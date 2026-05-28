using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using TMPro;


public class BellRinging3 : MonoBehaviour
{
    public bool hasRung;
    public float bellCooldown = 1f;
    private bool canRing = true;
    public bool levelOver = false;
    public int clientNumber;

    public GameObject clientNine;
    public GameObject clientTen;
    public GameObject clientEleven;
    public GameObject clientTwelve;
    public GameObject clientThirteen;
    public GameObject clientFourteen;
    public bool clientNineActivated;
    public bool clientTenActivated;
    public bool clientElevenActivated;
    public bool clientTwelveActivated;
    public bool clientThirteenActivated;
    public bool clientFourteenActivated;


    public Level3Points pointsScript;
    public BookMenu3 bookScript;
    public NewPlayerController newPlayerController;
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
    } 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clientNumber = 9;
        hasRung = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (clientNumber == 10 && hasRung == false && !clientTenActivated)
        {
            bellAnimator.SetBool("hasRung", false);
            clientNine.SetActive(false);
            Debug.Log("Client Five Active");
            clientTen.SetActive(true);
            clientTenActivated = true;
            bookScript.ResetScanList();
        }

        if (clientNumber == 11 && hasRung == false && !clientElevenActivated)
        {
            bellAnimator.SetBool("hasRung", false);
            clientTen.SetActive(false);
            Debug.Log("Client Six Active");
            clientEleven.SetActive(true);
            clientElevenActivated = true;
            bookScript.ResetScanList();

        }

        if (clientNumber == 12 && hasRung == false && !clientTwelveActivated)
        {
            bellAnimator.SetBool("hasRung", false);
            clientEleven.SetActive(false);
            Debug.Log("Client Seven Active");
            clientTwelve.SetActive(true);
            clientTwelveActivated = true;
            bookScript.ResetScanList();
        }

        if (clientNumber == 13 && hasRung == false && !clientThirteenActivated)
        {
            bellAnimator.SetBool("hasRung", false);
            clientTwelve.SetActive(false);
            Debug.Log("Client Eight Active");
            clientThirteen.SetActive(true);
            clientThirteenActivated = true;
            bookScript.ResetScanList();
        }

        if (clientNumber == 14 && hasRung == false && !clientFourteenActivated)
        {
            bellAnimator.SetBool("hasRung", false);
            clientThirteen.SetActive(false);
            Debug.Log("Client Eight Active");
            clientFourteen.SetActive(true);
            clientFourteenActivated = true;
            bookScript.ResetScanList();
        }

        if (clientNumber == 15 && levelOver == false)
        {
            levelOver = true;
            bellAnimator.SetBool("hasRung", false);
            clientFourteen.SetActive(false);
            Debug.Log("Level Over");
            clientFourteenActivated = false;
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
