using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    private Vector3 screenLeft = new Vector3(0, 0, Camera.main.nearClipPlane);
    private Vector3 screenRight = new Vector3(1, 0, Camera.main.nearClipPlane);

    public float spawnOffset = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 p = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Debug.Log(p);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
