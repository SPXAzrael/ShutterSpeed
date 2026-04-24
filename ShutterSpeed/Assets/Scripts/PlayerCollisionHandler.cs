using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public GameObject hazard;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            Destroy(gameObject);
        }
        //Debug.Log(other.gameObject);
    }
}
