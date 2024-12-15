using UnityEngine;

public class Trash : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object colliding is tagged as "Broom"
        if (collision.gameObject.CompareTag("Broom"))
        {
            Destroy(gameObject); // Destroy the trash
        }
    }
}
