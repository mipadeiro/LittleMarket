using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;

public class BookMenu1 : MonoBehaviour
{
    //choosing and hovering
    public string hoveredCategory;
    public string chosenCategory;
    public string previousCategory;

    //scannedItemsLists
    public List<GameObject> scannedItems = new List<GameObject>();
    public List<string> scannedItemsNames = new List<string>();

    //book menus
    public GameObject bookMainMenu;

    //book buttons
    public GameObject undoButton;
    public TextMeshProUGUI itemsText;

    //other scripts
    public BellRinging1 bellScript;


    void Start()
    {
        bookMainMenu.SetActive(true);
    }



    public void OnPickUp(InputAction.CallbackContext context)
    {
        Debug.Log("PickUp action performed: " + context.performed);

        if (!context.performed)
        {
            return;
        }

        if (context.performed)
        {
            // Perform selection based on the currently hovered button
            if (!string.IsNullOrEmpty(hoveredCategory))
            {
                chosenCategory = hoveredCategory;
                SelectCategory(chosenCategory);
            }
        }
    }

    // Public helper to perform a category selection directly (used by UI or tests)
    public void SelectCategory(string category)
    {
        switch (category)
        {
            case "Undo":
                Debug.Log("Undo button pressed");
                UndoLastItem();
                previousCategory = chosenCategory;
                chosenCategory = null;
                hoveredCategory = null;
                break;
            default:
                // No valid hovered category
                break;
        }
    }

    //each basic item adds its gameobject and itemName to scannedItems and scannedItemsNames to show up in itemsText
    public void AddBasicScanToList(GameObject basicObject)
    {
        scannedItems.Add(basicObject);

        var basic = basicObject.GetComponent<BasicItemController1>();
        var first = basicObject.GetComponent<FirstItem>();

        string itemName = null;

        if (basic != null)
        {
            itemName = basic.itemData.itemName;
        }
        else if (first != null)
        {
            itemName = first.itemData.itemName;
        }
        else
        {
            Debug.LogError("No valid item component found on " + basicObject.name);
            return;
        }

        scannedItemsNames.Add(itemName);

        Debug.Log("Added scanned item: " + itemName);

        RefreshItemsText();
    }

    private void RefreshItemsText()
    {
        itemsText.text = string.Join("\n", scannedItemsNames);

        foreach (string item in scannedItemsNames)
        {
            Debug.Log($"[{item}]");
        }
    }

    public void UndoLastItem()
    {
        if (scannedItems.Count == 0 || scannedItemsNames.Count == 0)
        return;

        int lastIndex = Mathf.Min(scannedItems.Count, scannedItemsNames.Count) - 1;

        GameObject obj = scannedItems[lastIndex];

        scannedItems.RemoveAt(lastIndex);
        scannedItemsNames.RemoveAt(lastIndex);

        if (obj != null)
        {
            var basic = obj.GetComponent<BasicItemController1>();
            var first = obj.GetComponent<FirstItem>();

            if (basic != null)
            {
                basic.isScanned = false;
                basic.correctScan = false;
            }
            else if (first != null)
            {
                first.isScanned = false;
                first.correctScan = false;
            }
        }

        RefreshItemsText();
    }

    public void ResetScanList()
    {
        if (bellScript != null && bellScript.hasRung)
        {
            scannedItems.Clear();
            scannedItemsNames.Clear();
            itemsText.text = "";
        }
        
    }
}