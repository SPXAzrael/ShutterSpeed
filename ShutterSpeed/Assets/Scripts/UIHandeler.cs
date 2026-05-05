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
      playerController = FindFirstObjectByType<PlayerController>();  
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelledText.text = playerController.DistanceTravelled.ToString("000000");
    }
}
