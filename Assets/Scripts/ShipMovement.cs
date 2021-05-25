using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ShipMovement : MonoBehaviour
{
    public static UnityAction BreakObjectAction;

    [SerializeField] private GameObject brokenShip;
    [SerializeField] private SpriteRenderer mainShip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        brokenShip.SetActive(true);
        BreakObjectAction?.Invoke();
        mainShip.enabled=false;
        StartCoroutine(TrashShip());
    }

     private IEnumerator TrashShip()
     { 
         yield return new WaitForSeconds(1.5f);
         //add tweening code here later
         yield return new WaitForSeconds(0.5f);
         Destroy(gameObject);
    }
}
