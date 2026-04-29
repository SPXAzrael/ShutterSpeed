using UnityEngine;

public class Magnet : Pickup
{

    [SerializeField] float rotationSpeed = 100f;

    GameManager gameManager;


    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    protected override void OnPickup()
    {
        if (gameManager.magnet) return;

        Debug.Log("Start Magnet Powerup");
        gameManager.EnableMagnet();
    }

    void Update()
    {
        // Makes the powerup rotate in place
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
