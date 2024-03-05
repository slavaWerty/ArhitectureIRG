using System;
using System.Collections.Generic;

namespace Patterns.Arhitecture
{
    public class RepositoriesBase
    {
        private Dictionary<Type, Repository> _repositoryMap;
        private SceneConfig _sceneConfig;

        public RepositoriesBase(SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;
        }

        public void CreateAllRepositories()
        {
           this._repositoryMap =  this._sceneConfig.CreateAllRepositories();
        }

        public void SendToCreateAllRepositories()
        {
            var allInteractors = this._repositoryMap.Values;
            foreach (var interactor in allInteractors)
            {
                interactor.OnCreate();
            }
        }

        public void InitzializeAllRepositories()
        {
            var allInteractors = this._repositoryMap.Values;
            foreach (var interactor in allInteractors)
            {
                interactor.Initzialize();
            }
        }

        public void SendToStartAllRepositories()
        {
            var allInteractors = this._repositoryMap.Values;
            foreach (var interactor in allInteractors)
            {
                interactor.OnStart();
            }
        }

        public T GetRepository<T>() where T : Repository
        {
            var type = typeof(T);
            return (T)this._repositoryMap[type];
        }
    }

}
