using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;
    public float maxHealth = 100;
    public float currentHealth;
    float tmpDamage;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealth(currentHealth, maxHealth);
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            GameManager.instance.GameOver();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                currentHealth -= enemy.damage;
                healthBar.UpdateHealth(maxHealth, currentHealth);
                Destroy(other.gameObject);
                EnemySpawner.onEnemyDestroyed.Invoke();
            }
            Destroy(other.gameObject);
        }
    }

    public void BaseDamage(int damage)
    {
        currentHealth -= damage;
    }
}
