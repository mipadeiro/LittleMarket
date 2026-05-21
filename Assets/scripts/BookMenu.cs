using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class BookMenu : MonoBehaviour
{
    public NewPlayerController playerScript;
    public UndoButton undoScript;
    public string chosenButton;
    public GameObject bookCanvas;
    public GameObject bookMainMenu;
    public GameObject bookFruitMenu;
    public GameObject bookVeggieMenu;
    public GameObject bookFungusMenu;
    public GameObject cancelButton;

    private void Awake()
    {
        if (undoScript == null)
        {
            undoScript = FindAnyObjectByType<UndoButton>();
            if (undoScript == null)
            {
                Debug.LogWarning("UndoButton not found");
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bookCanvas.SetActive(true);
        bookMainMenu.SetActive(true);
        bookFruitMenu.SetActive(false);
        bookVeggieMenu.SetActive(false);
        bookFungusMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPickUp(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        if (chosenButton == "Fruit")
        {
            bookMainMenu.SetActive(false);
            bookFruitMenu.SetActive(true);
        }
        else if (chosenButton == "Veggie")
        {
            bookMainMenu.SetActive(false);
            bookVeggieMenu.SetActive(true);
        }
        else if (chosenButton == "Fungus")
        {
            bookMainMenu.SetActive(false);
            bookFungusMenu.SetActive(true);
        }
        else if (chosenButton == "Undo")
        {
            if (undoScript != null)
            {
                undoScript.UndoLastScannedItem();
            }
            else
            {
                Debug.LogWarning("UndoButton is not assigned in BookMenu.");
            }
        }
        else if (chosenButton == "Apple")
        {
            bookMainMenu.SetActive(true);
            bookFruitMenu.SetActive(false);
        }
        else if (chosenButton == "Blue Cabbage")
        {
            bookMainMenu.SetActive(true);
            bookVeggieMenu.SetActive(false);

        }
        else if (chosenButton == "Sea Grapes")
        {
            bookMainMenu.SetActive(true);
            bookFungusMenu.SetActive(false);
        }
    }

    
}
