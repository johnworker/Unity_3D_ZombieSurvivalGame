using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public int damage = 10;
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
