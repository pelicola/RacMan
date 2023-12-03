using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player; 
    public float moveSpeed = 5f; 
    public float stoppingDistance = 1f;
    public Transform[] StartPath; 

    private Rigidbody2D rb;
    private int currentWaypoint = 0;
    private bool isChasing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; 
    }

    void Update()
    {
        if (player != null)
        {
            if (isChasing)
            {
                ChasePlayer();
            }
            else
            {
                Patrol();
            }
        }
    }

    void Patrol()
    {
        Vector3 direction = StartPath[currentWaypoint].position - transform.position;
        direction.Normalize();
        rb.velocity = direction * moveSpeed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 180f * Time.deltaTime);

        if (Vector3.Distance(transform.position, StartPath[currentWaypoint].position) <= 0.1f)
        {
            currentWaypoint++;

            if (currentWaypoint >= StartPath.Length)
            {
                currentWaypoint = 0;
                isChasing = true;
            }
        }
    }

    void ChasePlayer()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        rb.velocity = direction * moveSpeed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= stoppingDistance)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other){ 
        if(other.transform.tag == "Player"){
            Player._currentLives--;
        }
    } 

    private void OnTriggerExit2D(Collider2D other){ 
        if(other.transform.tag == "Bullet"){
            Destroy(gameObject); 
        }
    } 
}