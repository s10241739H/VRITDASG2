using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public Rigidbody doorRigidbody;  // Reference to the door's Rigidbody
    public Transform keySocket;      // The target position for the key
    public float interactionRange = 0.5f;  // Distance for key-socket detection

    private bool isUnlocked = false;  // Tracks if the door is unlocked

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key") && !isUnlocked)
        {
            float distance = Vector3.Distance(other.transform.position, keySocket.position);

            if (distance <= interactionRange)
            {
                UnlockDoor(other.gameObject);
            }
        }
    }

    private void UnlockDoor(GameObject key)
    {
        isUnlocked = true;
        Debug.Log("Door unlocked!");

        // Attach key to the socket
        key.transform.position = keySocket.position;
        key.transform.rotation = keySocket.rotation;
        key.transform.SetParent(keySocket);

        // Unfreeze the door constraints
        doorRigidbody.constraints = RigidbodyConstraints.None;
    }
}
