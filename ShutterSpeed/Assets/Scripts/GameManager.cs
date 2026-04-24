using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    public bool magnet = false;

    public static GameManager instance;

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

    int score = 0;

    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    public void EnableMagnet()
    {
        magnet = true;
    }


}