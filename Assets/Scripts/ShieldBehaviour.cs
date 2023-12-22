using UnityEngine;

public class ShieldBehavior : MonoBehaviour
{
    public GameObject spaceship; // Reference to the spaceship
    public float orbitDistance = 1f; // Fixed distance from the spaceship

    void Update()
    {
        if (spaceship != null)
        {
            // Get the mouse position in world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

            // Calculate the direction from the spaceship to the mouse cursor
            Vector3 direction = (mousePosition - spaceship.transform.position).normalized;

            // Position the shield at a fixed distance from the spaceship in the direction of the mouse cursor
            transform.position = spaceship.transform.position + direction * orbitDistance;

            // Make the shield face the mouse cursor
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90)); // Adjust the angle offset if necessary
        }
    }
}
