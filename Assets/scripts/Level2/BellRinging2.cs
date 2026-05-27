using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using TMPro;


public class BellRinging2 : MonoBehaviour
{
    public bool hasRung;
    public float bellCooldown = 1f;
    private bool canRing = true;
    public bool levelOver = false;
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

    public Level2Points pointsScript;
    public BookMenu bookScript;
    public NewPlayerController newPlayerController;
    public Animator bellAnimator;

    private void Awake()
    {
        if(bookScript == null)
        {
            FindAnyObjectByType<BookMenu>();
            if (bookScript == null)
            {
                Debug.Log("book menu not found for bellscript");
            }
        }
    } 

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
            bellAnimator.SetBool("hasRung", false);
            clientFour.SetActive(false);
            Debug.Log("Client Five Active");
            clientFive.SetActive(true);
            clientFiveActivated = true;
            bookScript.ResetScanList();
        }

        if (clientNumber == 6 && hasRung == false && !clientSixActivated)
        {
            bellAnimator.SetBool("hasRung", false);
            clientFive.SetActive(false);
            Debug.Log("Client Six Active");
            clientSix.SetActive(true);
            clientSixActivated = true;
            bookScript.ResetScanList();

        }

        if (clientNumber == 7 && hasRung == false && !clientSevenActivated)
        {
            bellAnimator.SetBool("hasRung", false);
            clientSix.SetActive(false);
            Debug.Log("Client Seven Active");
            clientSeven.SetActive(true);
            clientSevenActivated = true;
            bookScript.ResetScanList();
        }

        if (clientNumber == 8 && hasRung == false && !clientEightActivated)
        {
            bellAnimator.SetBool("hasRung", false);
            clientSeven.SetActive(false);
            Debug.Log("Client Eight Active");
            clientEight.SetActive(true);
            clientEightActivated = true;
            bookScript.ResetScanList();
        }

        if (clientNumber == 9 && levelOver == false)
        {
            levelOver = true;
            bellAnimator.SetBool("hasRung", false);
            clientEight.SetActive(false);
            Debug.Log("Level Over");
            clientEightActivated = false;
            bookScript.ResetScanList();
            EndLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canRing)
        {
            bookScript.ResetScanList();
            hasRung = true;
            bellAnimator.SetBool("hasRung", true);
            newPlayerController.heldObject.SetActive(false);
            Debug.Log("Ding!");
            StartCoroutine(RingCooldown());
            //add sfx
            // Note: clientNumber is incremented by the client scripts (ClientTwo.EndTransaction, etc.)
            //remove items in playerHands
            if (newPlayerController.heldObject != null)
            {
                newPlayerController.paulaAnimator.SetBool("holdingObject", false); // Reset holding animation state
                newPlayerController.heldObject.transform.SetParent(null); // Detach the held object from the player's hands
                newPlayerController.heldObject = null; // Clear the reference to the held object
            }
            canRing = false;
        }
    }

    private IEnumerator RingCooldown()
    {
        yield return new WaitForSeconds(bellCooldown);
        canRing = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasRung = false;
            bellAnimator.SetBool("hasRung", false);
            Debug.Log("Ding!");
            //add sfx

        }
    }

    public void EndLevel()
    {
        pointsScript.CalculatePoints();
    }

}
