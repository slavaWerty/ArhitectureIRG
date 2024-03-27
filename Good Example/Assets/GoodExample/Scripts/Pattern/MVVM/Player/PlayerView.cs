using UnityEngine;
using Zenject;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(AudioSource))]
    public class PlayerView : MonoBehaviour
    {
        private const string Horizontal = "Horizontal";

        [SerializeField] private Transform _jumpPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ParticleSystem _jumpEffect;
        [SerializeField] private ParticleSystem _runEffect;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private PlayerViewModel _viewModel;

        private void OnValidate()
        {
            _rigidbody2D ??= GetComponent<Rigidbody2D>();
            _spriteRenderer ??= GetComponent<SpriteRenderer>();
            _audioSource ??= GetComponent<AudioSource>();
        }

        [Inject]
        public void Initzialize(PlayerData data, JsonSaver saver, PlayerConfig config, IMovable movable)
        {
            _viewModel = new PlayerViewModel(data, saver, config, movable, _rigidbody2D, _runEffect.gameObject, _audioSource, 
                _jumpPosition, _jumpEffect.gameObject);
            SetPlayer();
        }

        private void SetPlayer()
        {
            _spriteRenderer.color = _viewModel.PlayerColor;
            _spriteRenderer.sprite = _viewModel.PlayerSprite;
        }

        private void Update()
        {
            if (Input.GetAxis(Horizontal) != 0)
                _viewModel.Move(gameObject.transform);
            else
                _viewModel.SetEffect(_runEffect.gameObject, false);

            if (_viewModel.CheckGround(_jumpPosition) == false)
                _viewModel.SetEffect(_jumpEffect.gameObject, true);
            else
                _viewModel.SetEffect(_jumpEffect.gameObject, false);

            if (Input.GetKeyDown(KeyCode.Space) && _viewModel.CheckGround(_jumpPosition))
                _viewModel.Jump();
        }

        public void SpendHealth(int value)
        {
            _viewModel.SpendHealth(value);
        }

        public void AddHealth(int value)
        {
            _viewModel.AddHealth(value);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject == null)
                return;

            if (!collision.gameObject.TryGetComponent(out Enemy enemy))
                return;

            SpendHealth(enemy.Damage);
        }
    }
}

