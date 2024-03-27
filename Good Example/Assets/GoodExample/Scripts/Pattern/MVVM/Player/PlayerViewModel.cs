using UnityEngine;

namespace Player
{
    public class PlayerViewModel
    {
        private PlayerData _playerData;
        private JsonSaver _saver;
        private PlayerConfig _config;
        private IMovable _movable;
        private IJumpable _jumpable;
        private PlayerMoveView _moveView;
        private PlayerJumpView _jumpView;

        public Color PlayerColor => _config.Color;
        public Sprite PlayerSprite => _config.Sprite;

        public PlayerViewModel(PlayerData data, JsonSaver saver, PlayerConfig config,
            IMovable movable, Rigidbody2D rb, GameObject runClip, AudioSource audioSource,
            Transform jumpTransform, GameObject jumpClipObject)
        {
            _playerData = data;
            _saver = saver;
            _config = config;
            _movable = movable;
            _jumpable = new PlayerJump(rb, config, runClip, jumpTransform);

            _moveView = new PlayerMoveView(_movable, audioSource, runClip, jumpTransform, _config);
            _jumpView = new PlayerJumpView(_jumpable, audioSource, jumpClipObject, config);
        }

        public void Move(Transform transform)
        {
            _movable.Move(transform);
        }

        public void Jump()
        {
            _jumpable.Jump();
        }

        public bool CheckGround(Transform transform)
        {
            return _jumpable.CheckGround(transform);
        }

        public void AddHealth(int count)
        {
            if (count < 0)
            {
                Debug.Log("Count меньше нуля");
                return;
            }

            _playerData.Health += count;
            _saver.Save();
        }

        public void SpendHealth(int count)
        {
            if (count < 0)
            {
                Debug.Log("Count меньше нуля");
                return;
            }

            _playerData.Health -= count;
            _saver.Save();
        }

        public void SetEffect(GameObject effect, bool active)
        {
            effect.SetActive(active);
        }
    }
}
