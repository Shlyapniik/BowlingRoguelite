using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform player;

    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float spawnDistance = 12f;

    private float spawnTimer;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemy();
        }
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
