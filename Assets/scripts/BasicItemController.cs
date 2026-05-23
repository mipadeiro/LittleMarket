using UnityEngine;
using System.Collections.Generic;

public class BasicItemController : MonoBehaviour
{
    public Item itemData;
    public bool isScanned;
    public bool correctScan;
    public bool inCart;
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
        inCart = false;
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
            Debug.Log(itemData.itemName + " scanned");
            isScanned = true;
            correctScan = true;
            bookScript.AddBasicScanToList(gameObject);
        }

        if (other.CompareTag("Cart"))
        {
            Debug.Log(itemData.itemName + " added to cart");
            inCart = true;
            
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
            inCart = true;
            
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

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Scanner"))
        {
            Debug.Log(itemData.itemName + " removed from scanner");
            scannerScript.RemoveItem(gameObject);
        }

        if (other.CompareTag("Cart"))
        {
            Debug.Log(itemData.itemName + " removed from cart");
            inCart = false;
            correctCart = false;
        }

        if (other.CompareTag("ColdCart"))
        {
            Debug.Log(itemData.itemName + " removed from cold cart");
            inCart = false;
            correctCart = false;
        }
    }
}
