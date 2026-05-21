using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UndoButton : MonoBehaviour
{
    public BookMenu bookScript;

    public string scannedItemName; // Store the name of the last scanned item for undo purposes
    public List<string> scannedItemNames = new List<string>();
    public TextMeshProUGUI scannedListText;
    public BellRinging2 bellScript;

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

        if(bellScript == null)
        {
            bellScript = FindAnyObjectByType<BellRinging2>();
            if (bellScript == null)
            {
                Debug.LogWarning("BellRinging2 not found");
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
        if (bellScript.hasRung == true)
        {
            scannedItemNames.Clear();
            RefreshScannerText();
        }
    }

    public void AddScannedItemName(string itemName)
    {
        scannedItemName = itemName;
        scannedItemNames.Add(itemName);
        RefreshScannerText();
    }

    public void UndoLastScannedItem()
    {
        if (scannedItemNames.Count == 0)
        {
            Debug.Log("Nothing to undo.");
            return;
        }

        scannedItemName = scannedItemNames[scannedItemNames.Count - 1];
        scannedItemNames.RemoveAt(scannedItemNames.Count - 1);
        RefreshScannerText();
        Debug.Log("Undoing scanned item: " + scannedItemName);
    }

    private void RefreshScannerText()
    {
        if (scannedListText == null)
            return;

        scannedListText.text = string.Join("\n", scannedItemNames.ToArray());
        if (scannedItemNames.Count > 0)
        {
            scannedListText.text += "\n";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bookScript.chosenButton = "Undo";
            // scannedItemName is assigned by the ItemController when an item is scanned.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bookScript.chosenButton = null;
        }
    }
}
