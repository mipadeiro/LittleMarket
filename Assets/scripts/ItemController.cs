using UnityEngine;
using TMPro;
using UnityEditor;

public class ItemController : MonoBehaviour
{
    public bool isScanned = false;
    public bool isInCart = false;
    public bool correctScan = false;
    public bool correctCart = false;
    public Item itemData;
    public TMPro.TextMeshProUGUI textItems;
    public BookMenu bookScript;
    public UndoButton undoScript;

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
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Scanner") && itemData.tags.Contains("Basic"))
        {
            isScanned = true;
            correctScan = true;
            Debug.Log(name + " scanned!");
            
            if (itemData != null && undoScript != null)
            {
                undoScript.AddScannedItemName(itemData.itemName);
                if (undoScript.scannedListText == null && textItems != null)
                {
                    undoScript.scannedListText = textItems;
                }
            }
        }
        
        if (collision.gameObject.CompareTag("Scanner") && itemData != null && (itemData.tags.Contains("Vegetable") || itemData.tags.Contains("Fruit") || itemData.tags.Contains("Fungus")))
        {
            CheckChoice();
        }

        if (collision.gameObject.CompareTag("Cart") && itemData.tags.Contains("Basic"))
        {
            isInCart = true;
            correctCart = true;
            Debug.Log(name + " in cart!");
        }

        if (collision.gameObject.CompareTag("Cart") && itemData.tags.Contains("Cold"))
        {
            isInCart = true;
            correctCart = false;
            Debug.Log(name + " in wrong cart!");
        }

        if (collision.gameObject.CompareTag("ColdCart") && itemData.tags.Contains("Basic"))
        {
            isInCart = true;
            correctCart = false;
            Debug.Log(name + " in wrong cart!");
        }

        if (collision.gameObject.CompareTag("ColdCart") && itemData.tags.Contains("Cold"))
        {
            isInCart = true;
            correctCart = true;
            Debug.Log(name + " in cold cart!");
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Cart"))
        {
            isInCart = false;
            Debug.Log(name + " removed from cart!");
        }
    }

    public void CheckChoice()
    {
        if (itemData == null)
        {
            Debug.LogWarning("ItemController.CheckChoice called with no itemData.");
            return;
        }

        if (bookScript == null)
        {
            Debug.LogWarning("ItemController.CheckChoice called with no BookMenu reference.");
            return;
        }

        if (string.IsNullOrEmpty(bookScript.chosenButton))
        {
            Debug.Log("No chosenButton selected while scanning " + itemData.itemName);
            return;
        }

        if (itemData.tags.Contains("Vegetable") || itemData.tags.Contains("Fruit") || itemData.tags.Contains("Fungus"))
        {
            isScanned = true;
            if (bookScript.chosenButton == itemData.itemName)
            {
                correctScan = true;
                Debug.Log(name + " scanned correctly! chosenButton=" + bookScript.chosenButton);
            }
            else
            {
                correctScan = false;
                Debug.Log(name + " scanned incorrectly! chosenButton=" + bookScript.chosenButton + ", itemName=" + itemData.itemName);
            }

            if (textItems != null)
            {
                textItems.text += bookScript.chosenButton + "\n";
            }
        }
    }
}
