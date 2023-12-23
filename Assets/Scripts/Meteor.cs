using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float initialSpeed = 2f;
    public float maxSpeed = 5f;
    public float acceleration = 0.05f;

    //Shares variable across all Meteor objects 
    public static float speedMultiplier = 1f;

    public GameObject player; // Reference to the player's spaceship

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private float currentSpeed;
    private Collider2D colliderBox;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colliderBox = GetComponent<Collider2D>();
        currentSpeed = initialSpeed;

        // Randomly choose between straight and targeted movement
        if (Random.Range(0, 2) == 0)
        {
            // Random Straight Movement
            moveDirection = Random.insideUnitCircle.normalized;
        }
        else
        {
            // Targeted Movement
            if (player != null)
            {
                Vector2 targetDirection = (player.transform.position - transform.position).normalized;
                moveDirection = targetDirection;
            }
        }
    }

    void Update()
    {
        //Debug.Log(speedMultiplier);
        // Accelerate the meteor over time
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }

        rb.velocity = moveDirection * currentSpeed * speedMultiplier;

        //Destroy if offscreen
        if (!IsVisibleFromCamera())
        {
            Destroy(gameObject);
        }
    }

    private bool IsVisibleFromCamera()
    {
        var cam = Camera.main;
        var viewportPosition = cam.WorldToViewportPoint(transform.position);
        return viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log(other.gameObject.tag);
        Destroy(gameObject);
    }
}
