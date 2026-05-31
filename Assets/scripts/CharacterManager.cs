using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public bool creekUnlocked;
    public GameObject creekButton;
    public bool fredUnlocked;
    public GameObject fredButton;
    public bool paulaUnlocked;
    public GameObject paulaButton;
    public string chosenCharacter = null;
    public GameObject levelsButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (chosenCharacter == null)
        {
            levelsButton.SetActive(false);
        }

        if(creekUnlocked != true)
        {
            creekButton.SetActive(false);
        }

        /* if(GameManager.level1Completed == true)
        {
            creekUnlocked = true;
            creekButton.SetActive(false);
        }

        if(fredUnlocked != true)
        {
            fredButton.SetActive(false);
        }

        if(GameManager.level2Completed == true)
        {
            fredUnlocked = true;
            fredButton.SetActive(false);
        }

        if(paulaUnlocked != true)
        {
            paulaButton.SetActive(false);
        }

        if(GameManager.level3Completed == true)
        {
            paulaUnlocked = true;
            paulaButton.SetActive(true);
        } */
    }

    public void SetCharacterLinnea()
    {
        chosenCharacter = "PlayerLinnea";
        levelsButton.SetActive(true);
        //ShowScores(Linnea);
    }

    public void SetCharacterCreek()
    {
        chosenCharacter = "PlayerCreek";
        levelsButton.SetActive(true);
        //ShowScores(Creek);
    }

    public void SetCharacterFred()
    {
        chosenCharacter = "PlayerFred";
        levelsButton.SetActive(true);
        //ShowScores(Fred);
    }

    public void SetCharacterPaula()
    {
        chosenCharacter = "PlayerPaula";
        levelsButton.SetActive(true);
        //ShowScores(Paula);
    }

    void ShowScores(string character)
    {
        //add way to see scores for each character
    }
}
