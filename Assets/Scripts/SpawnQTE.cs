using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnQTE : MonoBehaviour
{
    public GameObject qteDot;
    public Transform spawnPoint;
    public float spawnTime;

    // Testing at start
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(qteDot, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
