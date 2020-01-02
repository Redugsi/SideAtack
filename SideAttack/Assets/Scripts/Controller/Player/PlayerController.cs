using UnityEngine;

public class PlayerController : BaseRogueController, ISpawn
{

    private GameObject owned;
    private AttackComponent attackComponent;
    private Animator animator;

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

        animator = owned.GetComponent<Animator>();

    }

    public GameObject GetOwned()
    {
        return owned;
    }

    public float GetAttackRange()
    {
        return attackComponent.weapon.range;
    }

    public void Attack(Vector3 target, bool miss = false)
    {
        if (attackComponent == null)
        {
            return;
        }
        animator.SetBool("miss", miss);
        attackComponent.Attack(target);
    }

    public void Die()
    {
        animator.Play("Rogue_death_02", -1, 0f);
    }
}
