using UnityEngine;

public class CameraFollowComponent : MonoBehaviour
{

    public Transform target;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }
        transform.position = Vector3.SmoothDamp(transform.position, 
        new Vector3(target.position.x, transform.position.y, transform.position.z), 
        ref velocity, smoothTime);
    }
}
