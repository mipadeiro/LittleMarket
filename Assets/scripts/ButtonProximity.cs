using UnityEngine;

public class ButtonProximity : MonoBehaviour
{
    [Tooltip("Name assigned to this button (e.g., \"Fruit\", \"Veggie\", \"Fungus\")")]
    public string buttonName;
    public BookMenu bookMenu;

    void Reset()
    {
        if (bookMenu == null)
            bookMenu = FindObjectOfType<BookMenu>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<NewPlayerController>() != null && bookMenu != null)
        {
            bookMenu.chosenButton = buttonName;
            Debug.Log($"Player entered proximity of button: {buttonName}");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<NewPlayerController>() != null && bookMenu != null)
        {
            if (bookMenu.chosenButton == buttonName)
                bookMenu.chosenButton = "";
            Debug.Log($"Player exited proximity of button: {buttonName}");
        }
    }
}
