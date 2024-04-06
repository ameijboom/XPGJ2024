using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public Transform shotPoint;
    public Transform gun;

    public GameObject enemyProjectile;

    public float startTimeShots;
    private float _timeBetweenShots;
    
    private Transform _player;
    
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update()
    {
        Flip();
        Vector3 difference = _player.position - gun.transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if (_timeBetweenShots <= 0)
        {
            Instantiate(enemyProjectile, shotPoint.position, shotPoint.transform.rotation);
            _timeBetweenShots = startTimeShots;
        }
        else
        {
            _timeBetweenShots -= Time.deltaTime;
        }
    }

    void Flip()
    {
        if (transform.position.x - _player.transform.position.x >= 0)
        {
            transform.Rotate(0,180,0);
        }
        else
        {
            transform.Rotate(0,0,0);
        }
    }
}
