using UnityEngine;

public interface ISpawner
{
    void Spawn(Transform center, int spawnCount, float speed);
}
