using System;
using UnityEngine;

namespace Player
{
    public class PlayerJumpView : IDisposable
    {
        private IJumpable _jumpable;

        private AudioSource _source;
        private AudioClip _clip;
        private GameObject _jumpClipObject;

        public PlayerJumpView(IJumpable jumpable, AudioSource source, GameObject jumpClipObject, PlayerConfig config)
        {
            _jumpable = jumpable;
            _source = source;
            _clip = config.JumpClip;
            _jumpClipObject = jumpClipObject;

            _jumpable.Jumped += OnJumped;
        }

        private void OnJumped()
        {
            _source.clip = _clip;
            _source.Play();
            SetEffect(_jumpClipObject, true);
        }

        public void Dispose()
        {
            _jumpable.Jumped -= OnJumped;
        }

        private void SetEffect(GameObject effect, bool active)
        {
            effect.SetActive(active);
        }
    }
}
