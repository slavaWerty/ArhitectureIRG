using Player;
using UnityEngine;

public class BaseEnemySystem : IEnemySystem
{
    public new int Damage => _damage;

    public BaseEnemySystem(PlayerView target, Transform transform, float speed, float attackDistance, int damage)
    {
        _target = target;
        _transform = transform;
        _speed = speed;
        _attackDistance = attackDistance;
        _damage = damage;
    }

    public override void Attack()
    {
        if (_transform.position.x - _target.transform.position.x < _attackDistance)
        {
            _target.SpendHealth(_damage);
            Debug.Log("Attack");
        }
    }

    public override void Move()
    {
        if (_target.transform.position != _transform.position)
        {
            Vector3.Lerp(_transform.position, _target.transform.position, Time.deltaTime * _speed);
            Debug.Log("Move");
        }
    }
}

