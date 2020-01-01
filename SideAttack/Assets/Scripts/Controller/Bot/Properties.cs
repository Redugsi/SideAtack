using UnityEngine;

public class Properties : MonoBehaviour
{
    public Transform pelvis;
    public bool isDead = true;
    private Animator animator;

    public void SetReady()
    {
        if(pelvis == null) 
        {
            pelvis = transform.Find("Rogue_pelvis_01");
        }

        if(animator == null)
        {
            animator = GetComponent<Animator>();
        }

        gameObject.SetActive(true);
        pelvis.transform.rotation = Quaternion.identity;
        isDead = false;
        animator.Play("Rogue_idle_01", -1, 0f);
    }
}
