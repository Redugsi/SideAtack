using System;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    public event Action OnRightClicked = delegate { };
    public event Action OnLeftClicked = delegate { };
   
    void Update()
    {
        InputUpdateOnEditor();
    }

    private void InputUpdateOnEditor()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnLeftClicked();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            OnRightClicked();
        }
    }

    private void InputUpdateOnMobile()
    {
        int touchCounts = Input.touchCount;
        if (touchCounts > 0)
        {
            var touch = Input.GetTouch(touchCounts - 1);
            Debug.Log(touch.position.x);
            if (touch.position.x > Screen.width / 2)
            {
                OnRightClicked();
            }
            else
            {
                OnLeftClicked();
            }
        }
    }
}
