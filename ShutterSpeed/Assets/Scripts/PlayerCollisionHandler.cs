using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{
    public GameObject hazard;
    [SerializeField] float hitCooldown = 1f;
    GameManager gameManager;
    int hitCount;
    float lastHitTime = -Mathf.Infinity;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            TakeHit();
            Destroy(other.gameObject);
            //    SceneManager.LoadScene(0); ;
        }

    }

    void TakeHit()
    {
        float currentTime = Time.time;

        if (currentTime - lastHitTime <= hitCooldown)
        {
            hitCount++;
        }
        else
        {
            hitCount = 1;
        }

        lastHitTime = currentTime;

        if (hitCount >= 2)
        {
            gameManager.GameOver();
        }
    }
}
