using UnityEngine;

public class FlyPathAgent : MonoBehaviour
{
    public FlyPath flyPath;
    public float flySpeed;

    private int nextIndex = 1;

    void Start() => transform.position = flyPath[0];

    void Update()
    {
        if (flyPath == null) return;

        // ✅ Khi đi hết waypoint → hủy enemy
        if (nextIndex >= flyPath.waypoints.Length)
        {
            Destroy(gameObject);
            return;
        }

        if (transform.position != flyPath[nextIndex])
        {
            FlyToNextWaypoint();
            LookAt(flyPath[nextIndex]);
        }
        else
        {
            nextIndex++;
        }
    }

    private void FlyToNextWaypoint()
        => transform.position = Vector3.MoveTowards(
            transform.position,
            flyPath[nextIndex],
            flySpeed * Time.deltaTime
        );

    private void LookAt(Vector2 destination)
    {
        Vector2 position = transform.position;
        var lookDirection = destination - position;

        if (lookDirection.magnitude < 0.01f) return;

        var angle = Vector2.SignedAngle(Vector2.down, lookDirection);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}