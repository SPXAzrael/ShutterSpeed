using UnityEngine;
using TMPro;

public class UIHandeler : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI distanceTravelledText;

    //refrence
    PlayerController  playerController;

     void Awake()
    {
      playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();  
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelledText.text = playerController.DistanceTravelled.ToString("000000");
    }
}
