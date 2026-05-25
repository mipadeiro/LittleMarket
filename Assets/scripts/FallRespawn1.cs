using UnityEngine;

public class FallRespawn1 : MonoBehaviour
{

    public float threshold = -5;
    public Vector3 respawnPosition = new Vector3(0f, -1f, 0f);
    private NewPlayerController1 playerController;
    private bool hasFallen = false;

    void Start()
    {
        playerController = GetComponent<NewPlayerController1>();

        if (playerController == null)
        {
            Debug.LogWarning("PlayerController not found on this object!");
        }
    }

    void FixedUpdate()
    {
        if (transform.position.y < threshold && !hasFallen)
        {
            hasFallen = true;
            
            if (playerController != null)
            {
                playerController.fallenPlayer++;
                playerController.StartCoroutine(playerController.FallStun());
            }

            // Respawn
            transform.position = respawnPosition;
        }

        if (transform.position.y >= threshold)
        {
            hasFallen = false;
        }
    }
}
