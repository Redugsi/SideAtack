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
        if (botController == null)
        {
            return;
        }

        for (int i = 0; i < botController.bots.items.Count; i++)
        {

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
