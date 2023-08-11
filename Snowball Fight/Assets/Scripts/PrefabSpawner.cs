using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnInterval = 2.0f;
    public Vector2 spawnRange = new Vector2(-5f, 5f); // Adjust the range as needed

    private float timer = 0.0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPrefab();
            timer = 0.0f;
        }
    }

    private void SpawnPrefab()
    {
        Vector2 spawnPosition = new Vector2(
            Random.Range(spawnRange.x, spawnRange.y),
            transform.position.y // Use the spawner's y-position for the y-coordinate
        );

        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}
