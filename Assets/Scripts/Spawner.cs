using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject shipA;

    private float timeSinceLastSpawn = 0f;
    private float spawnInterval = 7f;
    // Start is called before the first frame update
    void Start()
    {
        Spawn(shipA);
        Spawn(shipA);
    }

    private void FixedUpdate()
    {
        timeSinceLastSpawn += Time.fixedDeltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            Spawn(shipA);
            timeSinceLastSpawn = 0;
            if (spawnInterval > 2.5f)
            {
                spawnInterval -= .03f;
            }
        }
    }

    private void Spawn(GameObject spawnObj)
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        Instantiate(spawnObj, spawnPoint.position, Quaternion.identity);
        float coinFlip = Random.Range(0, 1);
        if (coinFlip > .7f)
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            Instantiate(spawnObj, spawnPoint.position, Quaternion.identity);
        }
    }
}
