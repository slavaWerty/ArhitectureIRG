using System;
using System.Collections;

namespace Patterns.Arhitecture
{
    public static class Game
    {
        public static event Action OnGameInitzialized;
        public static SceneManagerBase sceneManager { get; private set; }

        public static void Run()
        {
            sceneManager = new SceneManagerExample();
            Coroutines.StartRoutine(InitzializeGameRoutine());
        }

        private static IEnumerator InitzializeGameRoutine()
        {
            sceneManager.InitzializeMap();
            yield return sceneManager.LoadCurrentSceneAsync();
            OnGameInitzialized?.Invoke();
        }

        public static T GetInteractor<T>() where T : Interactor
        {
            return sceneManager.GetInteractor<T>();
        }

        public static T GetRepository<T>() where T : Repository
        {
            return sceneManager.GetRepository<T>();
        }
    }

}

