using UnityEngine;

public class RouteVisualisation : MonoBehaviour
{
    [SerializeField] private Transform[] controlPoints;

    private Vector2 gizmosPosition;
    
    private void OnDrawGizmos()
    {
        for(float timeParameterInBezierEquation = 0; timeParameterInBezierEquation <= 1; timeParameterInBezierEquation += 0.05f)
        {
            Vector2[] p = new Vector2[4];
            for (int i = 0; i < 4; i++)
            {
                p[i]=controlPoints[i].position;
            }

            gizmosPosition = BezierPoint(timeParameterInBezierEquation, p);

            Gizmos.DrawSphere(gizmosPosition, 0.25f);
        }

        Gizmos.DrawLine(new Vector2(controlPoints[0].position.x, controlPoints[0].position.y), new Vector2(controlPoints[1].position.x, controlPoints[1].position.y));
        Gizmos.DrawLine(new Vector2(controlPoints[2].position.x, controlPoints[2].position.y), new Vector2(controlPoints[3].position.x, controlPoints[3].position.y));
    }

    public Vector2 BezierPoint(float timeParameterInBezierEquation, Vector2[] p)
    {
        return Mathf.Pow(1 - timeParameterInBezierEquation, 3) * p[0] + 
               3 * Mathf.Pow(1 - timeParameterInBezierEquation, 2) * timeParameterInBezierEquation * p[1] + 
               3 * (1 - timeParameterInBezierEquation) * Mathf.Pow(timeParameterInBezierEquation, 2) * p[2] + 
               Mathf.Pow(timeParameterInBezierEquation, 3) * p[3];
    }
}
