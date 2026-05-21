using UnityEngine;
using TMPro;

public class ItemController : MonoBehaviour
{
    public bool isScanned = false;
    public bool isInCart = false;
    public bool isWeighed = false;
    public bool correctScan = false;
    public bool correctCart = false;
    public Item itemData;
    public TMPro.TextMeshProUGUI textItems;
    public BookMenu bookScript;

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
            
            if (textItems != null && itemData != null)
            {
                textItems.text += itemData.itemName + "\n";
            }
        }
        
        if (itemData.tags.Contains("Vegetable") || itemData.tags.Contains("Fruit") || itemData.tags.Contains("Fungus"))
        {
            if (collision.gameObject.CompareTag("Scanner"))
            {
                WaitForRegister();
            }
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

    public void WaitForRegister()
    {
        //girl idk figure it out
    }

    public void CheckChoice()
    {
        if (gameObject.CompareTag("Vegetable") || gameObject.CompareTag("Fruit") || gameObject.CompareTag("Fungus"))
        {
            //if (bookScript.chosenButton == itemData.itemName)
            //{
            //    correctScan = true;
            //    Debug.Log(name + " scanned correctly!");
            //    if (textItems != null && itemData != null)
            //    {
            //        textItems.text += itemData.itemName + "\n";
            //    }
            //}
            //else
            //{
            //    correctScan = false;
            //    Debug.Log(name + " scanned incorrectly!");
            //    if (textItems != null && itemData != null)
            //    {
            //        textItems.text += chosenButton + "\n";
            //    }
            //}
        }
    }
}
