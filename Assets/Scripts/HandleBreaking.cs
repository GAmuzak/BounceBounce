using System.Collections;
using UnityEngine;

public class HandleBreaking : MonoBehaviour
{
    [SerializeField] protected BreakObject breakObject;

    protected void OnHit(GameObject brokenObject, SpriteRenderer mainObject)
    {
        
        brokenObject.SetActive(true);
        breakObject.OnObjectBreak();
        mainObject.enabled=false;
        StartCoroutine(BreakObject());
    }

    private IEnumerator BreakObject()
    { 
        yield return new WaitForSeconds(1.5f);
        //TODO add tweening code here later
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
