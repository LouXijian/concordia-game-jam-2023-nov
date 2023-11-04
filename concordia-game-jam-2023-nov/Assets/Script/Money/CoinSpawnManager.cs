using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnManager : MonoBehaviour
{
    public GameObject coinPrefab; // Assign your coin prefab in the Inspector
    public float spawnHeight = 0.5f; // Height above the ground to spawn coins
    public float maxRaycastDistance = 100f; // Maximum distance for the raycast
    public int numberOfCoins = 10; // Number of coins you want to spawn

    private List<Transform> groundTransforms;

    private void Start()
    {
        // Find all ground objects in the scene
        GameObject[] grounds = GameObject.FindGameObjectsWithTag("ground");
        groundTransforms = new List<Transform>();

        foreach (GameObject ground in grounds)
        {
            if (ground.GetComponent<Collider>() != null)
            {
                groundTransforms.Add(ground.transform);
            }
        }

        if (groundTransforms.Count > 0)
        {
            for (int i=0; i<numberOfCoins; i++)
            {
                SpawnCoin();
            }
        }
        else
        {
            Debug.LogError("No ground found with 'ground' tag or missing Colliders.");
        }
    }

    private void SpawnCoin()
    {
        // Randomly select a ground transform
        Transform selectedGround = groundTransforms[Random.Range(0, groundTransforms.Count)];

        // Get the bounds of the selected ground collider
        Bounds bounds = selectedGround.GetComponent<Collider>().bounds;

        // Attempt to find a valid point on the selected ground object
        Vector3 randomPoint = GetRandomPointOnGround(bounds);

        if (randomPoint != Vector3.zero) // If a valid point was found
        {
            // Spawn the coin at the found location
            Instantiate(coinPrefab, randomPoint, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Failed to find a valid point on the ground to spawn the coin.");
        }
    }

    private Vector3 GetRandomPointOnGround(Bounds bounds)
    {
        for (int i = 0; i < 10; i++) // Try up to 10 times to find a valid point
        {
            // Generate a random point within the bounds of the ground collider
            Vector3 randomPoint = new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                bounds.max.y + spawnHeight,
                Random.Range(bounds.min.z, bounds.max.z)
            );

            // Cast a ray downward from the spawnHeight to find the ground surface
            if (Physics.Raycast(randomPoint, Vector3.down, out RaycastHit hit, maxRaycastDistance))
            {
                // Return the point on the ground's surface
                return hit.point;
            }
        }

        // Return zero if no valid point was found after all attempts
        return Vector3.zero;
    }
}
