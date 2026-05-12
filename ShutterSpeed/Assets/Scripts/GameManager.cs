using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text distanceText;
    [SerializeField] float MagnetCooldown = 10f;
    [SerializeField] GameObject gameOverText;
    private float CooldownTimer = 0f;

    PlayerController player;
    LevelGenerator levelGenerator;

    bool gameOver = false;
    public bool magnet = false;

    public static GameManager instance;

    int score = 0;
    int scoreMultiplier = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    private void Update()
    {
        if (magnet)
        {
            CooldownTimer -= Time.deltaTime;
            if (CooldownTimer <= 0f)
            {
                magnet = false;
                CooldownTimer = 0f;
            }
        }

        DistanceTravelled();
    }

    public void ActivateDoubleCoins(float duration)
    {
        StartCoroutine(DoubleCoinsRoutine(duration));

    }


    public void UpdateScore(int amount)
    {
        if (gameOver) return;

        score += amount * scoreMultiplier;
        scoreText.text = score.ToString();
    }

    public void EnableMagnet()
    {
        magnet = true;
        CooldownTimer = MagnetCooldown;
    }

    public void GameOver()
    {
        gameOver = true;
        player.enabled = false;
        gameOverText.SetActive(true);
        Time.timeScale = 0.1f;
    }
    private void DistanceTravelled()
    {
        if (gameOver) return;

        int distanceDisplay = Mathf.FloorToInt(levelGenerator.DistanceTravelled);
        distanceText.text = distanceDisplay + " m";
    }

    IEnumerator DoubleCoinsRoutine(float duration)
    {
        scoreMultiplier = 2;
        yield return new WaitForSeconds(duration);
        scoreMultiplier = 1;
    }
}