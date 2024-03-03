using System.Collections;
using UnityEngine;

namespace Patterns.Arhitecture
{
    public class Scene
    {
        private InteractorsBase _interactorsBase;
        private RepositoriesBase _repositoriesBase;
        private SceneConfig _sceneConfig;

        public Scene(SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;
            _interactorsBase = new InteractorsBase(_sceneConfig);
            _repositoriesBase = new RepositoriesBase(_sceneConfig);
        }

        public Coroutine InitzializeAsync()
        {
            return Coroutines.StartRoutine(this.InitzializeRoutine());
        }

        private IEnumerator InitzializeRoutine()
        {
            _interactorsBase.CreateAllInteractors();
            _repositoriesBase.CreateAllRepositories();
            yield return null;

            _interactorsBase.SendToCreateAllInteractions();
            _repositoriesBase.SendToCreateAllRepositories();
            yield return null;

            _interactorsBase.InitzializeAllInteractions();
            _repositoriesBase.InitzializeAllRepositories();
            yield return null;

            _interactorsBase.SendToStartAllInteractions();
            _repositoriesBase.SendToStartAllRepositories();
            yield return null;
        }

        public T GetRepository<T>() where T : Repository
        {
            return this._repositoriesBase.GetRepository<T>();
        }

        public T GetInteractor<T>() where T : Interactor
        {
            return this._interactorsBase.GetInteractor<T>();
        }
    }

}
