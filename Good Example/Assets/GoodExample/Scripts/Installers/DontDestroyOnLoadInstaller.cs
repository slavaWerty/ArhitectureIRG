using UnityEngine;
using Zenject;

namespace Installers
{
    public class DontDestroyOnLoadInstaller : MonoInstaller
    {
        [SerializeField] private GameObject[] _dontDestroy;

        public override void InstallBindings()
        {
            foreach (GameObject go in _dontDestroy)
            {
                DontDestroyOnLoad(Instantiate(go));
            }
        }
    }
}
