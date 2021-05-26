using System.Collections;
using UnityEngine;
public class ShipMovement : BreakHandlerMonoBehaviour
{
    [SerializeField] private GameObject brokenShip;
    [SerializeField] private SpriteRenderer mainShip;
    [SerializeField] private Transform[] routes;
    [SerializeField] private RouteVisualization routeVisualization;

    private Vector2 objectPosition=Vector2.zero;
    private int routeToGo=0;
    private float timeParameterInBezierEquation=0f;
    private float speedModifier=0f;
    private bool shipMovementCoroutineAllowed=false;
    private bool shipHit=false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        OnHit(brokenShip, mainShip);
        shipHit = true; 
    }

    private void Start()
    {
        routeToGo = 0;
        timeParameterInBezierEquation = 0f;
        speedModifier = 0.5f;
        if (routes.Length < 1) return;
        shipMovementCoroutineAllowed = true;
    }

    private void Update()
    {
        if (shipMovementCoroutineAllowed)
        {
            StartCoroutine(FollowRoute(routeToGo));
        }
    }

    private IEnumerator FollowRoute(int routeNum)
    {
        shipMovementCoroutineAllowed = false;

        Vector2[] p = new Vector2[4];
        for (int i = 0; i < 4; i++)
        {
            p[i]=routes[routeNum].GetChild(i).position;
        }

        while(timeParameterInBezierEquation < 1)
        {
            if(shipHit) yield break;

            timeParameterInBezierEquation += Time.deltaTime * speedModifier;

            objectPosition = routeVisualization.BezierPoint(timeParameterInBezierEquation,p);

            transform.position = objectPosition;
            yield return new WaitForEndOfFrame();
        }

        timeParameterInBezierEquation = 0f;
        routeToGo = (routeToGo + 1) % routes.Length;
        shipMovementCoroutineAllowed = true;
    }
}
