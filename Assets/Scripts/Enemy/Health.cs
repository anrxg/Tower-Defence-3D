using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int hitPoint = 3;
    [SerializeField] int earnedPoint = 70;
    bool isDestroyed = false;

    public void TakeDamage(int damage)
    {
        hitPoint -= damage;
        if (hitPoint <= 0 && !isDestroyed) // if hitpoint becomes 0 and the enemy is not destroyed
        {
            EnemySpawner.onEnemyDestroyed.Invoke();
            GameManager.instance.InscreasePoints(earnedPoint);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
