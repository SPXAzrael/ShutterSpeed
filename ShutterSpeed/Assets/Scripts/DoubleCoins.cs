using UnityEngine;

public class DoubleCoins : Pickup
{
    [SerializeField] float PowerUpDuration = 10f;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
    protected override void OnPickup()
    {
        gameManager.ActivateDoubleCoins(PowerUpDuration);
    }


}
