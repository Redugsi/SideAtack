using UnityEngine;

public class SpawnerComponent : MonoBehaviour, ISpawner
{
    public float rangeBetweenSpawnPoints = 10f;
    public float spawnOffset = 100f;
    public BotRuntimeSet enemies;

    public void Spawn(Transform center, int spawnCount, float speed)
    {
        int spawnedCount = 0;
        int index = 0;
        spawnCount = Mathf.Clamp(spawnCount, 1, enemies.items.Count);

        while (spawnedCount < spawnCount)
        {
            var random = Random.Range(0, 2);
            
            if (random == 0)
            {
                var pos = new Vector3((center.position.x + spawnOffset) + (rangeBetweenSpawnPoints * index), center.position.y, center.position.z);
                enemies.items[spawnedCount].transform.position = pos;
                enemies.items[spawnedCount].SetReady();
                enemies.items[spawnedCount].GetComponent<MovementComponent>().targetTransform = center;
                enemies.items[spawnedCount].GetComponent<MovementComponent>().speed = speed;
                spawnedCount++;
            }

            random = Random.Range(0, 2);

            if (random == 0)
            {
                var pos = new Vector3((center.position.x - spawnOffset) - (rangeBetweenSpawnPoints * index), center.position.y, center.position.z);
                enemies.items[spawnedCount].transform.position = pos;
                enemies.items[spawnedCount].SetReady();
                enemies.items[spawnedCount].GetComponent<MovementComponent>().targetTransform = center;
                enemies.items[spawnedCount].GetComponent<MovementComponent>().speed = speed;
                spawnedCount++;
            }

            index++;
        }
    }
}
