using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnQTE : MonoBehaviour
{
    public GameObject qteDot;
    public RectTransform spawnPoint;

    [Range(0.3f, 2f)]
    public float spawnMin;
    [Range(0.3f, 2f)]
    public float spawnMax;
    private float spawnTime;

    // Testing at start
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            CalculateSpawnTime();
            yield return new WaitForSeconds(spawnTime);
            Instantiate(qteDot, spawnPoint);
        }
    }

    private void CalculateSpawnTime()
    {
        spawnTime = Random.Range(spawnMin, spawnMax);
    }
}
