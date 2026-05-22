using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class BookMenu : MonoBehaviour
{
    //choosing and hovering
    public string hoveredCategory;
    public string chosenCategory;
    public string hoveredItem;
    public string chosenItem;

    //scannedItemsList
    public List<string> scannedItems = new List<string>();

    //book menus
    public GameObject bookMainMenu;
    public GameObject bookFruitMenu;
    public GameObject bookVeggieMenu;
    public GameObject bookFungusMenu;

    //book buttons
    public GameObject cancelButton;
    public GameObject undoButton;
    public TextMeshProUGUI itemsText;

    //other scripts
    public BellRinging2 bellScript;


    void Start()
    {
        bookMainMenu.SetActive(true);
        bookFruitMenu.SetActive(false);
        bookVeggieMenu.SetActive(false);
        bookFungusMenu.SetActive(false);
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
                SelectCategory(hoveredCategory);
            }
            
            if (!string.IsNullOrEmpty(hoveredItem))
            {
                SelectItem(hoveredItem);
            }
        }
    }

    // Public helper to perform a category selection directly (used by UI or tests)
    public void SelectCategory(string category)
    {
        switch (category)
        {
            case "Cancel":
                chosenCategory = "Cancel";
                Debug.Log("Cancel button pressed");
                bookMainMenu.SetActive(true);
                bookFruitMenu.SetActive(false);
                bookVeggieMenu.SetActive(false);
                bookFungusMenu.SetActive(false);
                cancelButton.SetActive(false);
                break;
            case "Fruit":
                chosenCategory = "Fruit";
                Debug.Log("Fruit button pressed");
                bookMainMenu.SetActive(false);
                bookFruitMenu.SetActive(true);
                bookVeggieMenu.SetActive(false);
                bookFungusMenu.SetActive(false);
                cancelButton.SetActive(true);
                break;
            case "Vegetable":
                chosenCategory = "Vegetable";
                Debug.Log("Vegetable button pressed");
                bookMainMenu.SetActive(false);
                bookFruitMenu.SetActive(false);
                bookVeggieMenu.SetActive(true);
                bookFungusMenu.SetActive(false);
                cancelButton.SetActive(true);
                break;
            case "Fungus":
                chosenCategory = "Fungus";
                Debug.Log("Fungus button pressed");
                bookMainMenu.SetActive(false);
                bookFruitMenu.SetActive(false);
                bookVeggieMenu.SetActive(false);
                bookFungusMenu.SetActive(true);
                cancelButton.SetActive(true);
                break;
            case "Undo":
                chosenCategory = "Undo";
                Debug.Log("Undo button pressed");
                UndoLastItem();
                break;
            default:
                // No valid hovered category
                break;
        }
    }

    public void SelectItem(string item)
    {
        //fruit items

        //vegetable items

        //fungus items
    }

    public void AddItemToList(string itemName)
    {
        if (string.IsNullOrEmpty(itemName))
        {
            Debug.LogWarning("BookMenu.AddItemToList called with null or empty itemName");
            return;
        }

        // allow duplicate scans by design
        scannedItems.Add(itemName);
        // update itemsText after scanning
        itemsText.text += itemName + "\n";
        Debug.Log("BookMenu: added scanned item: " + itemName + " (scannedItems count=" + scannedItems.Count + ")");
    }

    public void UndoLastItem()
    {
        if (scannedItems.Count > 0)
        {
            scannedItems.RemoveAt(scannedItems.Count - 1);
            Debug.Log("BookMenu.UndoLastItem called (remaining count=" + scannedItems.Count + ")\n" + System.Environment.StackTrace);
            // update itemsText after undo
            itemsText.text = "";
            foreach (string item in scannedItems)
            {
                itemsText.text += item + "\n";
            }
        }
    }

    public void ResetScanList()
    {
        Debug.Log("BookMenu.ResetScanList called (hasRung=" + (bellScript != null ? bellScript.hasRung.ToString() : "<no bellScript>") + ")\n" + System.Environment.StackTrace);
        if (bellScript != null && bellScript.hasRung)
        {
            scannedItems.Clear();
            itemsText.text = "";
        }
        
    }
}