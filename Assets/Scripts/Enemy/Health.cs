using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int hitPoint = 3;

    public void TakeDamage(int damage)
    {
        hitPoint -= damage;
        if (hitPoint <= 0)
        {
            EnemySpawner.onEnemyDestroyed.Invoke();
            Destroy(gameObject);
        }
    }
}
