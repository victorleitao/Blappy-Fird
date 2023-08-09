using System.Collections.Generic;
using UnityEngine;

public class BackGroundSpawner : MonoBehaviour
{

    [Header("Prefabs Lists")]
    [Tooltip("List of broken lines prefabs to be spawned.")]
    public List<GameObject> brokenLinePrefabs;
    [Tooltip("List of buildings prefabs to be spawned.")]
    public List<GameObject> buildingsPrefabs;
    [Header("Spawn Settings")]
    [Tooltip("Time between buildings.")]
    public float buildingInterval = 1;
    [Tooltip("Distance of the spawning building on the X axis.")]
    public float buildingOffsetX = 15;
    private float buildingCooldown = 0;

    [Tooltip("Time between broken lines.")]
    public float brokenLineInterval = 1;
    [Tooltip("Distance of the spawning broken line on the X axis.")]
    public float brokenLineOffsetX = 15;
    private float brokenLineCooldown = 0;

    private void Start()
    {
        SpawnInitialBuildings();
    }

    void FixedUpdate()
    {
        // Ignore if game is over
        if (GameManager.Instance.IsGameOver())
        {
            return;
        }

        brokenLineCooldown -= Time.fixedDeltaTime;
        if (brokenLineCooldown <= 0f)
        {
            brokenLineCooldown = brokenLineInterval;

            // Spawn obstacle
            SpawnBrokenLine();
        }

        buildingCooldown -= Time.fixedDeltaTime;
        if (buildingCooldown <= 0f)
        {
            buildingCooldown = buildingInterval;

            // Spawn building
            SpawnBuilding();
        }
    }

    private void SpawnBrokenLine()
    {
        // Get random prefab
        int prefabIndex = Random.Range(0, brokenLinePrefabs.Count);
        GameObject prefab = brokenLinePrefabs[prefabIndex];

        // Get rotation
        Quaternion rotation = prefab.transform.rotation;

        // Get position
        float x = brokenLineOffsetX;
        float y = -2.58f;
        float z = -1;
        Vector3 position = new(x, y, z);

        // Instantiate prefab
        Instantiate(prefab, position, rotation);
    }

    private void SpawnBuilding()
    {
        // Get random prefab
        int prefabIndex = Random.Range(0, buildingsPrefabs.Count);
        GameObject prefab = buildingsPrefabs[prefabIndex];

        // Get rotation
        Quaternion rotation = prefab.transform.rotation;

        // Get position
        float x = buildingOffsetX;
        float z = 0.09f;
        Vector3 position = new(x, 0, z);

        // Instantiate prefab
        Instantiate(prefab, position, rotation);
    }

    private void SpawnInitialBuildings()
    {
        // Get random prefab
        int prefabIndex = Random.Range(0, buildingsPrefabs.Count);
        GameObject prefab = buildingsPrefabs[prefabIndex];

        // Get rotation
        Quaternion rotation = prefab.transform.rotation;

        // Get Z position
        float z = 0.09f;

        // Get X position
        float x = 10.45f;
        Vector3 position = new(x, 0, z);
        // Instantiate prefab
        Instantiate(prefab, position, rotation);

        // Instantiate another
        prefabIndex = Random.Range(0, buildingsPrefabs.Count);
        prefab = buildingsPrefabs[prefabIndex];
        x = 7.9f;
        position = new(x, 0, z);
        Instantiate(prefab, position, rotation);

        // Instantiate another
        prefabIndex = Random.Range(0, buildingsPrefabs.Count);
        prefab = buildingsPrefabs[prefabIndex];
        x = 5.35f;
        position = new(x, 0, z);
        Instantiate(prefab, position, rotation);

        // Instantiate another
        prefabIndex = Random.Range(0, buildingsPrefabs.Count);
        prefab = buildingsPrefabs[prefabIndex];
        x = 2.8f;
        position = new(x, 0, z);
        Instantiate(prefab, position, rotation);

        // Instantiate another
        prefabIndex = Random.Range(0, buildingsPrefabs.Count);
        prefab = buildingsPrefabs[prefabIndex];
        x = 0.25f;
        position = new(x, 0, z);
        Instantiate(prefab, position, rotation);

        // Instantiate another
        prefabIndex = Random.Range(0, buildingsPrefabs.Count);
        prefab = buildingsPrefabs[prefabIndex];
        x = -2.3f;
        position = new(x, 0, z);
        Instantiate(prefab, position, rotation);

        // Instantiate another
        prefabIndex = Random.Range(0, buildingsPrefabs.Count);
        prefab = buildingsPrefabs[prefabIndex];
        x = -4.85f;
        position = new(x, 0, z);
        Instantiate(prefab, position, rotation);

        // Instantiate another
        prefabIndex = Random.Range(0, buildingsPrefabs.Count);
        prefab = buildingsPrefabs[prefabIndex];
        x = -7.4f;
        position = new(x, 0, z);
        Instantiate(prefab, position, rotation);

        // Instantiate another
        prefabIndex = Random.Range(0, buildingsPrefabs.Count);
        prefab = buildingsPrefabs[prefabIndex];
        x = -9.95f;
        position = new(x, 0, z);
        Instantiate(prefab, position, rotation);

        // Instantiate another
        prefabIndex = Random.Range(0, buildingsPrefabs.Count);
        prefab = buildingsPrefabs[prefabIndex];
        x = -12.5f;
        position = new(x, 0, z);
        Instantiate(prefab, position, rotation);
    }
}
