using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using TMPro;


public class BellRinging : MonoBehaviour
{
    public bool hasRung;

    public int clientNumber;
    public GameObject clientOne;
    public GameObject clientTwo;
    public GameObject clientThree;
    public bool clientTwoActivated;
    public bool clientThreeActivated;
    public TMPro.TextMeshProUGUI textItems;
    public NewPlayerController newPlayerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clientNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (clientNumber == 2 && hasRung == false && !clientTwoActivated)
        {
            clientOne.SetActive(false);
            Debug.Log("Client Two Active");
            clientTwo.SetActive(true);
            clientTwoActivated = true;
            textItems.text = "";
        }

        if (clientNumber == 3 && hasRung == false && !clientThreeActivated)
        {
            clientTwo.SetActive(false);
            Debug.Log("Client Three Active");
            clientThree.SetActive(true);
            clientThreeActivated = true;
            textItems.text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasRung = true;
            Debug.Log("Ding!");
            //add sfx
            // Note: clientNumber is incremented by the client scripts (ClientTwo.EndTransaction, etc.)
            //remove items in playerHands
            if (newPlayerController.heldObject != null)
            {
                newPlayerController.heldObject.transform.SetParent(null); // Detach the held object from the player's hands
                newPlayerController.heldObject = null; // Clear the reference to the held object
                newPlayerController.paulaAnimator.SetBool("holdingObject", false); // Reset holding animation state
            }

        }
    }
        
}
