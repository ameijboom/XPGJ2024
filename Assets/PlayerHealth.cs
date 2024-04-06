using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance { get; private set; }
    
    [SerializeField] private float playerHealth;
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        Debug.Log("Ouch! " + playerHealth);
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
