using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using TMPro;


public class BellRinging4 : MonoBehaviour
{
    public bool hasRung;
    public float bellCooldown = 1f;
    private bool canRing = true;
    public bool levelOver = false;
    public int clientNumber;

    public GameObject clientFifteen;
    public GameObject clientSixteen;
    public GameObject clientSeventeen;
    public bool clientFifteenActivated;
    public bool clientSixteenActivated;
    public bool clientSeventeenActivated;


    public Level4Points pointsScript;
    public BookMenu3 bookScript;
    public NewPlayerController3 newPlayerController;
    public Animator bellAnimator;

    private void Awake()
    {
        if(bookScript == null)
        {
            FindAnyObjectByType<BookMenu3>();
            if (bookScript == null)
            {
                Debug.Log("book menu not found for bellscript");
            }
        }
        if(pointsScript == null)
        {
            FindAnyObjectByType<Level3Points>();
            if (pointsScript == null)
            {
                Debug.Log("book menu not found for bellscript");
            }
        }
        if(newPlayerController == null)
        {
            newPlayerController = FindAnyObjectByType<NewPlayerController3>();
            if(newPlayerController == null)
            {
                Debug.Log("playercontroller not found");
            }
        }
    } 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clientNumber = 15;
        hasRung = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (clientNumber == 16 && hasRung == false && !clientSixteenActivated)
        {
            bellAnimator.SetBool("hasRung", false);
            clientFifteen.GetComponent<ClientFifteenScript>().EndTransaction();
            Debug.Log("Client Ten Active");
            clientSixteen.GetComponent<ClientSixteenScript>().StartTransaction();
            clientSixteenActivated = true;
            bookScript.ResetScanList();
        }

        if (clientNumber == 17 && hasRung == false && !clientSeventeenActivated)
        {
            bellAnimator.SetBool("hasRung", false);
            clientSixteen.GetComponent<ClientSixteenScript>().EndTransaction();
            Debug.Log("Client Eleven Active");
            clientSeventeen.GetComponent<ClientSeventeenScript>().StartTransaction();
            clientSeventeenActivated = true;
            bookScript.ResetScanList();

        }

        if (clientNumber == 18 && levelOver == false)
        {
            levelOver = true;
            bellAnimator.SetBool("hasRung", false);
            clientSeventeen.GetComponent<ClientSeventeenScript>().EndTransaction();
            Debug.Log("Level Over");
            clientSeventeenActivated = false;
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
            clientNumber = clientNumber + 1;
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
