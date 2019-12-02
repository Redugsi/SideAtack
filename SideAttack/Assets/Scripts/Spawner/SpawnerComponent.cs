using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour, ISpawner
{
    public float rangeBetweenSpawnPoints = 10f;
    public float spawnOffset = 100f;
    public GameObject roguePrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Vector3 p = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        //Debug.Log(p);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(Vector3 center)
    {
        Debug.Log("Spawn Called " + center);
        int rogueCount = 12;
        int spawnedCount = 0;
        int index = 0;

        while (spawnedCount < rogueCount)
        {
            var random = Random.Range(0, 2);
            
            if (random == 0)
            {
                Instantiate(roguePrefab, new Vector3((center.x + spawnOffset) + (rangeBetweenSpawnPoints * index), center.y, center.z), Quaternion.identity);
                spawnedCount++;
            }

            random = Random.Range(0, 2);

            if (random == 0)
            {
                Instantiate(roguePrefab, new Vector3((center.x - spawnOffset) - (rangeBetweenSpawnPoints * index), center.y, center.z), Quaternion.identity);
                spawnedCount++;
            }

            index++;
        }
    }
}
