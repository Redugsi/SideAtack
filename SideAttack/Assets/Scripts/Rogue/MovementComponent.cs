using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public Transform targetTransform;
    public float speed = 1f;
    
    void Update()
    {
        if(targetTransform == null)
        {
            return;
        }

        float distance = targetTransform.position.x - transform.position.x;

        if(Mathf.Abs(distance) < Constants.ROGUE_WIDTH_IN_UNIT)
        {
            return;
        }

        float step = speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, distance > 0 ? 0 : 180, 0);
        transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, step);
    }
}
