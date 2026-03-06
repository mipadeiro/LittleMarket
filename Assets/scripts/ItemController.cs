using UnityEngine;

public class ItemController : MonoBehaviour
{
    public bool isScanned = false;
    public bool isInCart = false;
    public Item itemData;
    public TMPro.TextMeshProUGUI textItems;

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
        if (collision.gameObject.CompareTag("Scanner"))
        {
            isScanned = true;
            Debug.Log(name + " scanned!");
            
            if (textItems != null && itemData != null)
            {
                textItems.text += itemData.itemName + "\n";
            }
        }

        if (collision.gameObject.CompareTag("Cart"))
        {
            isInCart = true;
            Debug.Log(name + " in cart!");
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
}
