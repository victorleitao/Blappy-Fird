using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    private float cooldown = 0;

    void FixedUpdate()
    {
        // Ignore if game is over
        if (GameManager.Instance.IsGameOver())
        {
            return;
        }

        cooldown -= Time.fixedDeltaTime;
        if (cooldown <= 0f)
        {
            cooldown = GameManager.Instance.obstacleInterval;

            // Spawn obstacle
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        // Get random prefab
        int prefabIndex = Random.Range(0, GameManager.Instance.obstaclePrefabs.Count);
        GameObject prefab = GameManager.Instance.obstaclePrefabs[prefabIndex];

        // Get rotation
        Quaternion rotation = prefab.transform.rotation;

        // Get position
        float x = GameManager.Instance.obstacleOffsetX;
        float y = Random.Range(GameManager.Instance.obstacleOffsetY.x, GameManager.Instance.obstacleOffsetY.y);
        float z = -1;
        Vector3 position = new Vector3(x, y, z);

        // Instantiate prefab
        Instantiate(prefab, position, rotation);
    }
}
