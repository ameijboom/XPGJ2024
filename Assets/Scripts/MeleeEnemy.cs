using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _attackCD;

    private float _lastAttack;

    private float _distance;

    private void Update()
    {
        _distance = Vector2.Distance(transform.position, _player.transform.position);

        transform.position =
            Vector2.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(Time.time - _lastAttack < _attackCD) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.instance.TakeDamage(1f);
        }

        _lastAttack = Time.time;
    }
}
