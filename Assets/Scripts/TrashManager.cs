using UnityEngine;

public class TrashManager : MonoBehaviour
{
    public GameObject keyPrefab; // Assign the key prefab in the inspector
    public Transform keySpawnPoint; // Assign the spawn point for the key
    private int trashClearedCount = 0; // Tracks the number of trash cleared
    private int trashThreshold = 10; // Number of trash to clear before spawning the key
    private bool keySpawned = false; // Ensures the key only spawns once

    // Call this method whenever a trash item is cleared
    public void ClearTrash()
    {
        trashClearedCount++;

        if (trashClearedCount >= trashThreshold && !keySpawned)
        {
            SpawnKey();
        }
    }

    private void SpawnKey()
    {
        if (keyPrefab != null && keySpawnPoint != null)
        {
            Instantiate(keyPrefab, keySpawnPoint.position, keySpawnPoint.rotation);
            Debug.Log("Key has appeared!");
            keySpawned = true; // Prevent further spawning
        }
        else
        {
            Debug.LogWarning("Key prefab or spawn point is not assigned.");
        }
    }
}

