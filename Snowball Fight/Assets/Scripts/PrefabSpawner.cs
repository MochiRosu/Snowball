using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // Array of prefabs to spawn
    public Vector2 spawnRange;
    public float spawnInterval = 2.0f;

    private float timer = 0.0f;

    private void Start()
    {
        timer = spawnInterval;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnPrefab();
            timer = spawnInterval;
        }
    }

    private void SpawnPrefab()
    {
        // Calculate a random position within the spawn range
        Vector2 randomPosition = new Vector2(
            Random.Range(-spawnRange.x, spawnRange.x),
            Random.Range(-spawnRange.y, spawnRange.y)
        );

        // Choose a random prefab from the array
        GameObject randomPrefab = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];

        // Spawn the chosen prefab at the random position
        Instantiate(randomPrefab, randomPosition, Quaternion.identity);
    }
}
