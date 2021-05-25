using UnityEngine;
public class WallBreak : HandleBreaking
{
    [SerializeField] private GameObject brokenWall;
    [SerializeField] private SpriteRenderer mainWall;
    private void OnCollisionEnter2D(Collision2D other)
    {
        OnHit(brokenWall, mainWall, otherCollision2D:other);
    }
    
}
