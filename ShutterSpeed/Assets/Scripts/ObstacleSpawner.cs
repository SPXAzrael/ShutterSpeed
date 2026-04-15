using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] Transform obstacleParent;
    [SerializeField] float spawnInterval = 1f;
    [SerializeField] float spawnWidth = 4f;

    


    private void Start()
    {
       StartCoroutine(SpawnObstacleRoutine());
    }

    //Generates obstacels every 1 second
    IEnumerator SpawnObstacleRoutine() 
    {
        while (true)
        {
            GameObject randomObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPos = new Vector3(Random.Range(-spawnWidth, spawnWidth), transform.position.y, transform.position.z);
            
            yield return new WaitForSeconds(spawnInterval);

            Instantiate(randomObstacle, spawnPos, Random.rotation, obstacleParent);
            
        }
    }
}
