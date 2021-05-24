using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class BashZone : MonoBehaviour
{
    public UnityAction<bool> InBashZone;

    [SerializeField] private SpriteRenderer planetSprite;
    [SerializeField] private Sprite normalState;
    [SerializeField] private Sprite bashReady;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        planetSprite.sprite = bashReady;
        InBashZone?.Invoke(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        planetSprite.sprite = normalState;
        InBashZone?.Invoke(false);
    }
}
