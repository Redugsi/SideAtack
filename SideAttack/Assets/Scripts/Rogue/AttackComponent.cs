using System.Collections;
using UnityEngine;

public class AttackComponent : MonoBehaviour, IPlayerAttack
{
    public WeaponObject weapon;

    public void Attack(Vector3 target)
    {
        Debug.Log("Attack " + target);
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
