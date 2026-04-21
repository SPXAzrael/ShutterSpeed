using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    const string playerTag = "Player";

    protected abstract void OnPickup();

    private void OnTriggerEnter(Collider other)
    {
        // If the player picks up a powerup it will destroy it and activate the powerup code
        if (other.CompareTag(playerTag))
        {
            OnPickup();
            Destroy(gameObject);
        }
    }
}
