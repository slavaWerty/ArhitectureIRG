using UnityEngine.SceneManagement;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Arhitecture
{
    public abstract class SceneManagerBase
    {
        public event Action<Scene> OnLoadedScene;
        public Scene scene { get; private set; }
        public bool IsLoading { get; private set; }

        protected Dictionary<string, SceneConfig> sceneConfigMap;

        public SceneManagerBase()
        {
            this.sceneConfigMap = new Dictionary<string, SceneConfig>();
            this.InitzializeMap();
        }

        public abstract void InitzializeMap();

        private IEnumerator LoadCurrentSceneRoutine(SceneConfig sceneConfig)
        {
            this.IsLoading = true;

            yield return Coroutines.StartRoutine(this.InitzializeSceneAsync(sceneConfig));

            this.IsLoading = false;
            this.OnLoadedScene?.Invoke(this.scene);
        }

        private IEnumerator LoadNewSceneRoutine(SceneConfig sceneConfig)
        {
            this.IsLoading = true;

            yield return Coroutines.StartRoutine(this.LoadSceneAsync(sceneConfig));
            yield return Coroutines.StartRoutine(this.InitzializeSceneAsync(sceneConfig));

            this.IsLoading = false;
            this.OnLoadedScene?.Invoke(this.scene);
        }

        public Coroutine LoadCurrentSceneAsync()
        {
            if (this.IsLoading)
                throw new Exception("Scene in loading now");

            var sceneName = SceneManager.GetActiveScene().name;
            var config = this.sceneConfigMap[sceneName];
            return Coroutines.StartRoutine(this.LoadCurrentSceneRoutine(config));
        }

        public Coroutine LoadNewSceneAsync(string sceneName)
        {
            if(this.IsLoading)
                throw new Exception("Scene in loading now");

            var config = this.sceneConfigMap[sceneName];
            return Coroutines.StartRoutine(this.LoadNewSceneRoutine(config));
        }

        private IEnumerator LoadSceneAsync(SceneConfig sceneConfig)
        {
            var async = SceneManager.LoadSceneAsync(sceneConfig.sceneName);
            async.allowSceneActivation = false;

            while(async.progress < 0.9f)
            {
                yield return null;
            }

            async.allowSceneActivation = true;
        }

        private IEnumerator InitzializeSceneAsync(SceneConfig sceneConfig)
        {
            this.scene = new Scene(sceneConfig);
            yield return this.scene.InitzializeAsync();
        }

        public T GetRepository<T>() where T : Repository
        {
            return this.scene.GetRepository<T>();
        }

        public T GetInteractor<T>() where T : Interactor
        {
            return this.scene.GetInteractor<T>();
        }
    }
}
