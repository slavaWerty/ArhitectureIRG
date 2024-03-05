using System;
using System.Collections.Generic;

namespace Patterns.Arhitecture
{
    internal class InteractorsBase
    {
        private Dictionary<Type, Interactor> _interactorsMap;
        private SceneConfig _sceneConfig;

        public InteractorsBase(SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;
        }


        public void CreateAllInteractors()
        {
            this._interactorsMap = this._sceneConfig.CreateAllInteractors();
        }

        public void SendToCreateAllInteractions()
        {
            var allInteractors = this._interactorsMap.Values;
            foreach (var interactor in allInteractors)
            {
                interactor.OnCreate();
            }
        }

        public void InitzializeAllInteractions()
        {
            var allInteractors = this._interactorsMap.Values;
            foreach (var interactor in allInteractors)
            {
                interactor.Initzialize();
            }
        }

        public void SendToStartAllInteractions()
        {
            var allInteractors = this._interactorsMap.Values;
            foreach (var interactor in allInteractors)
            {
                interactor.OnStart();
            }
        }

        public T GetInteractor<T>() where T : Interactor
        {
            var type = typeof(T);
            return (T) this._interactorsMap[type];
        }
    }
}
