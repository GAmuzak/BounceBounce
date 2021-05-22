using System;
using UnityEngine;
using UnityEngine.Events;

public class RotateArrow : MonoBehaviour
{
    [SerializeField] Transform arrowSprite;
    
    public UnityAction StartPullAction;
    public UnityAction EndPullAction;
    
    Vector2 dirn;
    Vector2 initMousePos;
    Vector2 currentMousePos;
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            initMousePos = new Vector2(Screen.width/2.0f,Screen.height/2.0f);
            StartPullAction?.Invoke();
        }

        else if (Input.GetMouseButton(0))
        {
            Cursor.lockState = CursorLockMode.None;
            currentMousePos = Input.mousePosition;
            dirn = (currentMousePos - initMousePos).normalized;
            arrowSprite.right =dirn ;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndPullAction?.Invoke();
        }
        

    }


}
