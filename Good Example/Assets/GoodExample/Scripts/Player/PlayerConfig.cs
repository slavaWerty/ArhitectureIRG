using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Game/new PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [Header("Speed")]
    [SerializeField] private float _speed;
    [Header("Color and Sprite")]
    [SerializeField] private Color _color;
    [SerializeField] private Sprite _sprite;
    [Header("Health")]
    [SerializeField] private int _health;
    [Header("Jump")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _radius;
    [Header("Effect")]
    [SerializeField] private AudioClip _jumpClip;
    [SerializeField] private AudioClip _runClip;
    [Space(20)]
    [SerializeField] private float _stepsDistance;

    public float Speed => _speed;
    public float JumpForce => _jumpForce;
    public Color Color => _color;
    public int Health => _health;
    public LayerMask LayerMask => _layerMask;
    public float Radius => _radius;
    public AudioClip JumpClip => _jumpClip;
    public AudioClip RunClip => _runClip;
    public float StepsDistance => _stepsDistance;
    public Sprite Sprite => _sprite;
}

