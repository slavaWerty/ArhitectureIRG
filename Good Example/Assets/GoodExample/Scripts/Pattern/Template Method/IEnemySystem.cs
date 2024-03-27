using Player;
using UnityEngine;

public abstract class IEnemySystem
{
    protected Transform _transform;
    protected PlayerView _target;
    protected int _damage;
    protected float _attackDistance;
    protected float _speed;

    public int Damage => _damage;

    public void Work()
    {
        Move();
        Attack();
    }

    public virtual void Move()
    {
        Debug.Log("Move Worked");
    }

    public virtual void Attack()
    {
        Debug.Log("Attack Worked");
    }
}
