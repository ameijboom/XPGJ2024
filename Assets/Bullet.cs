using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;

    private void FixedUpdate()
    {
        transform.Translate((Vector2.right * bulletSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerHealth.instance.TakeDamage(1f);
            Destroy(gameObject);
        }
    }
}
