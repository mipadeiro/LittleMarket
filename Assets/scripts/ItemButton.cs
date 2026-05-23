using UnityEngine;
using TMPro;

public class ItemButton : MonoBehaviour
{
    public TextMeshProUGUI itemText;
    public BookMenu bookScript;

    private void Awake()
    {
        if (bookScript == null)
        {
            bookScript = FindAnyObjectByType<BookMenu>();
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Notify BookMenu which category is being hovered so the PickUp action can confirm selection
            bookScript.hoveredItem = itemText.text;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Clear hovered state when player leaves the trigger
            if (bookScript != null && bookScript.hoveredItem == itemText.text)
            {
                bookScript.hoveredItem = null;
            }
        }
    }
}
