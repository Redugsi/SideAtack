using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour, ISpawner
{
    public float rangeBetweenSpawnPoints = 10f;
    public float spawnOffset = 100f;
    public GameObjectSet enemies;

    public void Spawn(Transform center, int spawnCount)
    {
        int spawnedCount = 0;
        int index = 0;

        while (spawnedCount < spawnCount)
        {
            var random = Random.Range(0, 2);
            
            if (random == 0)
            {
                var pos = new Vector3((center.position.x + spawnOffset) + (rangeBetweenSpawnPoints * index), center.position.y, center.position.z);
                enemies.items[spawnedCount].transform.position = pos;
                enemies.items[spawnedCount].GetComponent<MovementComponent>().targetTransform = center;
                enemies.items[spawnedCount].SetActive(true);         
                spawnedCount++;
            }

            random = Random.Range(0, 2);

            if (random == 0)
            {
                var pos = new Vector3((center.position.x - spawnOffset) - (rangeBetweenSpawnPoints * index), center.position.y, center.position.z);
                enemies.items[spawnedCount].transform.position = pos;
                enemies.items[spawnedCount].GetComponent<MovementComponent>().targetTransform = center;
                enemies.items[spawnedCount].SetActive(true);
                spawnedCount++;
            }

            index++;
        }
    }
}
