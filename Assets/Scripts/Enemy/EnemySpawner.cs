using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    [Header("Refrences")]
    [SerializeField] Transform[] enemies;
    [SerializeField] Transform enemySpawnPoint;

    [Header("Attributes")]
    [SerializeField] int baseEnemies = 8;
    [SerializeField] float timeBetweenWave = 5f;
    [SerializeField] float enemiesPerSecond = 0.5f;
    [SerializeField] float difficultyScalingFactor = 0.75f; // Increases enemy count every wave
    int currentWave = 1;
    float timeSinceLastSpawn;
    int enemiesLeftToSpawn;
    int enemiesAlive;
    bool isSpawning = false;

    void Update()
    {
        if ((!isSpawning))
            return;

        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0) //Spawns enemy every seconds if enemiesPerSecond is 0.5f 
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f;
            enemiesLeftToSpawn--;
            enemiesAlive++;
        }
    }

    void Start()
    {
        StartWave();
    }

    void StartWave()
    {
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();

    }

    int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor)); // getting number of enemies per waves
    }

    void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[enemyIndex], enemySpawnPoint.position, Quaternion.identity);
    }
}
