using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public NewPlayerController playerScript; // Reference to the player controller script to update grounded state

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            playerScript.isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            playerScript.isGrounded = false;
        }
    }

    

}