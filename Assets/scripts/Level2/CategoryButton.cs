using UnityEngine;
using TMPro;

public class CategoryButton : MonoBehaviour
{
    public TextMeshProUGUI categoryText;
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
            bookScript.hoveredCategory = categoryText.text;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Clear hovered state when player leaves the trigger
            if (bookScript != null && bookScript.hoveredCategory == categoryText.text)
            {
                bookScript.hoveredCategory = null;
            }
        }
    }
}
