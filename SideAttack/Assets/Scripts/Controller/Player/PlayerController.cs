using UnityEngine;

public class PlayerController : BaseRogueController, ISpawn
{

    private GameObject owned;

    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        owned = Instantiate(prefab) as GameObject;
        owned.GetComponent<ArmoireComponent>().armoire = armoire;

        var attackComponent = owned.AddComponent<AttackComponent>();
        attackComponent.weapon = armoire.weapon;
    }

    public GameObject GetOwned()
    {
        return owned;
    }
}
