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

    public GameObject level1Button;
    public GameObject level1FirstStar;
    public GameObject level1SecondStar;
    public GameObject level1ThirdStar;
    public GameObject level2Button;
    public GameObject level2FirstStar;
    public GameObject level2SecondStar;
    public GameObject level2ThirdStar;
    public GameObject level3Button;
    public GameObject level3FirstStar;
    public GameObject level3SecondStar;
    public GameObject level3ThirdStar;
    public GameObject level4Button;
    public GameObject level4FirstStar;
    public GameObject level4SecondStar;
    public GameObject level4ThirdStar;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        level1Button.SetActive(true);
        level2Button.SetActive(true);
        level3Button.SetActive(true);
        level4Button.SetActive(true);

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

        if(GameManager.Instance.level1Completed == true)
        {
            creekUnlocked = true;
            creekButton.SetActive(true);
        }

        if(fredUnlocked != true)
        {
            fredButton.SetActive(false);
        }

        if(GameManager.Instance.level2Completed == true)
        {
            fredUnlocked = true;
            fredButton.SetActive(true);
        }

        if(paulaUnlocked != true)
        {
            paulaButton.SetActive(false);
        }

        if(GameManager.Instance.level3Completed == true)
        {
            paulaUnlocked = true;
            paulaButton.SetActive(true);
        }
    }

    public void SetCharacterLinnea()
    {
        chosenCharacter = "PlayerLinnea";
        levelsButton.SetActive(true);
        GameManager.Instance.activeCharacter = "PlayerLinnea";
        DisplayLevels();
        ShowScores();
    }

    public void SetCharacterCreek()
    {
        chosenCharacter = "PlayerCreek";
        levelsButton.SetActive(true);
        GameManager.Instance.activeCharacter = "PlayerCreek";
        DisplayLevels();
        ShowScores();
    }

    public void SetCharacterFred()
    {
        chosenCharacter = "PlayerFred";
        levelsButton.SetActive(true);
        GameManager.Instance.activeCharacter = "PlayerFred";
        DisplayLevels();
        ShowScores();
    }

    public void SetCharacterPaula()
    {
        chosenCharacter = "PlayerPaula";
        levelsButton.SetActive(true);
        GameManager.Instance.activeCharacter = "PlayerPaula";
        DisplayLevels();
        ShowScores();
    }

    public void DisplayLevels()
    {
        if(chosenCharacter == "PlayerLinnea")
        {
            if(GameManager.Instance.linneaLevel1Completed)
            {
                level1Button.SetActive(true);
            }
            if(GameManager.Instance.linneaLevel2Completed)
            {
                level2Button.SetActive(true);
            }
            if(GameManager.Instance.linneaLevel3Completed)
            {
                level3Button.SetActive(true);
            }
            if(GameManager.Instance.linneaLevel4Completed)
            {
                level4Button.SetActive(true);
            }
        }

        if(chosenCharacter == "PlayerCreek")
        {
            if(GameManager.Instance.creekLevel1Completed)
            {
                level1Button.SetActive(true);
            }
            if(GameManager.Instance.creekLevel2Completed)
            {
                level2Button.SetActive(true);
            }
            if(GameManager.Instance.creekLevel3Completed)
            {
                level3Button.SetActive(true);
            }
            if(GameManager.Instance.creekLevel4Completed)
            {
                level4Button.SetActive(true);
            }
        }

        if(chosenCharacter == "PlayerFred")
        {
            if(GameManager.Instance.fredLevel1Completed)
            {
                level1Button.SetActive(true);
            }
            if(GameManager.Instance.fredLevel2Completed)
            {
                level2Button.SetActive(true);
            }
            if(GameManager.Instance.fredLevel3Completed)
            {
                level3Button.SetActive(true);
            }
            if(GameManager.Instance.fredLevel4Completed)
            {
                level4Button.SetActive(true);
            }
        }

        if(chosenCharacter == "PlayerPaula")
        {
            if(GameManager.Instance.paulaLevel1Completed)
            {
                level1Button.SetActive(true);
            }
            if(GameManager.Instance.paulaLevel2Completed)
            {
                level2Button.SetActive(true);
            }
            if(GameManager.Instance.paulaLevel3Completed)
            {
                level3Button.SetActive(true);
            }
            if(GameManager.Instance.paulaLevel4Completed)
            {
                level4Button.SetActive(true);
            }
        }
    }

    public void ShowScores()
    {
        if(chosenCharacter == "PlayerLinnea")
        {
            //level1
            if(GameManager.Instance.level1ScoreLinnea < 1500)
            {
                level1FirstStar.SetActive(false);
                level1SecondStar.SetActive(false);
                level1ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level1ScoreLinnea > 1500 && GameManager.Instance.level1ScoreLinnea > 1950)
            {
                level1FirstStar.SetActive(true);
                level1SecondStar.SetActive(false);
                level1ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level1ScoreLinnea > 1950 && GameManager.Instance.level1ScoreLinnea > 2400)
            {
                level1FirstStar.SetActive(true);
                level1SecondStar.SetActive(true);
                level1ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level1ScoreLinnea > 2400)
            {
                level1FirstStar.SetActive(true);
                level1SecondStar.SetActive(true);
                level1ThirdStar.SetActive(true);
            }

            //level2
            if(GameManager.Instance.level2ScoreLinnea < 1800)
            {
                level2FirstStar.SetActive(false);
                level2SecondStar.SetActive(false);
                level2ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level2ScoreLinnea > 1800 && GameManager.Instance.level2ScoreLinnea > 2400)
            {
                level2FirstStar.SetActive(true);
                level2SecondStar.SetActive(false);
                level2ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level2ScoreLinnea > 2400 && GameManager.Instance.level2ScoreLinnea > 3500)
            {
                level2FirstStar.SetActive(true);
                level2SecondStar.SetActive(true);
                level2ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level2ScoreLinnea > 3500)
            {
                level2FirstStar.SetActive(true);
                level2SecondStar.SetActive(true);
                level2ThirdStar.SetActive(true);
            }

            //level3
            if(GameManager.Instance.level3ScoreLinnea < 1900)
            {
                level3FirstStar.SetActive(false);
                level3SecondStar.SetActive(false);
                level3ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level3ScoreLinnea > 1900 && GameManager.Instance.level3ScoreLinnea > 2750)
            {
                level3FirstStar.SetActive(true);
                level3SecondStar.SetActive(false);
                level3ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level3ScoreLinnea > 2750 && GameManager.Instance.level3ScoreLinnea > 3850)
            {
                level3FirstStar.SetActive(true);
                level3SecondStar.SetActive(true);
                level3ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level3ScoreLinnea > 3850)
            {
                level3FirstStar.SetActive(true);
                level3SecondStar.SetActive(true);
                level3ThirdStar.SetActive(true);
            }

            //level4
            if(GameManager.Instance.level4ScoreLinnea < 1900)
            {
                level4FirstStar.SetActive(false);
                level4SecondStar.SetActive(false);
                level4ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level4ScoreLinnea > 1900 && GameManager.Instance.level4ScoreLinnea > 2750)
            {
                level4FirstStar.SetActive(true);
                level4SecondStar.SetActive(false);
                level4ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level4ScoreLinnea > 2750 && GameManager.Instance.level4ScoreLinnea > 3850)
            {
                level4FirstStar.SetActive(true);
                level4SecondStar.SetActive(true);
                level4ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level4ScoreLinnea > 3850)
            {
                level4FirstStar.SetActive(true);
                level4SecondStar.SetActive(true);
                level4ThirdStar.SetActive(true);
            }
        }
        if(chosenCharacter == "PlayerCreek")
        {
            //level1
            if(GameManager.Instance.level1ScoreCreek < 1500)
            {
                level1FirstStar.SetActive(false);
                level1SecondStar.SetActive(false);
                level1ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level1ScoreCreek > 1500 && GameManager.Instance.level1ScoreCreek > 1950)
            {
                level1FirstStar.SetActive(true);
                level1SecondStar.SetActive(false);
                level1ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level1ScoreCreek > 1950 && GameManager.Instance.level1ScoreCreek > 2400)
            {
                level1FirstStar.SetActive(true);
                level1SecondStar.SetActive(true);
                level1ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level1ScoreCreek > 2400)
            {
                level1FirstStar.SetActive(true);
                level1SecondStar.SetActive(true);
                level1ThirdStar.SetActive(true);
            }

            //level2
            if(GameManager.Instance.level2ScoreCreek < 1800)
            {
                level2FirstStar.SetActive(false);
                level2SecondStar.SetActive(false);
                level2ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level2ScoreCreek > 1800 && GameManager.Instance.level2ScoreCreek > 2400)
            {
                level2FirstStar.SetActive(true);
                level2SecondStar.SetActive(false);
                level2ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level2ScoreCreek > 2400 && GameManager.Instance.level2ScoreCreek > 3500)
            {
                level2FirstStar.SetActive(true);
                level2SecondStar.SetActive(true);
                level2ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level2ScoreCreek > 3500)
            {
                level2FirstStar.SetActive(true);
                level2SecondStar.SetActive(true);
                level2ThirdStar.SetActive(true);
            }

            //level3
            if(GameManager.Instance.level3ScoreCreek < 1900)
            {
                level3FirstStar.SetActive(false);
                level3SecondStar.SetActive(false);
                level3ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level3ScoreCreek > 1900 && GameManager.Instance.level3ScoreCreek > 2750)
            {
                level3FirstStar.SetActive(true);
                level3SecondStar.SetActive(false);
                level3ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level3ScoreCreek > 2750 && GameManager.Instance.level3ScoreCreek > 3850)
            {
                level3FirstStar.SetActive(true);
                level3SecondStar.SetActive(true);
                level3ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level3ScoreCreek > 3850)
            {
                level3FirstStar.SetActive(true);
                level3SecondStar.SetActive(true);
                level3ThirdStar.SetActive(true);
            }

            //level4
            if(GameManager.Instance.level4ScoreCreek < 1900)
            {
                level4FirstStar.SetActive(false);
                level4SecondStar.SetActive(false);
                level4ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level4ScoreCreek > 1900 && GameManager.Instance.level4ScoreCreek > 2750)
            {
                level4FirstStar.SetActive(true);
                level4SecondStar.SetActive(false);
                level4ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level4ScoreCreek > 2750 && GameManager.Instance.level4ScoreCreek > 3850)
            {
                level4FirstStar.SetActive(true);
                level4SecondStar.SetActive(true);
                level4ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level4ScoreCreek > 3850)
            {
                level4FirstStar.SetActive(true);
                level4SecondStar.SetActive(true);
                level4ThirdStar.SetActive(true);
            }
        }
        if(chosenCharacter == "PlayerFred")
        {
            if(GameManager.Instance.level1ScoreFred < 1500)
            {
                level1FirstStar.SetActive(false);
                level1SecondStar.SetActive(false);
                level1ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level1ScoreFred > 1500 && GameManager.Instance.level1ScoreFred > 1950)
            {
                level1FirstStar.SetActive(true);
                level1SecondStar.SetActive(false);
                level1ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level1ScoreFred > 1950 && GameManager.Instance.level1ScoreFred > 2400)
            {
                level1FirstStar.SetActive(true);
                level1SecondStar.SetActive(true);
                level1ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level1ScoreFred > 2400)
            {
                level1FirstStar.SetActive(true);
                level1SecondStar.SetActive(true);
                level1ThirdStar.SetActive(true);
            }

            //level2
            if(GameManager.Instance.level2ScoreFred < 1800)
            {
                level2FirstStar.SetActive(false);
                level2SecondStar.SetActive(false);
                level2ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level2ScoreFred > 1800 && GameManager.Instance.level2ScoreFred > 2400)
            {
                level2FirstStar.SetActive(true);
                level2SecondStar.SetActive(false);
                level2ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level2ScoreFred > 2400 && GameManager.Instance.level2ScoreFred > 3500)
            {
                level2FirstStar.SetActive(true);
                level2SecondStar.SetActive(true);
                level2ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level2ScoreFred > 3500)
            {
                level2FirstStar.SetActive(true);
                level2SecondStar.SetActive(true);
                level2ThirdStar.SetActive(true);
            }

            //level3
            if(GameManager.Instance.level3ScoreFred < 1900)
            {
                level3FirstStar.SetActive(false);
                level3SecondStar.SetActive(false);
                level3ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level3ScoreFred > 1900 && GameManager.Instance.level3ScoreFred > 2750)
            {
                level3FirstStar.SetActive(true);
                level3SecondStar.SetActive(false);
                level3ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level3ScoreFred > 2750 && GameManager.Instance.level3ScoreFred > 3850)
            {
                level3FirstStar.SetActive(true);
                level3SecondStar.SetActive(true);
                level3ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level3ScoreFred > 3850)
            {
                level3FirstStar.SetActive(true);
                level3SecondStar.SetActive(true);
                level3ThirdStar.SetActive(true);
            }

            //level4
            if(GameManager.Instance.level4ScoreFred < 1900)
            {
                level4FirstStar.SetActive(false);
                level4SecondStar.SetActive(false);
                level4ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level4ScoreFred > 1900 && GameManager.Instance.level4ScoreFred > 2750)
            {
                level4FirstStar.SetActive(true);
                level4SecondStar.SetActive(false);
                level4ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level4ScoreFred > 2750 && GameManager.Instance.level4ScoreFred > 3850)
            {
                level4FirstStar.SetActive(true);
                level4SecondStar.SetActive(true);
                level4ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level4ScoreFred > 3850)
            {
                level4FirstStar.SetActive(true);
                level4SecondStar.SetActive(true);
                level4ThirdStar.SetActive(true);
            }
        }
        if(chosenCharacter == "PlayerPaula")
        {
            if(GameManager.Instance.level1ScorePaula < 1500)
            {
                level1FirstStar.SetActive(false);
                level1SecondStar.SetActive(false);
                level1ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level1ScorePaula > 1500 && GameManager.Instance.level1ScorePaula > 1950)
            {
                level1FirstStar.SetActive(true);
                level1SecondStar.SetActive(false);
                level1ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level1ScorePaula > 1950 && GameManager.Instance.level1ScorePaula > 2400)
            {
                level1FirstStar.SetActive(true);
                level1SecondStar.SetActive(true);
                level1ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level1ScorePaula > 2400)
            {
                level1FirstStar.SetActive(true);
                level1SecondStar.SetActive(true);
                level1ThirdStar.SetActive(true);
            }

            //level2
            if(GameManager.Instance.level2ScorePaula < 1800)
            {
                level2FirstStar.SetActive(false);
                level2SecondStar.SetActive(false);
                level2ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level2ScorePaula > 1800 && GameManager.Instance.level2ScorePaula > 2400)
            {
                level2FirstStar.SetActive(true);
                level2SecondStar.SetActive(false);
                level2ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level2ScorePaula > 2400 && GameManager.Instance.level2ScorePaula > 3500)
            {
                level2FirstStar.SetActive(true);
                level2SecondStar.SetActive(true);
                level2ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level2ScorePaula > 3500)
            {
                level2FirstStar.SetActive(true);
                level2SecondStar.SetActive(true);
                level2ThirdStar.SetActive(true);
            }

            //level3
            if(GameManager.Instance.level3ScorePaula < 1900)
            {
                level3FirstStar.SetActive(false);
                level3SecondStar.SetActive(false);
                level3ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level3ScorePaula > 1900 && GameManager.Instance.level3ScorePaula > 2750)
            {
                level3FirstStar.SetActive(true);
                level3SecondStar.SetActive(false);
                level3ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level3ScorePaula > 2750 && GameManager.Instance.level3ScorePaula > 3850)
            {
                level3FirstStar.SetActive(true);
                level3SecondStar.SetActive(true);
                level3ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level3ScorePaula > 3850)
            {
                level3FirstStar.SetActive(true);
                level3SecondStar.SetActive(true);
                level3ThirdStar.SetActive(true);
            }

            //level4
            if(GameManager.Instance.level4ScorePaula < 1900)
            {
                level4FirstStar.SetActive(false);
                level4SecondStar.SetActive(false);
                level4ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level4ScorePaula > 1900 && GameManager.Instance.level4ScorePaula > 2750)
            {
                level4FirstStar.SetActive(true);
                level4SecondStar.SetActive(false);
                level4ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level4ScorePaula > 2750 && GameManager.Instance.level4ScorePaula > 3850)
            {
                level4FirstStar.SetActive(true);
                level4SecondStar.SetActive(true);
                level4ThirdStar.SetActive(false);
            }
            else if(GameManager.Instance.level4ScorePaula > 3850)
            {
                level4FirstStar.SetActive(true);
                level4SecondStar.SetActive(true);
                level4ThirdStar.SetActive(true);
            }
        }
    }
}
