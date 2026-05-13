using UnityEngine;

public class MoveCoin : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 playerDirection;
    private float timeStamp;
    private PlayerController player;
    bool coinsMagnet;
    bool flyToPlayer = false;

    private void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (player == null) return;

        if (flyToPlayer)
        {
            playerDirection = -(transform.position - player.transform.position);
            rb.linearVelocity = (Time.time / timeStamp) * 10f * new Vector2(playerDirection.x, playerDirection.y);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Magnet")
        {
            coinsMagnet = GameManager.instance.magnet;

            if (coinsMagnet)
            {
                timeStamp = Time.time;
                flyToPlayer = true;
            }

        }
    }
}
