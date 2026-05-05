using System;
using TMPro;
using Unity.VisualScripting;
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

    private void FixedUpdate()
    {
        DistanceTravelled();
    }

    private void DistanceTravelled()
    {
        if (gameOver) return;

        int distanceDisplay = Mathf.FloorToInt(levelGenerator.DistanceTravelled);
        distanceText.text = distanceDisplay + " m";
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
    }


    public void UpdateScore(int amount)
    {
        if (gameOver) return;

        score += amount;
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
}