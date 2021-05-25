using UnityEngine;

public class BreakObject : MonoBehaviour
{
    [SerializeField] private float blastForce;
    [SerializeField] private Transform playerLocation;

    private void OnEnable()
    {
        ShipMovement.BreakObjectAction += OnObjectBreak;
    }

    private void OnDisable()
    {
        ShipMovement.BreakObjectAction -= OnObjectBreak;
    }

    private void OnObjectBreak()
    {
        ObjectExplode();
    }

    private void ObjectExplode()
    {
        foreach (Transform child in transform)
        {
            Vector2 shootDirection = child.transform.position-playerLocation.position;
            child.GetComponent<Rigidbody2D>().AddForce(shootDirection.normalized*blastForce, ForceMode2D.Impulse);
        }
    }
}
