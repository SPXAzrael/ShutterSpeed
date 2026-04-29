using UnityEngine;

public class Coins : Pickup
{
    [SerializeField] int pointValue;


    GameManager gameManager;


    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    protected override void OnPickup()
    {
        gameManager.UpdateScore(pointValue);
    }
}
