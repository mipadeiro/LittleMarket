using UnityEngine;

public class ItemController : MonoBehaviour
{
    public bool isScanned;
    public bool correctScan;

    public Item itemData;
    public BookMenu bookScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Scanner"))
        {
            //bookScript.currentScannerItem = gameObject;
            Debug.Log("Scanner targeting: " + name);
        }
    }

    public void ExecuteScan(string chosenItem)
    {
        if (isScanned)
            return;

        isScanned = true;

        Debug.Log($"SCAN: chosen={chosenItem} actual={itemData.itemName}");

        if (!string.IsNullOrEmpty(chosenItem) &&
            chosenItem.Trim() == itemData.itemName.Trim())
        {
            correctScan = true;
            Debug.Log("CORRECT SCAN");
        }
        else
        {
            correctScan = false;
            Debug.Log("WRONG SCAN");
        }
    }
}