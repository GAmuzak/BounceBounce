using System;
using UnityEngine;
using UnityEngine.Events;

public class DashDirection : MonoBehaviour
{
    [SerializeField] private GameObject arrowSprite;
    
    public static UnityAction StartPullAction;
    public static UnityAction<Vector2> EndPullAction;

    
    [SerializeField] private BashZone bz;

    private Vector2 direction;
    private readonly Vector2 initMousePos = new Vector2(Screen.width*0.5f,Screen.height*0.5f);
    private Vector2 currentMousePos;
    public SpriteRenderer spriteRenderer;
    private bool canBash=false;

    private void OnEnable()
    {
        bz.InBashZone += CanBash;
    }

    

    private void Start()
    {
        Cursor.visible = false;
        spriteRenderer=arrowSprite.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
        if (Cursor.visible) Cursor.visible = false;
        if (!canBash) {
            spriteRenderer.enabled = false;
            Time.timeScale = 1f;
            return;
        }
        Bash();
        


    }

    private void Bash()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            
            StartPullAction?.Invoke();
            spriteRenderer.enabled = true;
        }

        else if (Input.GetMouseButton(0))
        {
            Cursor.lockState = CursorLockMode.None;
            currentMousePos = Input.mousePosition;
            direction = (currentMousePos - initMousePos).normalized;
            arrowSprite.transform.right =direction ;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndPullAction?.Invoke(direction);
            spriteRenderer.enabled = false;
        }
    }
    
    private void CanBash(bool cb)
    {
        canBash = cb;
    }


}
