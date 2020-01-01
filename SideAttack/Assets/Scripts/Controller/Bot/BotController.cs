using System.Collections;
using UnityEngine;

public class BotController : BaseRogueController, ISpawn
{
    public GameObjectSet bots;
    public GameEvent botDeadEvent;
    public float spawnCount;
    private float activationTime = 1.5f;

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

    public GameObject GetNearestBotBySide(Vector3 target, bool left)
    {
        GameObject botGo = null;
        float minDistance = float.MaxValue;

        for (int i = 0; i < bots.items.Count; i++)
        {
            var go = bots.items[i];

            if (!go.active)
            {
                continue;
            }

            float distance = Mathf.Abs(go.transform.position.x - target.x);

            if ((left && go.transform.position.x < target.x && distance < minDistance) ||
                (!left && go.transform.position.x > target.x && distance < minDistance))
            {
                botGo = go;
                minDistance = distance;
            }
        }

        return botGo;
    }

    public void Kill(GameObject go)
    {
        go.GetComponent<Animator>().Play("Rogue_death_01", -1, 0f);
        StartCoroutine(DeactiveAfterDelay(go));
        botDeadEvent.Raise();
    }

    private IEnumerator DeactiveAfterDelay(GameObject go)
    {
        yield return new WaitForSeconds(activationTime);
        go.SetActive(false);
    }

    public bool AllBotsDead()
    {
        for(int i = 0; i < bots.items.Count; i++) 
        { 
            if (bots.items[i].activeInHierarchy)
            {
                return false;
            }
        }

        return true;
    }
}
