using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class BookMenu : MonoBehaviour
{
    public ItemController itemScript;
    public NewPlayerController playerScript;
    public TMPro.TextMeshProUGUI textItems;
    public string chosenButton;
    public GameObject bookCanvas;
    public GameObject bookMainMenu;
    public GameObject bookFruitMenu;
    public GameObject bookVeggieMenu;
    public GameObject bookFungusMenu;
    public Button fruit1Button;
    public Button fruit2Button;
    public Button fruit3Button;
    public Button fruit4Button;
    public Button fruit5Button;
    public Button veggie1Button;
    public Button veggie2Button;
    public Button veggie3Button;
    public Button veggie4Button;
    public Button veggie5Button;
    public Button fungus1Button;
    public Button fungus2Button;
    public Button fungus3Button;
    public Button fungus4Button;
    public Button fungus5Button;

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
    }
}
