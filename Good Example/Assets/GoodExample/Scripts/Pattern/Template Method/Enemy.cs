using Player;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _trigger;

    private IEnemySystem _enemySystem;
    private bool _IsPlayer = false;

    public int Damage => _enemySystem.Damage;

    private void OnValidate()
    {
        _trigger ??= GetComponent<BoxCollider2D>();
        _trigger.isTrigger = true;
        _trigger.size = new Vector2(3, 3);
    }

    [Inject]
    public void Initziazlie(IEnemySystem enemySystem)
    {
        _enemySystem = enemySystem;
    }

    private void Update()
    {
        if (!_IsPlayer)
            return;

        _enemySystem.Work();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != null)
        {
            if (collision.gameObject.GetComponent<PlayerView>() != null)
            {
                _IsPlayer = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject != null)
        {
            if (collision.gameObject.GetComponent<PlayerView>() != null)
            {
                _IsPlayer = false;
            }
        }
    }
}

