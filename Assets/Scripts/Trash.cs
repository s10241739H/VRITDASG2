using UnityEngine;

public class Trash : MonoBehaviour
{
    private int collisionCount = 0;  // Tracks how many times the broom collides
    public TrashManager trashManager;  // Reference to the TrashManager script

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is the broom
        if (collision.gameObject.CompareTag("Broom"))
        {
            collisionCount++;  // Increase the collision count
            Debug.Log("Broom hit trash! Count: " + collisionCount);

            // Destroy the trash after 3 collisions
            if (collisionCount >= 3)
            {
                Debug.Log("Trash destroyed!");
                Destroy(gameObject);  // Destroy the trash object
            }
        }
    }

    private void OnDestroy()
    {
        // Notify the TrashManager when the trash is destroyed
        if (trashManager != null)
        {
            trashManager.ClearTrash();
        }
    }
}
