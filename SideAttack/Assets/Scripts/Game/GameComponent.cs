using System.Collections;
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

    public float newWaveDelay = 2;

    private void Awake()
    {
        var inputComponent = GetComponent<InputComponent>();
        inputComponent.OnLeftClicked += OnLeftClicked;
        inputComponent.OnRightClicked += OnRightClicked;

        score.score = 0;
        score.wave = 1;
    }

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

            var distance = Mathf.Abs(playerRogueXPosition - bot.transform.position.x);

            if(distance <= Constants.ROGUE_COLLISION_WIDTH_IN_UNIT)
            {
                //Debug.Log("Player Get Killed");
                Time.timeScale = 0;
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

    #region Input

    private void OnLeftClicked()
    {
        PlayerAttack(true);
    }

    private void OnRightClicked()
    {
        PlayerAttack(false);
    }

    private void PlayerAttack(bool left)
    {
        if (playerController == null || botController == null)
        {
            return;
        }


        var attackRange = playerController.GetAttackRange();
        var attackPos = new Vector3(left ? playerController.GetOwned().transform.position.x - (attackRange + Constants.ROGUE_COLLISION_WIDTH_IN_UNIT)
            : playerController.GetOwned().transform.position.x + (attackRange + Constants.ROGUE_COLLISION_WIDTH_IN_UNIT),
            playerController.GetOwned().transform.position.y,
                playerController.GetOwned().transform.position.z);

        var nearestBot = botController.GetNearestBotBySide(playerController.GetOwned().transform.position, left);

        if (nearestBot != null)
        {
            bool isContain = (left && (attackPos.x <= (nearestBot.transform.position.x + Constants.ROGUE_COLLISION_WIDTH_IN_UNIT))) ||
            (!left && (attackPos.x >= nearestBot.transform.position.x - Constants.ROGUE_COLLISION_WIDTH_IN_UNIT));

            if (isContain)
            {
                botController.Kill(nearestBot);
                attackPos = new Vector3(left ? nearestBot.transform.position.x + Constants.ROGUE_COLLISION_WIDTH_IN_UNIT
                    : nearestBot.transform.position.x - Constants.ROGUE_COLLISION_WIDTH_IN_UNIT,
                    nearestBot.transform.position.y, nearestBot.transform.position.z);
            }
        }

        playerController.Attack(attackPos);
    }
    #endregion

    private void KillBot(GameObject bot)
    { 
        if(bot == null || botController == null)
        {
            return;
        }

        botController.Kill(bot);
    }

    public void OnBotDead()
    {
        score.score += score.wave;
        score.wave += 1;

        if(botController.AllBotsDead())
        {
            StartCoroutine(NewWave());
        } else 
        { 
        
        }
    }

    IEnumerator NewWave()
    {
        Debug.Log("New wave called");
        yield return new WaitForSeconds(newWaveDelay);
        SpawnWave();
    }
}
