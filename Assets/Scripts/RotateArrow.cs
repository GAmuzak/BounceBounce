using UnityEngine;
using UnityEngine.Events;

public class RotateArrow : MonoBehaviour
{
    [SerializeField] GameObject arrowSprite;
    
    public UnityAction StartPullAction;
    public UnityAction<Vector2> EndPullAction;
    
    Vector2 dirn;
    Vector2 initMousePos;
    Vector2 currentMousePos;
    bool arrowRender;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        Cursor.visible = false;
        spriteRenderer=arrowSprite.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            initMousePos = new Vector2(Screen.width/2.0f,Screen.height/2.0f);
            StartPullAction?.Invoke();
            spriteRenderer.enabled = true;
        }

        else if (Input.GetMouseButton(0))
        {
            Cursor.lockState = CursorLockMode.None;
            currentMousePos = Input.mousePosition;
            dirn = (currentMousePos - initMousePos).normalized;
            arrowSprite.transform.right =dirn ;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndPullAction?.Invoke(dirn);
            spriteRenderer.enabled = false;
        }

        if (Cursor.visible) Cursor.visible = false;


    }


}
