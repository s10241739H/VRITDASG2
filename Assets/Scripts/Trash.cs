using UnityEngine;

public class Trash : MonoBehaviour
{
    private bool isBeingCleaned = false;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object colliding with the trash is tagged as "Broom"
        if (collision.gameObject.CompareTag("Broom") && IsBroomHeld(collision.gameObject))
        {
            isBeingCleaned = true;
            // Destroy or disable the trash object
            Destroy(gameObject); // Removes the trash from the scene
        }
    }

    // This function checks if the broom is being held by the player
    private bool IsBroomHeld(GameObject broom)
    {
        // Replace this with your logic for detecting if the broom is held.
        // For example, checking if the broom is a child of the player's hand.
        var hand = broom.transform.parent; // Assuming it's parented to a VR hand object when picked up
        return hand != null && hand.CompareTag("PlayerHand");
    }
}
