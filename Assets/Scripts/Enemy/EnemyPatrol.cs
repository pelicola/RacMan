using UnityEngine;

public class EnemyFollowPath : MonoBehaviour
{
    public Transform[] startWaypoints;
    public Transform[] mainWaypoints;
    public float moveSpeed = 5f;
    public float startDelay = 2f; // Adjust the delay as needed

    private Transform[] currentWaypoints;
    private int currentWaypointIndex = 0;

    public SpriteRenderer spriteRenderer;
    public Sprite cop;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = cop; 

        if (startWaypoints != null && startWaypoints.Length > 0)
        {
            currentWaypoints = startWaypoints;
        }
        else
        {
            Debug.LogError("Start waypoints array is null or empty. Check your waypoints array.");
        }
    }

    void StartFollowing()
    {
        currentWaypoints = startWaypoints;
    }

    void Update()
    {
        MoveTowardsWaypoint();
    }

    void MoveTowardsWaypoint()
    {
        if (currentWaypoints != null && currentWaypointIndex >= 0 && currentWaypointIndex < currentWaypoints.Length)
        {
            if (currentWaypoints[currentWaypointIndex] != null) // Check if the current waypoint is not null
            {
                Vector3 targetPosition = currentWaypoints[currentWaypointIndex].position;
                targetPosition.z = transform.position.z; // Set the Z-coordinate to be the same as the current position

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
            else
            {
                Debug.LogWarning("currentWaypoints[currentWaypointIndex] is null. Check your waypoints array.");
            }
        }
        else
        {
            Debug.LogWarning("currentWaypoints array is null or currentWaypointIndex is out of bounds.");
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
