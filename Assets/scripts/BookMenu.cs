using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;

public class BookMenu : MonoBehaviour
{
    //choosing and hovering
    public string hoveredCategory;
    public string chosenCategory;
    public string previousCategory;
    public string hoveredItem;
    public string chosenItem;
    public string previousItem;

    //scannedItemsLists
    public List<GameObject> scannedItems = new List<GameObject>();
    public List<string> scannedItemsNames = new List<string>();

    //book menus
    public GameObject bookMainMenu;
    public GameObject bookFruitMenu;
    public GameObject bookVeggieMenu;
    public GameObject bookFungusMenu;

    //book buttons
    public GameObject cancelButton;
    public GameObject undoButton;
    public TextMeshProUGUI itemsText;
    public GameObject noItemMessage;

    //other scripts
    public BellRinging2 bellScript;


    void Start()
    {
        bookMainMenu.SetActive(true);
        bookFruitMenu.SetActive(false);
        bookVeggieMenu.SetActive(false);
        bookFungusMenu.SetActive(false);
        cancelButton.SetActive(false);
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
            
            if (!string.IsNullOrEmpty(hoveredItem))
            {
                chosenItem = hoveredItem;
                SelectItem(chosenItem);
            }
        }
    }

    // Public helper to perform a category selection directly (used by UI or tests)
    public void SelectCategory(string category)
    {
        switch (category)
        {
            case "Cancel":
                Debug.Log("Cancel button pressed");
                bookMainMenu.SetActive(true);
                bookFruitMenu.SetActive(false);
                bookVeggieMenu.SetActive(false);
                bookFungusMenu.SetActive(false);
                cancelButton.SetActive(false);
                hoveredCategory = null;
                previousCategory = chosenCategory;
                chosenCategory = null;
                break;
            case "Fruit":
                Debug.Log("Fruit button pressed");
                bookMainMenu.SetActive(false);
                bookFruitMenu.SetActive(true);
                bookVeggieMenu.SetActive(false);
                bookFungusMenu.SetActive(false);
                cancelButton.SetActive(true);
                previousCategory = chosenCategory;
                chosenCategory = null;
                hoveredCategory = null;

                break;
            case "Vegetable":
                Debug.Log("Vegetable button pressed");
                bookMainMenu.SetActive(false);
                bookFruitMenu.SetActive(false);
                bookVeggieMenu.SetActive(true);
                bookFungusMenu.SetActive(false);
                cancelButton.SetActive(true);
                previousCategory = chosenCategory;
                chosenCategory = null;
                hoveredCategory = null;

                break;
            case "Fungus":
                Debug.Log("Fungus button pressed");
                bookMainMenu.SetActive(false);
                bookFruitMenu.SetActive(false);
                bookVeggieMenu.SetActive(false);
                bookFungusMenu.SetActive(true);
                cancelButton.SetActive(true);
                previousCategory = chosenCategory;
                chosenCategory = null;
                hoveredCategory = null;
                break;
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

    public void SelectItem(string item)
    {
        switch (item)
        {
            //fruit items
            case "Apple":
                Debug.Log("Apple button chosen");
                bookFruitMenu.SetActive(false);
                bookMainMenu.SetActive(true);
                hoveredItem = null;
                break;
            //vegetable items
            case "Blue Cabbage":
                Debug.Log("Blue Cabbage button chosen");
                bookVeggieMenu.SetActive(false);
                bookMainMenu.SetActive(true);
                hoveredItem = null;
                break;
            //fungus items
            case "Sea Grapes":
                Debug.Log("Sea Grapes button chosen");
                bookFungusMenu.SetActive(false);
                bookMainMenu.SetActive(true);
                hoveredItem = null;
                break;
        }
        
    }

    public void ShowNoItemError()
    {
        Debug.Log("no item in scanner");
        noItemMessage.SetActive(true);
        StartCoroutine(HideNoItemMessage());
    }

        private IEnumerator HideNoItemMessage()
        {
            yield return new WaitForSeconds(3f);
            noItemMessage.SetActive(false);
        }

    //each basic item adds its gameobject and itemName to scannedItems and scannedItemsNames to show up in itemsText
    public void AddBasicScanToList(GameObject basicObject)
    {
        var basic = basicObject.GetComponent<BasicItemController>();
        if (basic == null || basic.itemData == null) 
        {
            return;
        }

        scannedItems.Add(basicObject);
        scannedItemsNames.Add(basic.itemData.itemName);

        Debug.Log("Added scanned item: " + basic.itemData.itemName);

        RefreshItemsText();
    }

    //each itemcontroller adds its gameobject to scannedItems list
    public void AddItemToList(GameObject scannedObject)
    {
        // allow duplicate scans by design
        scannedItems.Add(scannedObject);

        Debug.Log("Added scanned item: " + scannedObject);
    }
    
    //each registered item adds whatever itemChosen is to scannedItemsNames to show up in itemsText
    public void AddChoiceToList(string chosenItem)
    {
        if (!string.IsNullOrWhiteSpace(chosenItem))
        {
            scannedItemsNames.Add(chosenItem.Trim());
            RefreshItemsText();

            Debug.Log("Added scanned item name: " + chosenItem);
        }  
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
            var basic = obj.GetComponent<BasicItemController>();
            var register = obj.GetComponent<RegisterItemController>();

            if (basic != null && !scannedItems.Contains(obj))
            {
                basic.isScanned = false;
                basic.correctScan = false;
            }
            else if (register != null && !scannedItems.Contains(obj))
            {
                register.isScanned = false;
                register.correctScan = false;
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