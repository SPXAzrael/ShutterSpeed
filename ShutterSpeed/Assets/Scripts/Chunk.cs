using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject fenceHazard;
    [SerializeField] private GameObject[] powerup;
    [SerializeField] private GameObject coinPrefab;

    [SerializeField] private float[] lanes = { -3f, 0f, 3f };

    [SerializeField] float pickupSpawnChance = 0.3f;
    [SerializeField] float pickupSpawnCoin = 0.5f;
    [SerializeField] float coinSeperationValue = 2f;

    List<int> availableLanes = new List<int>() { 0, 1, 2 };
    void Start()
    {
        SpawnFences();
        SpawnPowerup();
        SpawnCoin();
    }

    // Spawns between 0 - 2 fence obstacles every chunk
    void SpawnFences()
    {
        int fencesToSpawn = Random.Range(0, lanes.Length);
        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0) break;
            int selectedLane = GetSelectedLane();

            Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fenceHazard, spawnPos, Quaternion.identity, this.transform);
        }
    }

    void SpawnPowerup()
    {
        if (Random.value > pickupSpawnChance || availableLanes.Count <= 0) return;

        int selectedLane = GetSelectedLane();

        Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        GameObject powerupToSpawn = powerup[Random.Range(0, powerup.Length)];
        Instantiate(powerupToSpawn, spawnPos, Quaternion.identity, this.transform);
    }
    void SpawnCoin()
    {
        if (Random.value > pickupSpawnCoin || availableLanes.Count <= 0) return;

        int selectedLane = GetSelectedLane();

        int maxCoinsToSpawn = 6;
        int coinsToSpawn = Random.Range(0, maxCoinsToSpawn);

        float chunkZPos = transform.position.z + (coinSeperationValue * 2f);

        for (int i = 0; i < coinsToSpawn; i++)
        {
            float coinSpawnZ = chunkZPos - (i * coinSeperationValue);
            Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, coinSpawnZ);
            Instantiate(coinPrefab, spawnPos, Quaternion.identity, this.transform);
        }

    }

    private int GetSelectedLane()
    {
        int randomLane = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLane];
        availableLanes.RemoveAt(randomLane);
        return selectedLane;
    }


}