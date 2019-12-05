using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour, ISpawner
{
    public float rangeBetweenSpawnPoints = 10f;
    public float spawnOffset = 100f;
    public GameObjectSet enemies;

    public void Spawn(Vector3 center, int spawnCount)
    {
        int spawnedCount = 0;
        int index = 0;

        while (spawnedCount < spawnCount)
        {
            var random = Random.Range(0, 2);
            
            if (random == 0)
            {
                var pos = new Vector3((center.x + spawnOffset) + (rangeBetweenSpawnPoints * index), center.y, center.z);
                         
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
