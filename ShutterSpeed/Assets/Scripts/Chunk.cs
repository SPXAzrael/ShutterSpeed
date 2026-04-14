using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject fenceHazard;
    [SerializeField] private float[] lanes = { -3f, 0f, 3f };

    void Start()
    {
        SpawnFence();
    }

    void SpawnFence()
    {
        List<int> availableLanes = new List<int>() { 0, 1, 2, };
        int fencesToSpawn = Random.Range(0, lanes.Length);
        for (int i = 0; i < fencesToSpawn; i++) 
        {
            if (availableLanes.Count <= 0) break;

            int randomLane = Random.Range(0, availableLanes.Count);
            int selectedLane = availableLanes[randomLane];
            availableLanes.RemoveAt(randomLane);

            Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fenceHazard, spawnPos, Quaternion.identity, this.transform);
        }
    }
}
