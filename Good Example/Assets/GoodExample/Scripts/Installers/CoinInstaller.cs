using Money;
using Player;
using TMPro;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class CoinInstaller : MonoInstaller
    {
        [SerializeField] private Canvas _canvas;

        public override void InstallBindings()
        {
            Container.Bind<Data>().AsSingle();
            Container.Bind<Wallet>().AsSingle();
            Container.Bind<CoinDisplay>().AsSingle().WithArguments(_canvas.GetComponentInChildren<TextMeshProUGUI>());
        }
    }
}
