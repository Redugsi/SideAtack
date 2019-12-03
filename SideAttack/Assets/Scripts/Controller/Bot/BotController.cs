using UnityEngine;

public class BotController : BaseRogueController, ISpawn
{
    public GameObjectSet bots;
    public float spawnCount;

    void Awake()
    {
        bots.items.Clear();
        SpawnBots();
    }

    public void Spawn()
    {
        GameObject rogue = Instantiate(prefab) as GameObject;
        rogue.GetComponent<ArmoireComponent>().armoire = armoire;
        rogue.SetActive(false);
        bots.Add(rogue);
    }

    private void SpawnBots()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Spawn();
        }
    }
}
