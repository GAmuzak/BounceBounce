using System.Collections;
using UnityEngine;
public class ShipMovement : HandleBreaking
{
    [SerializeField] private GameObject brokenShip;
    [SerializeField] private SpriteRenderer mainShip;
    [SerializeField] private Transform[] routes;

    private Vector2 objectPosition;
    private int routeToGo;
    private float tParam;
    private float speedModifier;
    private bool coroutineAllowed;
    private bool shipHit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnHit(brokenShip, mainShip, other);
        if (other.gameObject.CompareTag("Player")) shipHit = true; //need to fix, not sure how
    }

    // Start is called before the first frame update
    void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 0.5f;
        if (routes.Length < 1) return;
        coroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(FollowRoute(routeToGo));
        }
    }

    private IEnumerator FollowRoute(int routeNum)
    {
        if(shipHit) yield break;
        coroutineAllowed = false;

        Vector2 p0 = routes[routeNum].GetChild(0).position;
        Vector2 p1 = routes[routeNum].GetChild(1).position;
        Vector2 p2 = routes[routeNum].GetChild(2).position;
        Vector2 p3 = routes[routeNum].GetChild(3).position;

        while(tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;

            objectPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;

            transform.position = objectPosition;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;
        routeToGo += 1;
        if(routeToGo > routes.Length - 1)
        {
            routeToGo = 0;
        }
        coroutineAllowed = true;

    }
}
