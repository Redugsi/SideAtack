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

        float step = speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, targetTransform.position.x > transform.position.x ? 0 : 180, 0);
        transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, step);
    }
}
