using UnityEngine;

public class MountainSlope : MonoBehaviour
{
    public float slipThreshold = 30f; // The angle at which the Player starts slipping
    public float climbThreshold = 30f; // The angle at which the Player can start climbing
    public LayerMask groundLayer; // The layer that represents the ground
    public float slipForceMultiplier = 5f; // The force multiplier for slipping
    public float climbForceMultiplier = 5f; // The force multiplier for climbing
    public float maxSpeed = 10f; // The maximum speed of the Player

    private GameObject Player; // A reference to the Player GameObject
    private Rigidbody rb;
    private bool hasWoodenSkin = false; // A flag to determine if the Player has wooden skin
    private PowerUpTags powerUpTags; // A reference to the PowerUpTags component on the Player GameObject

    void OnTriggerEnter(Collider other)
    {
        // Check if the Player has entered the trigger collider
        if (other.gameObject.CompareTag("Player"))
        {
            Player = other.gameObject;
            rb = Player.GetComponent<Rigidbody>();
            powerUpTags = Player.GetComponent<PowerUpTags>();
			hasWoodenSkin = powerUpTags.HasTag("Wood");
        }
    }

    void FixedUpdate()
    {
        // Check if the Player has been set
        if (Player != null)
        {
            // Cast a ray downwards to check if the Player is on the ground
            RaycastHit hit;
            if (Physics.Raycast(Player.transform.position, -Player.transform.up, out hit, 1.0f, groundLayer))
            {
                // Get the angle between the Player's up vector and the normal of the ground
                float angle = Vector3.Angle(Player.transform.up, hit.normal);

                // If the angle is greater than the slip threshold and the Player doesn't have wooden skin, make them slip
                if (angle > slipThreshold && !hasWoodenSkin)
                {
                    // Calculate the slip force and apply it to the Player
                    Vector3 slipForce = -hit.normal * slipForceMultiplier * rb.mass * Physics.gravity.magnitude;
                    rb.AddForce(slipForce, ForceMode.Force);
                }

                // If the angle is greater than the climb threshold and the Player has wooden skin, make them climb
                if (angle > climbThreshold && hasWoodenSkin)
                {
                    // Calculate the climb force and apply it to the Player
                    Vector3 climbForce = hit.normal * climbForceMultiplier * rb.mass * Physics.gravity.magnitude;
                    rb.AddForce(climbForce, ForceMode.Force);

                    // Limit the Player's speed to the maximum speed
                    if (rb.velocity.magnitude > maxSpeed)
                    {
                        rb.velocity = rb.velocity.normalized * maxSpeed;
                    }
                }
            }
        }
    }

}
