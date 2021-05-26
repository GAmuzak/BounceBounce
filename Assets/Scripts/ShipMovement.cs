using System.Collections;
using UnityEngine;
public class ShipMovement : HandleBreaking
{
    [SerializeField] private GameObject brokenShip;
    [SerializeField] private SpriteRenderer mainShip;
    [SerializeField] private Transform[] routes;

    private Vector2 objectPosition;
    private int routeToGo;
    private float timeParameterInBezierEquation;
    private float speedModifier;
    private bool shipMovementCoroutineAllowed;
    private bool shipHit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        OnHit(brokenShip, mainShip);
        shipHit = true; 
    }

    void Start()
    {
        routeToGo = 0;
        timeParameterInBezierEquation = 0f;
        speedModifier = 0.5f;
        if (routes.Length < 1) return;
        shipMovementCoroutineAllowed = true;
    }

    void Update()
    {
        if (shipMovementCoroutineAllowed)
        {
            StartCoroutine(FollowRoute(routeToGo));
        }
    }

    private IEnumerator FollowRoute(int routeNum)
    {
        shipMovementCoroutineAllowed = false;
        
        Vector2 p0 = routes[routeNum].GetChild(0).position;
        Vector2 p1 = routes[routeNum].GetChild(1).position;
        Vector2 p2 = routes[routeNum].GetChild(2).position;
        Vector2 p3 = routes[routeNum].GetChild(3).position;

        while(timeParameterInBezierEquation < 1)
        {
            if(shipHit) yield break;

            timeParameterInBezierEquation += Time.deltaTime * speedModifier;

            objectPosition = Mathf.Pow(1 - timeParameterInBezierEquation, 3) * p0 +
                             3 * Mathf.Pow(1 - timeParameterInBezierEquation, 2) * timeParameterInBezierEquation * p1 + 
                             3 * (1 - timeParameterInBezierEquation) * Mathf.Pow(timeParameterInBezierEquation, 2) * p2 
                             + Mathf.Pow(timeParameterInBezierEquation, 3) * p3;

            transform.position = objectPosition;
            yield return new WaitForEndOfFrame();
        }

        timeParameterInBezierEquation = 0f;
        routeToGo += 1;
        if(routeToGo > routes.Length - 1)
        {
            routeToGo = 0;
        }
        shipMovementCoroutineAllowed = true;

    }
}
