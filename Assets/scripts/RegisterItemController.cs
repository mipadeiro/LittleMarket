using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class RegisterItemController : MonoBehaviour
{
    public Item itemData;
    public bool isScanned;
    public bool correctScan;
    public bool InCart;
    public bool correctCart;
    public UndoButton undoScript;
    public BookMenu bookScript;
    public ScannerScript scannerScript;
    
    private void Awake() 
    {
        if (bookScript == null) 
        {
            bookScript = FindAnyObjectByType<BookMenu>();
            if (bookScript == null)
            {
                Debug.LogWarning("BookMenu not found"); 
            } 
        }

        if (undoScript == null)
        {
            undoScript = FindAnyObjectByType<UndoButton>();
            if (undoScript == null)
            {
                Debug.LogWarning("UndoButton not found");
            } 
        }

        if (scannerScript == null)
        {
            scannerScript = FindAnyObjectByType<ScannerScript>();
            if (scannerScript == null)
            {
                Debug.LogWarning("ScannerScript not found");
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isScanned = false;
        correctScan = false;
        InCart = false;
        correctCart = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Scanner"))
        {
            Debug.Log(itemData.itemName + " in scanner");
            
            StartCoroutine(WaitForChoice());
        }

        if (other.CompareTag("Cart"))
        {
            Debug.Log(itemData.itemName + " added to cart");
            InCart = true;
            
            if (itemData.tags.Contains("Cold"))
            {
                correctCart = false;
            }
            else
            {
                correctCart = true;
            }
        }

        if (other.CompareTag("ColdCart"))
        {
            Debug.Log(itemData.itemName + " added to cold cart");
            InCart = true;
            
            if (itemData.tags.Contains("Cold"))
            {
                correctCart = true;
            }
            else
            {
                correctCart = false;
            }
        }
    }

    private IEnumerator WaitForChoice()
    {
        Debug.Log("Waiting for item button press");
        // wait until it's NOT null
        while (bookScript.chosenItem == null)
        {
            yield return null; // wait one frame
        }

        // runs once after condition is met
        CompareScanToChoice(bookScript.chosenItem);
    }

    public void CompareScanToChoice(string chosenItem)
    {
        Debug.Log("Comparing scanned item to button");

        // No items in scanner at all
        if (scannerScript.itemsInScanner.Count == 0)
        {
            bookScript.ShowNoItemError();
            return;
        }

        // 2. We only care that THIS object is currently in scanner
        if (!scannerScript.itemsInScanner.Contains(gameObject))
        {
            return;
        }

        // 3. Now evaluate player's choice independently
        isScanned = true;

        bool isCorrect = (itemData.itemName == chosenItem);

        correctScan = isCorrect;

        bookScript.previousItem = bookScript.chosenItem;
        bookScript.chosenItem = null;

        bookScript.AddItemToList(gameObject);
        bookScript.AddChoiceToList(chosenItem);

        Debug.Log(isCorrect
            ? "Correct scan!"
            : "Incorrect scan (player chose wrong item)");
    }
}
