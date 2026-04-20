using UnityEngine;

public class FirstItem : MonoBehaviour
{
    public bool isScanned = false;
    public bool isInCart = false;
    public Item itemData;
    public TMPro.TextMeshProUGUI textItems;
    private Level1Tutorial tutorial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tutorial = FindFirstObjectByType<Level1Tutorial>();
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

            if (tutorial != null)
            {
                tutorial.OnItemScanned();
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