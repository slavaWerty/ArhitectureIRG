using Player;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private PlayerView _player;
    [SerializeField] private Transform _playerSpawn;

    public override void InstallBindings()
    {
        BindPlayer();
    }

    private void BindPlayer()
    {
        Container.Bind<PlayerConfig>().FromInstance(_playerConfig).AsSingle();
        Container.Bind<PlayerData>().AsSingle();
        Container.Bind<JsonSaver>().AsSingle();
        Container.Bind<IMovable>().To<PlayerMove>().AsSingle();

        PlayerView playerView = Container.InstantiatePrefabForComponent<PlayerView>(_player, _playerSpawn.position, Quaternion.identity, null);
        Container.Bind<PlayerView>().FromInstance(playerView).AsSingle();
    }
}