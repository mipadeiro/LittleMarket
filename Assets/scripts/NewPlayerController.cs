using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerController : MonoBehaviour
{
    public float speed = 3f;
    public float jumpHeight = 1.75f;
    public float gravity = -9.81f; // Gravity acceleration (negative for downward pull)
    public float rotationSpeed = 10f; // How quickly the player rotates towards movement direction
    public float pickupRange = 0.5f; // how close the player needs to be to

    // References to components and variables for movement
    public CharacterController controller; // Unity's CharacterController for collision-aware movement
    public Vector3 moveInput; // Stores horizontal/vertical input as a 3D vector (x, 0, z)
    public Vector3 velocity; // Tracks vertical velocity for jumping and gravity
    public Transform playerHands; //location to place held items
    public GameObject heldObject = null; // reference to currently held item

    public bool pickedUpThisStep;
    public bool droppedThisStep;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Input Action callback for movement (WASD or left joystick)
    public void Move(InputAction.CallbackContext context)
    {
        // Read the 2D input value (e.g., Vector2(-1, 0) for left) and convert to Vector3
        moveInput = context.ReadValue<Vector2>();
        // Debug log to show input values in the console
        Debug.Log("Move Input: " + moveInput);
    }

    // Input Action callback for jumping (spacebar or south button on controller)
    public void Jump(InputAction.CallbackContext context)
    {
        // Debug log showing if the jump action was performed and if the player is grounded
        Debug.Log($"Jumping {context.performed} - Is Grounded: {controller.isGrounded}");
        // Only jump if the action was performed (pressed) and the player is on the ground
        if (context.performed && controller.isGrounded)
        {
            // Log confirmation
            Debug.Log("Should be jumping");
            // Calculate initial upward velocity using kinematic equation: v = sqrt(2 * h * g)
            // (jumpHeight is positive, gravity is negative, so -2f * gravity makes it positive)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void PickUp(InputAction.CallbackContext context)
    {
        if (context.performed && heldObject == null) //only picks up if hands are empty
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickupRange);
            GameObject closestPickup = null;
            float closestDistance = Mathf.Infinity;

            foreach (Collider collider in hitColliders)
            {
                if (collider.CompareTag("Pickup"))
                {
                    float distance = Vector3.Distance(transform.position, collider.transform.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestPickup = collider.gameObject;
                    }
                }
                
            }

            if (closestPickup != null)
            {
                heldObject = closestPickup;
                heldObject.transform.SetParent(playerHands); //make child object of hands
                heldObject.transform.localPosition = Vector3.zero; //center on hands, do i want this?
                heldObject.transform.localRotation = Quaternion.identity; //reset rotation
                Rigidbody rb = heldObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true; // Disable physics while held
                    Debug.Log("Picked up: " + heldObject.name);
                }
                Collider collider = heldObject.GetComponent<Collider>();
                if (collider != null)
                {
                    collider.enabled = false; // Disable collider to prevent interference
                }
                pickedUpThisStep = true;
            }
        }
    }

    public void Drop(InputAction.CallbackContext context)
    {
        if (context.performed && heldObject != null) //only drops if holding something
        {
            heldObject.transform.SetParent(null); // detach from hands
            Rigidbody rb = heldObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false; // Re-enable physics
            }
            Collider collider = heldObject.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = true; // Re-enable collider
            }
            Debug.Log("Dropped: " + heldObject.name);
            heldObject = null; // Clear reference to held object
            droppedThisStep = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Create a movement vector from input (x from left/right, z from up/down, y=0 for horizontal)
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        //Move the character horizontally based on input, speed, and time delta for frame-rate independence
        controller.Move(move * speed * Time.deltaTime);

        //Rotate player towards movement direction
        if (moveInput.magnitude > 0) // Only rotate if there's input
        {
            // Calculate the direction to face (convert 2D input to 3D world direction)
            Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            // Smoothly interpolate towards target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Apply gravity to vertical velocity each frame
        velocity.y += gravity * Time.deltaTime;
        // Move the character vertically (handles jumping and falling)
        controller.Move(velocity * Time.deltaTime);
    }

    //LateUpdate is called after all Update calls, ensuring held object syncs after player movement
    void LateUpdate()
    {
        //If holding an object, manually update its position to follow playerHands exactly
        if (heldObject != null && playerHands != null)
        {
            heldObject.transform.position = playerHands.position;
            heldObject.transform.rotation = playerHands.rotation;
        }
    }
}
