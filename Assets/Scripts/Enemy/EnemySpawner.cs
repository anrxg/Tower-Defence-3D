using System.Collections;
using UnityEngine;
using UnityEngine.Events;

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

    [Header("Events")]
    public static UnityEvent onEnemyDestroyed = new UnityEvent();
    int currentWave = 1;
    float timeSinceLastSpawn;
    int enemiesLeftToSpawn;
    int enemiesAlive;
    bool isSpawning = false;

    void Awake()
    {
        onEnemyDestroyed.AddListener(EnemyDestroy);
    }
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

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            StartCoroutine(WaveEnd());
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
        Instantiate(enemies[enemyIndex], enemySpawnPoint.position, Quaternion.identity); // Spawining enemies
    }

    void EnemyDestroy()
    {
        enemiesAlive--;
    }

    IEnumerator WaveEnd()
    {
        yield return new WaitForSeconds(timeBetweenWave);
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(WaveEnd());
    }
}
