using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField] private Transform[] controlPoints;
    
    private Vector2 gizmosPosition;
    
    private void OnDrawGizmos()
    {
        for(float timeParameterInBezierEquation = 0; timeParameterInBezierEquation <= 1; timeParameterInBezierEquation += 0.05f)
        {
            gizmosPosition = Mathf.Pow(1 - timeParameterInBezierEquation, 3) * controlPoints[0].position + 
                             3 * Mathf.Pow(1 - timeParameterInBezierEquation, 2) * timeParameterInBezierEquation * controlPoints[1].position + 
                             3 * (1 - timeParameterInBezierEquation) * Mathf.Pow(timeParameterInBezierEquation, 2) * controlPoints[2].position + 
                             Mathf.Pow(timeParameterInBezierEquation, 3) * controlPoints[3].position;

            Gizmos.DrawSphere(gizmosPosition, 0.25f);
        }

        Gizmos.DrawLine(new Vector2(controlPoints[0].position.x, controlPoints[0].position.y), new Vector2(controlPoints[1].position.x, controlPoints[1].position.y));
        Gizmos.DrawLine(new Vector2(controlPoints[2].position.x, controlPoints[2].position.y), new Vector2(controlPoints[3].position.x, controlPoints[3].position.y));

    }
}
