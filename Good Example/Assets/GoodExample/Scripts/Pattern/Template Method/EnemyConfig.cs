using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Game/new EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] protected int _damage;
    [SerializeField] protected float _attackDistance;
    [SerializeField] protected float _speed;

    public int Damage => _damage;
    public float AttackDistance => _attackDistance;
    public float Speed => _speed;
}

