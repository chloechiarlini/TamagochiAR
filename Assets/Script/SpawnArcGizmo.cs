using UnityEngine;

public class SpawnArcGizmo : MonoBehaviour
{
    public float arcRadius = 1.2f;
    public float totalArcAngle = 160f;
    public int numberOfPoints = 5;
    public float heightOffset = 0.05f; 
    private void OnDrawGizmos()
    {
        if (numberOfPoints <= 0)
            return;

        Gizmos.color = Color.magenta;

        Vector3 center = transform.position;
        center.y += heightOffset;   

        for (int i = 0; i < numberOfPoints; i++)
        {
            float angleDeg = (numberOfPoints == 1)
                ? 0f
                : -totalArcAngle / 2f + (totalArcAngle / (numberOfPoints - 1)) * i;

            float angleRad = angleDeg * Mathf.Deg2Rad;

            Vector3 offset = new Vector3(
                Mathf.Sin(angleRad) * arcRadius,
                0f,    // 👈 plus de Y dans l’offset
                Mathf.Cos(angleRad) * arcRadius
            );

            Vector3 position = center + offset;
            Gizmos.DrawSphere(position, 0.5f);
        
        }
    }
}