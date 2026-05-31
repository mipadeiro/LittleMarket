using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using TMPro;


public class BellRinging1 : MonoBehaviour
{
    public bool hasRung;
    public int clientNumber;
    public GameObject clientOne;
    public GameObject clientTwo;
    public GameObject clientThree;
    public bool clientTwoActivated;
    public bool clientThreeActivated;
    public TMPro.TextMeshProUGUI textItems;
    public NewPlayerController1 newPlayerController;
    public Animator bellAnimator;
    public float bellCooldown = 1f;
    public bool canRing = true;
    public BookMenu1 bookScript;
    public Level1Points pointsScript;
    public bool levelOver;

    private void Awake()
    {
        if(bookScript == null)
        {
            bookScript = FindAnyObjectByType<BookMenu1>();
            if(bookScript == null)
            {
                Debug.Log("BookMenu1 not found");
            }
        }
        if(pointsScript == null)
        {
            pointsScript = FindAnyObjectByType<Level1Points>();
            if(pointsScript == null)
            {
                Debug.Log("Level1Points not found");
            }
        }
        if(newPlayerController == null)
        {
            newPlayerController = FindAnyObjectByType<NewPlayerController1>();
            if(newPlayerController == null)
            {
                Debug.Log("playercontroller not found");
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clientNumber = 1;
        hasRung = false;
        levelOver = false;
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
        }

        if (clientNumber == 3 && hasRung == false && !clientThreeActivated)
        {
            clientTwo.SetActive(false);
            Debug.Log("Client Three Active");
            clientThree.SetActive(true);
            clientThreeActivated = true;
        }

        if (clientNumber == 4 && levelOver == false)
        {
            levelOver = true;
            clientThree.SetActive(false);
            Debug.Log("Level Over");
            EndLevel();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canRing)
        {
            hasRung = true;
            bookScript.ResetScanList();
            bellAnimator.SetBool("hasRung", true);
            Debug.Log("Ding!");
            StartCoroutine(RingCooldown());
            //add sfx
            // Note: clientNumber is incremented by the client scripts (ClientTwo.EndTransaction, etc.)
            //remove items in playerHands
            if (newPlayerController.heldObject != null)
            {
                newPlayerController.heldObject.SetActive(false);
                newPlayerController.paulaAnimator.SetBool("holdingObject", false); // Reset holding animation state
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
