using UnityEngine;

public class BotController : BaseRogueController, ISpawn
{
    public GameObjectSet bots;
    public float spawnCount;

    void Awake()
    {
        bots.items.Clear();
    }

    public void Spawn()
    {
        GameObject rogue = Instantiate(prefab) as GameObject;
        rogue.AddComponent<MovementComponent>();
        rogue.GetComponent<ArmoireComponent>().armoire = armoire;
        rogue.SetActive(false);
        bots.Add(rogue);
    }

    public void SpawnBots()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Spawn();
        }
    }
}
