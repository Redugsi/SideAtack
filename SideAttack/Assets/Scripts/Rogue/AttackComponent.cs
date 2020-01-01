using System.Collections;
using UnityEngine;

public class AttackComponent : MonoBehaviour, IPlayerAttack
{
    public WeaponObject weapon;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("weaponSpeed", 1 / weapon.speed);
    }

    public void Attack(Vector3 target)
    {
        transform.rotation = Quaternion.Euler(0, target.x > transform.position.x ? 0 : 180, 0);
        animator.Play("Rogue_attack_02", -1, 0f);
        StartCoroutine(Move(target));
    }

    private IEnumerator Move(Vector3 target)
    {
        float elapsedTime = 0f;

        while (elapsedTime <= weapon.speed)
        {
            transform.position = Vector3.Lerp(transform.position, target, elapsedTime / weapon.speed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
