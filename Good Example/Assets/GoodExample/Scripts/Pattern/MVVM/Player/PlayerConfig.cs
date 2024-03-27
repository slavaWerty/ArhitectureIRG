using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Game/new PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private Color _color;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private AudioClip _jumpClip;
    [SerializeField] private AudioClip _runClip;
    [SerializeField] private float _radius;
    [SerializeField] private float _stepsDistance;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    public Color Color => _color;
    public LayerMask LayerMask => _layerMask;
    public AudioClip JumpClip => _jumpClip;
    public AudioClip RunClip => _runClip;
    public Sprite Sprite => _sprite;
    public float Radius => _radius;
    public float StepsDistance => _stepsDistance;
    public float Speed => _speed;
    public float JumpForce => _jumpForce;
}

