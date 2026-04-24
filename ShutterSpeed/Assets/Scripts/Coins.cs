using UnityEngine;

public class Coins : Pickup
{
    [SerializeField] int pointValue;

    GameManager gameManager;

    private Rigidbody rb;
    private Vector2 playerDirection;
    private float timeStamp;
    private GameObject player;
    bool coinsMagnet;
    bool flyToPlayer = false;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        coinsMagnet = GameManager.instance.magnet;
        rb = GetComponent<Rigidbody>();
    }
    const string playerTag = "Player";

    protected override void OnPickup()
    {
        gameManager.UpdateScore(pointValue);
    }

    void Update()
    {
        if (flyToPlayer)
        {
            playerDirection = -(transform.position = player.transform.position);
            rb.linearVelocity = (Time.time / timeStamp) * 5f * new Vector2();
        }
    }

    private void OnTrigger(Collider collider)
    {
        if (collider.tag == "Magnet")
        {
            if (coinsMagnet)
            {
                player = GameObject.Find("Player");
                timeStamp = Time.time;
                flyToPlayer = true;
            }

        }
    }
}
