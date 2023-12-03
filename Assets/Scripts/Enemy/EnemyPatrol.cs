using UnityEngine;

public class EnemyFollowPath : MonoBehaviour
{
    public Transform[] startWaypoints;
    public Transform[] mainWaypoints;
    public float moveSpeed = 5f;

    private Transform[] currentWaypoints;
    private int currentWaypointIndex = 0;

    void Start()
    {
        currentWaypoints = startWaypoints;
    }

    void Update()
    {
        MoveTowardsWaypoint();
    }

    void MoveTowardsWaypoint()
    {
        if (currentWaypointIndex >= 0 && currentWaypointIndex < currentWaypoints.Length)
        {
            Vector3 targetPosition = currentWaypoints[currentWaypointIndex].position;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentWaypointIndex++;
                if (currentWaypoints == startWaypoints && currentWaypointIndex == currentWaypoints.Length)
                {
                    SwitchToMainPath();
                }
                else if (currentWaypoints == mainWaypoints && currentWaypointIndex == currentWaypoints.Length)
                {
                    ReverseMainPath();
                }
            }
        }
    }

    void SwitchToMainPath()
    {
        currentWaypoints = mainWaypoints;
        currentWaypointIndex = 0;
    }

    void ReverseMainPath()
    {
        System.Array.Reverse(mainWaypoints);
        currentWaypointIndex = 1; 
        currentWaypoints = mainWaypoints;
    }
}


