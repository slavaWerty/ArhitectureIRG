using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public class PlayerView : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private Transform _jumpPosition;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private ParticleSystem _jumpEffect;
    [SerializeField] private ParticleSystem _runEffect;

    private PlayerViewModel _viewModel;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private IPersistantData _persistantData;

    private void OnValidate()
    {
        _rigidbody2D ??= GetComponent<Rigidbody2D>();
        _spriteRenderer ??= GetComponent<SpriteRenderer>();
        _audioSource ??= GetComponent<AudioSource>();
    }

    public void Initzialize()
    {
        _persistantData = new PersistantData();
        _viewModel = new PlayerViewModel(_persistantData, _playerConfig);
        _spriteRenderer.color = _viewModel.GetColor();
        _spriteRenderer.sprite = _viewModel.GetSprite();
        _viewModel.Load();
    }

    private void Update()
    {
        if (Input.GetAxis(Horizontal) != 0)
            _viewModel.Move(transform, _audioSource, _runEffect.gameObject, _jumpPosition);
        else
            _viewModel.SetEffect(_runEffect.gameObject, false);

        if (_viewModel.CheckGround(_jumpPosition) == false)
            _viewModel.SetEffect(_jumpEffect.gameObject, true);
        else
            _viewModel.SetEffect(_jumpEffect.gameObject, false);

        if (Input.GetKeyDown(KeyCode.Space) && _viewModel.CheckGround(_jumpPosition))
            _viewModel.Jump(_rigidbody2D, _audioSource, _jumpEffect.gameObject);
    }
}

