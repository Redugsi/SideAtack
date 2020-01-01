using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public Transform targetTransform;
    public float speed = 1f;

    private Animator animator;
    private Properties properties;

    private void Start()
    {
        animator = GetComponent<Animator>();
        properties = GetComponent<Properties>();
    }

    void Update()
    {
        if(targetTransform == null || properties.isDead)
        {
            animator.SetFloat("runSpeed", 0);
            return;
        }

        float distance = targetTransform.position.x - transform.position.x;

        if(Mathf.Abs(distance) < Constants.ROGUE_WIDTH_IN_UNIT)
        {
            animator.SetFloat("runSpeed", 0);
            return;
        }

        animator.SetFloat("runSpeed", 1);
        float step = speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, distance > 0 ? 0 : 180, 0);
        transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, step);
    }
}
