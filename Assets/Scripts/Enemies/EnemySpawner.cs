using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform player;

    [Header("Wave Settings")]
    [SerializeField] private int startingEnemyCount = 10;
    [SerializeField] private int additionalEnemiesPerWave = 5;
    [SerializeField] private float spawnInterval = 0.5f;
    [SerializeField] private float waveDelay = 3f;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnDistance = 12f;

    private int currentWave = 0;
    private int enemiesToSpawn;
    private int enemiesSpawned;

    private float spawnTimer;
    private float waveTimer;

    private bool spawningWave;
    private bool waitingForNextWave;

    private void Start()
    {
        StartWave();
    }

    private void Update()
    {
        if (waitingForNextWave)
        {
            waveTimer -= Time.deltaTime;

            if (waveTimer <= 0f) StartWave();

            return;
        }

        if (!spawningWave) return;

        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnEnemy();

            enemiesSpawned++;
            spawnTimer = spawnInterval;

            if (enemiesSpawned >= enemiesToSpawn)
            {
                spawningWave = false;
                waitingForNextWave = true;
                waveTimer = waveDelay;
            }
        }
    }

    private void StartWave()
    {
        currentWave++;
        enemiesToSpawn = startingEnemyCount + (currentWave - 1) * additionalEnemiesPerWave;
        enemiesSpawned = 0;
        spawningWave = true;
        waitingForNextWave = false;
        spawnTimer = 0f;

        Debug.Log($"Wave {currentWave} started. Enemies: {enemiesToSpawn}");
    }

    private void SpawnEnemy()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        Vector3 spawnPosition = player.position + new Vector3(
            randomDirection.x,
            0f,
            randomDirection.y
        ) * spawnDistance;

        Enemy enemy = Instantiate(
            enemyPrefab,
            spawnPosition,
            Quaternion.identity);

        enemy.Initialize(player);
    }
}
