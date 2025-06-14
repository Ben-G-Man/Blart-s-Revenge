using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellaSpawner : MonoBehaviour
{
    public GameObject fella;

    public bool dospawn = true;
    public float spawnratePerSecond = 1f;

    private float timeofLastSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dospawn)
        {
            if (Time.time - timeofLastSpawn > (1f / spawnratePerSecond))
            {
                timeofLastSpawn = Time.time;
                Instantiate(fella, transform.position, Quaternion.identity);
            }
        }
    }
}
