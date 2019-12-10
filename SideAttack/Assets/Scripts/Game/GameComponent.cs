using UnityEngine;

[RequireComponent(typeof(InputComponent))]
public class GameComponent : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private BotController botController;

    [SerializeField]
    private SpawnerComponent spawner;

    public ScoreObject score;

    private void Start()
    {
        botController.SpawnBots();
        SpawnWave();
    }

    private void Update()
    {
        CheckEnemyCollision();
    }

    private void CheckEnemyCollision()
    {
        if (botController == null || playerController == null || playerController.GetOwned() == null)
        {
            return;
        }

        var playerRogueXPosition = playerController.GetOwned().transform.position.x;

        foreach (var bot in botController.bots.items)
        {
            if (!bot.active)
            {
                continue;
            }

            Debug.Log(bot.GetInstanceID() + "");

            var distance = Mathf.Abs(playerRogueXPosition - bot.transform.position.x);

            if(distance <= Constants.ROGUE_COLLISION_WIDTH_IN_UNIT)
            {
                Debug.Log("Player Get Killed");
            }
        }

    }

    public void SpawnWave()
    {
        spawner.Spawn(playerController.GetOwned().transform, GameHelper.GetEnemyCount(score.wave), GameHelper.GetSpeed(score.wave));
    }

    public Transform GetPlayerTransform()
    {
        if (playerController == null || playerController.GetOwned() == null)
        {
            return null;
        }

        return playerController.GetOwned().transform;
    }

}
