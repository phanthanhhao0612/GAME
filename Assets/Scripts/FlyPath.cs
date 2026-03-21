using UnityEngine;

public class FlyPath : MonoBehaviour
{
    public Waypoint[] waypoints;

    private void Reset()
    {
        waypoints = GetComponentsInChildren<Waypoint>();
    }

    public Vector3 this[int index]
    {
        get
        {
            if (waypoints == null || index < 0 || index >= waypoints.Length)
            {
                Debug.LogWarning("Waypoint index out of range");
                return Vector3.zero;
            }

            return waypoints[index].transform.position;
        }
    }

    private void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Length < 2) return;

        Gizmos.color = Color.green;

        for (int i = 0; i < waypoints.Length; i++)
        {
            Gizmos.DrawSphere(waypoints[i].transform.position, 0.2f);

            if (i < waypoints.Length - 1)
            {
                Gizmos.DrawLine(
                    waypoints[i].transform.position,
                    waypoints[i + 1].transform.position
                );
            }
        }
    }
}