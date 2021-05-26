using UnityEngine;
using UnityEngine.Events;

public class DashDirection : MonoBehaviour
{
    public static UnityAction StartPullAction;
    public static UnityAction<Vector2> EndPullAction;
    
    [SerializeField] private GameObject arrowSprite;
    [SerializeField] private BashZone bashZone;

    private readonly Vector2 centerOfScreen = new Vector2(Screen.width*0.5f,Screen.height*0.5f);
    private Vector2 direction;
    private Vector2 currentMousePos;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        Cursor.visible = false;
        spriteRenderer=arrowSprite.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
        #if UNITY_EDITOR
        Cursor.visible = false;
        #endif
        if (bashZone.CanBash) Bash();
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
            direction = (currentMousePos - centerOfScreen).normalized;
            arrowSprite.transform.right =direction ;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndPullAction?.Invoke(direction);
            spriteRenderer.enabled = false;
        }
    }
}
