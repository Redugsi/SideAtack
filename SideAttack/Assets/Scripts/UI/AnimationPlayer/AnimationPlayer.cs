using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private Animation animationComp;

    // Start is called before the first frame update
    void Start()
    {
        animationComp = GetComponent<Animation>();
    }

    public void PlayAnimation(string animationName)
    {
        animationComp.Play(animationName);
    }
}
