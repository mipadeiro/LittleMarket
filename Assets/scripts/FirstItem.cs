using UnityEngine;

public class FirstItem : MonoBehaviour
{
    public Item itemData;
    public bool isScanned;
    public bool correctScan;
    public bool inCart;
    public bool correctCart;
    public UndoButton undoScript;
    public BookMenu1 bookScript;
    public ScannerScript1 scannerScript;
    private Level1Tutorial tutorial;

    private void Awake() 
    {
        if (bookScript == null) 
        {
            bookScript = FindAnyObjectByType<BookMenu1>();
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
            scannerScript = FindAnyObjectByType<ScannerScript1>();
            if (scannerScript == null)
            {
                Debug.LogWarning("ScannerScript not found");
            }
        }

        if (tutorial == null)
        {
            tutorial = FindFirstObjectByType<Level1Tutorial>();
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

            if (tutorial != null)
            {
                tutorial.OnItemScanned();
            }
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