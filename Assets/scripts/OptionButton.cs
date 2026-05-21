using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    public BookMenu bookScript;

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
            if (buttonText != null)
            {
                bookScript.chosenButton = buttonText.text;
            }
            else
            {
                Debug.LogWarning("Button Text is not assigned in OptionButton.");
            }
        }
    }
}
