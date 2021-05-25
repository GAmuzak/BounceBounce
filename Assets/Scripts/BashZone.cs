using UnityEngine;

public class BashZone : MonoBehaviour
{
    public static bool CanBash;

    [SerializeField] private SpriteRenderer planetSprite;
    [SerializeField] private Sprite normalState;
    [SerializeField] private Sprite bashReady;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        planetSprite.sprite = bashReady;
        CanBash=true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        planetSprite.sprite = normalState;
        CanBash=false;
    }
}
