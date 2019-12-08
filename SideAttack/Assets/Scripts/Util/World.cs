using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private BotController botController;

    [SerializeField]
    private SpawnerComponent spawner;

    private void Start()
    {
        botController.SpawnBots();
        spawner.Spawn(playerController.GetOwned().transform, 4);
    }

    public Transform GetPlayerTransform()
    {
        if (playerController == null || playerController.GetOwned() == null)
        {
            Debug.Log("NULL");
            return null;
        }

        return playerController.GetOwned().transform;
    }
}
