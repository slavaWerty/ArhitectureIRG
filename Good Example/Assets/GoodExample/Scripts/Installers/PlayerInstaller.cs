using Player;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Config _playerConfig;
        [SerializeField] private View _player;
        [SerializeField] private Transform _playerSpawn;

        public override void InstallBindings()
        {
            BindPlayer();
        }

        private void BindPlayer()
        {
            Container.Bind<Config>().FromInstance(_playerConfig).AsSingle();
            Container.Bind<Data>().AsSingle();
            Container.Bind<IDataSaver>().To<JsonSaver>().AsSingle();
            Container.Bind<IMovable>().To<MoveObject>().AsSingle();
            Container.Bind<Health>().AsSingle();

            View playerView = Container.InstantiatePrefabForComponent<View>(_player, _playerSpawn.position, Quaternion.identity, null);
            Container.Bind<View>().FromInstance(playerView).AsSingle();
        }
    }
}