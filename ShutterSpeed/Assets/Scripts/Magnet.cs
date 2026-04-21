using UnityEngine;

public class Magnet : Pickup
{

    [SerializeField] float rotationSpeed = 100f;

    protected override void OnPickup()
    {
        Debug.Log("Start Magnet Powerup");
    }

    void Update()
    {
        // Makes the powerup rotate in place
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
