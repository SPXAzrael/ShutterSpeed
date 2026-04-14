using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float spawnInterval = 1f;

    int obstacleSpawned;


    private void Start()
    {
       StartCoroutine(SpawnObstacleRoutine());
    }

    //Generates obstacels every 1 second
    IEnumerator SpawnObstacleRoutine() 
    {
        while (obstacleSpawned < 5)
        {
            yield return new WaitForSeconds(spawnInterval);
            Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
            obstacleSpawned++;
        }
    }
}
