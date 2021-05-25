using UnityEngine;
public class WallBreak : HandleBreaking
{
    [SerializeField] private GameObject brokenWall;
    [SerializeField] private SpriteRenderer mainWall;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        OnHit(brokenWall, mainWall);
    }
    
}
