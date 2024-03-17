using UnityEngine;

public class BootstrapPlayer : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;

    private void Start()
    {
        _playerView.Initzialize();
    }
}
