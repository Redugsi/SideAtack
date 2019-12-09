using UnityEngine;

public class AttackComponent : MonoBehaviour, IPlayerAttack
{

    public WeaponObject weapon;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {

    }

    public void AttackLeft()
    {
        Debug.Log("Left Attack");
    }

    public void AttackRight()
    {
        Debug.Log("Right Attack");
    }
}
