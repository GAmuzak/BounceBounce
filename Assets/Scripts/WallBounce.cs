using System;
using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.Serialization;

public class WallBounce : MonoBehaviour
{
    [SerializeField] private GameObject brokenWall;
    [SerializeField] private SpriteRenderer mainWall;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        brokenWall.SetActive(true);
        ShipMovement.BreakObjectAction?.Invoke();
        mainWall.enabled=false;
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
