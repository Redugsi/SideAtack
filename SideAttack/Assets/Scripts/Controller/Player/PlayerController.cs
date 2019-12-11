using UnityEngine;

public class PlayerController : BaseRogueController, ISpawn
{

    private GameObject owned;
    private AttackComponent attackComponent;

    void Awake()
    {
        Spawn();
    }

    public void Spawn()
    {
        owned = Instantiate(prefab) as GameObject;
        owned.GetComponent<ArmoireComponent>().armoire = armoire;

        attackComponent = owned.AddComponent<AttackComponent>();
        attackComponent.weapon = armoire.weapon;
    }

    public GameObject GetOwned()
    {
        return owned;
    }

    public float GetAttackRange()
    {
        return attackComponent.weapon.range;
    }

    public void Attack(Vector3 target)
    {
        if (attackComponent == null)
        {
            return;
        }

        attackComponent.Attack(target);
    }
}
