using System;
using System.Collections.Generic;

namespace Patterns.Arhitecture
{
    public class SceneConfigExample : SceneConfig
    {
        public const string SceneName = "SampleScene";

        public override string sceneName => SceneName;

        public override Dictionary<Type, Interactor> CreateAllInteractors()
        {
            var interactorsMap = new Dictionary<Type, Interactor>();

            this.CreateInteractor<BankInteractor>(interactorsMap);
            this.CreateInteractor<PlayerInteractor>(interactorsMap);

            return interactorsMap;
        }

        public override Dictionary<Type, Repository> CreateAllRepositories()
        {
            var repositoriesMap = new Dictionary<Type, Repository>();

            this.CreateRepository<BankRepository>(repositoriesMap);

            return repositoriesMap;
        }
    }
}
