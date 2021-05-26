using UnityEngine;

public class BashZone : MonoBehaviour
{
    public bool CanBash { get; private set; }


    [SerializeField] private SpriteRenderer planetSprite;
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite bashReady;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        planetSprite.sprite = bashReady;
        CanBash=true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        planetSprite.sprite = normalSprite;
        CanBash=false;
    }
}
