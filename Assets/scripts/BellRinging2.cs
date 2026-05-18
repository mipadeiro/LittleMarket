using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using TMPro;


public class BellRinging2 : MonoBehaviour
{
    public bool hasRung;

    public int clientNumber;
    public GameObject clientFour;
    public GameObject clientFive;
    public GameObject clientSix;
    public GameObject clientSeven;
    public GameObject clientEight;
    public bool clientFiveActivated;
    public bool clientSixActivated;
    public bool clientSevenActivated;
    public bool clientEightActivated;
    public TMPro.TextMeshProUGUI textItems;
    public NewPlayerController newPlayerController;
    public Animator bellAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clientNumber = 4;
        hasRung = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (clientNumber == 5 && hasRung == false && !clientFiveActivated)
        {
            clientFour.SetActive(false);
            Debug.Log("Client Five Active");
            clientFive.SetActive(true);
            clientFiveActivated = true;
            textItems.text = "";
        }

        if (clientNumber == 6 && hasRung == false && !clientSixActivated)
        {
            clientFive.SetActive(false);
            Debug.Log("Client Six Active");
            clientSix.SetActive(true);
            clientSixActivated = true;
            textItems.text = "";
        }

        if (clientNumber == 7 && hasRung == false && !clientSevenActivated)
        {
            clientSix.SetActive(false);
            Debug.Log("Client Seven Active");
            clientSeven.SetActive(true);
            clientSevenActivated = true;
            textItems.text = "";
        }

        if (clientNumber == 8 && hasRung == false && !clientEightActivated)
        {
            clientSeven.SetActive(false);
            Debug.Log("Client Eight Active");
            clientEight.SetActive(true);
            clientEightActivated = true;
            textItems.text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasRung = true;
            bellAnimator.SetBool("hasRung", true);
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

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasRung = false;
            bellAnimator.SetBool("hasRung", false);
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
