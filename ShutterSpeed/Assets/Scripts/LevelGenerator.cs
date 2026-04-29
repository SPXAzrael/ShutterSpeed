using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] levelChunks;
    [SerializeField] Transform chunkParent;
    [SerializeField] int startingChunks = 12;
    [SerializeField] float chunkLength = 10f; //1 unit = 1 metre
    [SerializeField] float moveSpeed = 8f; //movement speed of chunks

    List<GameObject> chunks = new List<GameObject>();

    private void Start()
    {
        
        SpawnStartingChunks();

    }

    private void Update()
    {
        MoveChunks();

    }

    private void SpawnStartingChunks()
    {
        //Whilst less than 12 add 1- runs code 12 times until i value = startingchunks value
        for (int i = 0; i < startingChunks; i++)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        // Calculates where the transform position should be- Z because the way the level should project onto the axis
        float spawnPositionZ = CalculateSpawnPositionZ();

        Vector3 chunkSpawnPosition = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        GameObject chunkToSpawn = levelChunks[Random.Range(0, levelChunks.Length)];
        //Puts the level object (prefab) and putting it into the level- chunkparent line puts them all under that
        GameObject newChunk = Instantiate(chunkToSpawn, chunkSpawnPosition, chunkToSpawn.transform.rotation, chunkParent);

        //adds chunks to array
        chunks.Add(newChunk);
    }

    private float CalculateSpawnPositionZ()
    {
        float spawnPositionZ;
        // If first chunk is 0 place down at the start
        if (chunks.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        // else you are not on the starting chunk- add level generation on - 10, 20, 30, etc
        else
        {
            //Getting the last chunk and then adding a new chunk onto the end
            spawnPositionZ = chunks[chunks.Count - 1].transform.position.z + chunkLength;
        }

        return spawnPositionZ;
    }

    private void MoveChunks()
    {
        for (int i = 0; i < chunks.Count;i++)
        {
            //Getting the current chunk in the loop
            GameObject chunk = chunks[i];
            // Drags everything towards the camera- frame rate independent- runs smoothly no matter what machine
            chunk.transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));
            //delete chunks when fully outside camera position
            if (chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            }
        }
    }
}
