using Newtonsoft.Json;
using UnityEngine;

public class PlayerData
{
    private float _speed;
    private float _jumpForce;
    private Color _color;
    private int _health;
    private LayerMask _layerMask;
    private float _radius;
    private AudioClip _runClip;
    private AudioClip _jumpClip;
    private float _stepsDistance;
    private Sprite _sprite;

    public LayerMask LayerMask => _layerMask;
    public Color Color => _color;
    public AudioClip RunClip => _runClip;
    public AudioClip JumpClip => _jumpClip;
    public Sprite Sprite
    {
        get => _sprite;
        set => _sprite = value;
    }

    public float StepsDistance
    {
        get => _stepsDistance;
        set
        {
            _stepsDistance = value;
        }
    }

    public float Radius
    {
        get => _radius;
        set
        {
            if(value < 0)
            {
                Debug.Log("Value меньше нуля");
                return;
            }

            _radius = value;
        }
    }

    public float Speed
    {
        get => _speed;
        set
        {
            if(value < 0)
            {
                Debug.Log("Value меньше нуля");
                return;
            }

            _speed = value;
        }
    }

    public float JumpForce
    {
        get => _jumpForce;
        set
        {
            if (value < 0)
            {
                Debug.Log("Value меньше нуля");
                return;
            }

            _jumpForce = value;
        }
    }

    public int Health
    {
        get => _health;
        set
        {
            if (value < 0)
            {
                Debug.Log("Value меньше нуля");
                return;
            }

            _health = value;
        }
    }

    public PlayerData(PlayerConfig config)
    {
        _speed = config.Speed;
        _jumpForce = config.JumpForce;
        _color = config.Color;
        _health = config.Health;
        _layerMask = config.LayerMask;
        _radius = config.Radius;
        _runClip = config.RunClip;
        _jumpClip = config.JumpClip;
        _stepsDistance = config.StepsDistance;
        _sprite = config.Sprite;
    }

    [JsonConstructor]

    public PlayerData(int health)
    {
        _health = health;
    }
}
