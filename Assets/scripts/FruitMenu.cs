using UnityEngine;

public class FruitMenu : MonoBehaviour
{
    public BookMenu bookScript;

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
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bookScript.chosenCategory = "Fruit";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bookScript.chosenCategory = null;
        }
    }
}
