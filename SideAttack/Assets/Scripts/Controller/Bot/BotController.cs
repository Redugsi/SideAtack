using System.Collections;
using UnityEngine;

public class BotController : BaseRogueController, ISpawn
{
    public BotRuntimeSet bots;
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
        var property = rogue.AddComponent<Properties>();
        rogue.SetActive(false);
        bots.Add(property);
    }

    public void SpawnBots()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Spawn();
        }
    }

    public Properties GetNearestBotBySide(Vector3 target, bool left)
    {
        Properties botGo = null;
        float minDistance = float.MaxValue;

        for (int i = 0; i < bots.items.Count; i++)
        {
            var bot = bots.items[i];
            var go = bot.gameObject;

            if (!go.activeInHierarchy || bot.isDead)
            {
                continue;
            }

            float distance = Mathf.Abs(go.transform.position.x - target.x);

            if ((left && go.transform.position.x < target.x && distance < minDistance) ||
                (!left && go.transform.position.x > target.x && distance < minDistance))
            {
                botGo = bot;
                minDistance = distance;
            }
        }

        return botGo;
    }

    public void Kill(Properties bot)
    {
        bot.isDead = true;
        bot.GetComponent<Animator>().Play("Rogue_death_01", -1, 0f);
        StartCoroutine(SendToFakePosition(bot.gameObject));
        StartCoroutine(DeactiveAfterDelay(bot.gameObject));
        botDeadEvent.Raise();
    }

    private IEnumerator DeactiveAfterDelay(GameObject go)
    {
        yield return new WaitForSeconds(activationTime);
        go.SetActive(false);
    }

    private IEnumerator SendToFakePosition(GameObject go)
    {
        yield return new WaitForSeconds(1f);
        go.transform.position = new Vector3(9000f, go.transform.position.y, go.transform.position.z);
    }

    public bool AllBotsDead()
    {
        for(int i = 0; i < bots.items.Count; i++) 
        { 
            if (!bots.items[i].isDead)
            {
                return false;
            }
        }

        return true;
    }
}
