using UnityEngine;
using TMPro;

public class Level2Points : MonoBehaviour
{
    //endlevel ui
    public GameObject winBook;
    public GameObject firstStar;
    public GameObject secondStar;
    public GameObject thirdStar;
    public GameObject failBook;
    
    //scripts
    public ClientFourScript clientFour;
    public ClientFiveScript clientFive;
    public ClientSixScript clientSix;
    public ClientSevenScript clientSeven;
    public ClientEightScript clientEight;
    public SprayBottle sprayScript;
    public NewPlayerController playerScript;
    public GameObject playerCharacter;
    public GameObject level2Controller;

    //items
    public GameObject grapes;
    public GameObject mermaidScales;
    public GameObject blueDye;
    public GameObject potato;
    public GameObject soupRock;
    public GameObject apple;
    public GameObject kale;
    public GameObject glowMushroom;
    public GameObject fairyDust;
    public GameObject seaglass;
    public GameObject starFruit;
    public GameObject tigerPrawn;
    public GameObject cilantro;
    public GameObject lemon;
    public GameObject cannedTuna;
    public GameObject pearl;
    public GameObject plankton;
    public GameObject blueCabbage;
    public GameObject minotaurButter;
    public GameObject lochNessPunch;

    //variables to store points and respective txt
    public float timeClient4 = 0;
    public float timeClient5 = 0;
    public float timeClient6 = 0;
    public float timeClient7 = 0;
    public float timeClient8 = 0;
    public int timeScore = 0;
    public TextMeshProUGUI timebonus;
    public int fallenItems = 0;
    public TextMeshProUGUI itemsfallen;
    public int notScannedItems = 0;
    public TextMeshProUGUI noscan;
    public int wrongScanItems = 0;
    public TextMeshProUGUI wrongscan;
    public int notInCart = 0;
    public TextMeshProUGUI nocart;
    public int wrongCart = 0;
    public TextMeshProUGUI wrongCarttxt;
    public int sprayUses = 0;
    public TextMeshProUGUI cleanbonus;
    public int perfectScan = 0;
    public TextMeshProUGUI scanbonus;
    public int perfectCart = 0;
    public TextMeshProUGUI cartbonus;
    public int noPlayerFall = 0;
    public TextMeshProUGUI nofallplayer;
    public int noItemFall = 0;
    public TextMeshProUGUI nofallitem;

    public int level2TotalScore;
    public TextMeshProUGUI totalScore;
    //public int noPrjectileHit = 200;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        if(clientFour == null)
        {
            clientFour = FindAnyObjectByType<ClientFourScript>();
        }
        if(clientFive == null)
        {
            clientFive = FindAnyObjectByType<ClientFiveScript>();
        }
        if(clientSix == null)
        {
            clientSix = FindAnyObjectByType<ClientSixScript>();
        }
        if(clientSeven == null)
        {
            clientSeven = FindAnyObjectByType<ClientSevenScript>();
        }
        if(clientEight == null)
        {
            clientEight = FindAnyObjectByType<ClientEightScript>();
        }
        if(playerScript == null)
        {
            playerScript = FindAnyObjectByType<NewPlayerController>();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalculatePoints()
    {
        playerScript.enabled = false;
        fallenItems = 0;
        notScannedItems = 0;
        wrongScanItems = 0;
        notInCart = 0;
        wrongCart = 0;
        perfectScan = 0;
        perfectCart = 0;
        noPlayerFall = 0;
        noItemFall = 0;
        timeScore = 0;

        level2Controller.SetActive(true);

        //CLIENT FOUR
        //time bonus
        timeClient4 =  clientFour.timeSpent;
        timeClient4 = (timeClient4 * 100) / clientFour.maxTime;
        if(timeClient4 < 25)
        {
            timeScore = timeScore + 100;
        }
        else if(timeClient4 > 25 && timeClient4 < 50)
        {
            timeScore = timeScore + 75;
        }
        else if(timeClient4 > 50 && timeClient4 < 75)
        {
            timeScore = timeScore + 50;
        }
        else if(timeClient4 > 75 && timeClient4 < 99)
        {
            timeScore = timeScore + 25;
        }
        else if(timeClient4 > 99)
        {
            timeScore = timeScore + 0;
        }

        //item falls
        fallenItems = fallenItems + grapes.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + mermaidScales.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + blueDye.GetComponent<ItemRespawn>().itemFallen;

        //not scanned
        if(grapes.GetComponent<RegisterItemController>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(mermaidScales.GetComponent<BasicItemController>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(blueDye.GetComponent<BasicItemController>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }

        //wrong scan
        if(grapes.GetComponent<RegisterItemController>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(mermaidScales.GetComponent<BasicItemController>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(blueDye.GetComponent<BasicItemController>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }

        //not in cart
        if(grapes.GetComponent<RegisterItemController>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(mermaidScales.GetComponent<BasicItemController>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(blueDye.GetComponent<BasicItemController>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        
        //wrong cart
        if(grapes.GetComponent<RegisterItemController>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(mermaidScales.GetComponent<BasicItemController>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(blueDye.GetComponent<BasicItemController>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }

        //CLIENT FIVE
        //time bonus
        timeClient5 =  clientFive.timeSpent;
        timeClient5 = (timeClient5 * 100) / clientFive.maxTime;
        if(timeClient5 < 25)
        {
            timeScore = timeScore + 100;
        }
        else if(timeClient5 > 25 && timeClient5 < 50)
        {
            timeScore = timeScore + 750;
        }
        else if(timeClient5 > 50 && timeClient5 < 75)
        {
            timeScore = timeScore + 50;
        }
        else if(timeClient5 > 75 && timeClient5 < 99)
        {
            timeScore = timeScore + 25;
        }
        else if(timeClient5 > 99)
        {
            timeScore = timeScore + 0;
        }

        //item falls
        fallenItems = fallenItems + potato.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + soupRock.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + apple.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + kale.GetComponent<ItemRespawn>().itemFallen;

        //not scanned
        if(potato.GetComponent<RegisterItemController>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(soupRock.GetComponent<BasicItemController>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(apple.GetComponent<RegisterItemController>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(kale.GetComponent<RegisterItemController>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }

        //wrong scan
        if(potato.GetComponent<RegisterItemController>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(soupRock.GetComponent<BasicItemController>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(apple.GetComponent<RegisterItemController>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(kale.GetComponent<RegisterItemController>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }

        //not in cart
        if(potato.GetComponent<RegisterItemController>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(soupRock.GetComponent<BasicItemController>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(apple.GetComponent<RegisterItemController>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(kale.GetComponent<RegisterItemController>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        
        //wrong cart
        if(potato.GetComponent<RegisterItemController>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(soupRock.GetComponent<BasicItemController>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(apple.GetComponent<RegisterItemController>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(kale.GetComponent<RegisterItemController>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }

        //CLIENT SIX
        //time bonus
        timeClient6 =  clientSix.timeSpent;
        timeClient6 = (timeClient6 * 100) / clientSix.maxTime;
        if(timeClient6 < 25)
        {
            timeScore = timeScore + 100;
        }
        else if(timeClient6 > 25 && timeClient6 < 50)
        {
            timeScore = timeScore + 75;
        }
        else if(timeClient6 > 50 && timeClient6 < 75)
        {
            timeScore = timeScore + 50;
        }
        else if(timeClient6 > 75 && timeClient6 < 99)
        {
            timeScore = timeScore + 25;
        }
        else if(timeClient6 > 99)
        {
            timeScore = timeScore + 0;
        }

        //item falls
        fallenItems = fallenItems + glowMushroom.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + fairyDust.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + seaglass.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + starFruit.GetComponent<ItemRespawn>().itemFallen;

        //not scanned
        if(glowMushroom.GetComponent<RegisterItemController>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(fairyDust.GetComponent<BasicItemController>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(seaglass.GetComponent<BasicItemController>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(starFruit.GetComponent<RegisterItemController>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }

        //wrong scan
        if(glowMushroom.GetComponent<RegisterItemController>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(fairyDust.GetComponent<BasicItemController>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(seaglass.GetComponent<BasicItemController>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(starFruit.GetComponent<RegisterItemController>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }

        //not in cart
        if(glowMushroom.GetComponent<RegisterItemController>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(fairyDust.GetComponent<BasicItemController>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(seaglass.GetComponent<BasicItemController>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(starFruit.GetComponent<RegisterItemController>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        
        //wrong cart
        if(glowMushroom.GetComponent<RegisterItemController>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(fairyDust.GetComponent<BasicItemController>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(seaglass.GetComponent<BasicItemController>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(starFruit.GetComponent<RegisterItemController>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }

        //CLIENT SEVEN
        //time bonus
        timeClient7 =  clientSeven.timeSpent;
        timeClient7 = (timeClient7 * 100) / clientSeven.maxTime;
        if(timeClient7 < 25)
        {
            timeScore = timeScore + 100;
        }
        else if(timeClient7 > 25 && timeClient7 < 50)
        {
            timeScore = timeScore + 75;
        }
        else if(timeClient7 > 50 && timeClient7 < 75)
        {
            timeScore = timeScore + 50;
        }
        else if(timeClient7 > 75 && timeClient7 < 99)
        {
            timeScore = timeScore + 25;
        }
        else if(timeClient7 > 99)
        {
            timeScore = timeScore + 0;
        }

        //item falls
        fallenItems = fallenItems + tigerPrawn.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + cilantro.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + lemon.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + cannedTuna.GetComponent<ItemRespawn>().itemFallen;

        //not scanned
        if(tigerPrawn.GetComponent<BasicItemController>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(cilantro.GetComponent<RegisterItemController>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(lemon.GetComponent<RegisterItemController>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(cannedTuna.GetComponent<BasicItemController>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }

        //wrong scan
        if(tigerPrawn.GetComponent<BasicItemController>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(cilantro.GetComponent<RegisterItemController>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(lemon.GetComponent<RegisterItemController>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(cannedTuna.GetComponent<BasicItemController>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }

        //not in cart
        if(tigerPrawn.GetComponent<BasicItemController>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(cilantro.GetComponent<RegisterItemController>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(lemon.GetComponent<RegisterItemController>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(cannedTuna.GetComponent<BasicItemController>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        
        //wrong cart
        if(tigerPrawn.GetComponent<BasicItemController>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(cilantro.GetComponent<RegisterItemController>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(lemon.GetComponent<RegisterItemController>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(cannedTuna.GetComponent<BasicItemController>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }

        //CLIENT SEVEN
        //time bonus
        timeClient8 =  clientEight.timeSpent;
        timeClient8 = (timeClient8 * 100) / clientEight.maxTime;
        if(timeClient8 < 25)
        {
            timeScore = timeScore + 100;
        }
        else if(timeClient8 > 25 && timeClient8 < 50)
        {
            timeScore = timeScore + 75;
        }
        else if(timeClient8 > 50 && timeClient8 < 75)
        {
            timeScore = timeScore + 50;
        }
        else if(timeClient8 > 75 && timeClient8 < 99)
        {
            timeScore = timeScore + 25;
        }
        else if(timeClient8 > 99)
        {
            timeScore = timeScore + 0;
        }

        //item falls
        fallenItems = fallenItems + pearl.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + plankton.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + blueCabbage.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + minotaurButter.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + lochNessPunch.GetComponent<ItemRespawn>().itemFallen;

        //not scanned
        if(pearl.GetComponent<BasicItemController>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(plankton.GetComponent<BasicItemController>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(blueCabbage.GetComponent<RegisterItemController>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(minotaurButter.GetComponent<BasicItemController>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(lochNessPunch.GetComponent<BasicItemController>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }

        //wrong scan
        if(pearl.GetComponent<BasicItemController>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(plankton.GetComponent<BasicItemController>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(blueCabbage.GetComponent<RegisterItemController>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(minotaurButter.GetComponent<BasicItemController>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(lochNessPunch.GetComponent<BasicItemController>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }

        //not in cart
        if(pearl.GetComponent<BasicItemController>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(plankton.GetComponent<BasicItemController>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(blueCabbage.GetComponent<RegisterItemController>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(minotaurButter.GetComponent<BasicItemController>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(lochNessPunch.GetComponent<BasicItemController>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        
        //wrong cart
        if(pearl.GetComponent<BasicItemController>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(plankton.GetComponent<BasicItemController>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(blueCabbage.GetComponent<RegisterItemController>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(minotaurButter.GetComponent<BasicItemController>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(lochNessPunch.GetComponent<BasicItemController>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }

        //final calculations

        fallenItems = -fallenItems;
        fallenItems = fallenItems * 5;

        //cleaned dirt
        sprayUses = sprayScript.cleanedDirt;
        sprayUses = sprayUses * 100;

        if(notScannedItems == 0 && wrongScanItems == 0)
        {
            perfectScan = 1000;
        }
        if(notInCart == 0 && wrongCart == 0)
        {
            perfectCart = 800;
        }
        if(playerScript.fallenPlayer == 0)
        {
            noPlayerFall = 500;
        }
        if(fallenItems == 0)
        {
            noItemFall = 600;
        }

        level2TotalScore = timeScore + fallenItems + notScannedItems + wrongScanItems + notInCart + wrongCart + sprayUses + perfectScan + perfectCart + noPlayerFall + noItemFall;
        ShowPoints();
    }

    public void ShowPoints()
    {
        if(level2TotalScore < 1800)
        {
            failBook.SetActive(true);
        }
        else if (level2TotalScore < 2400 && level2TotalScore > 1800)
        {
            winBook.SetActive(true);
            firstStar.SetActive(true);
        }
        else if (level2TotalScore < 3500 && level2TotalScore > 2400)
        {
            winBook.SetActive(true);
            firstStar.SetActive(true);
            secondStar.SetActive(true);
        }
        else if (level2TotalScore > 3500)
        {
            winBook.SetActive(true);
            firstStar.SetActive(true);
            secondStar.SetActive(true);
            thirdStar.SetActive(true);
        }

        timebonus.text = timeScore.ToString();

        itemsfallen.text = fallenItems.ToString();

        noscan.text = notScannedItems.ToString();

        wrongscan.text = wrongScanItems.ToString();

        nocart.text = notInCart.ToString();

        wrongCarttxt.text = wrongCart.ToString();

        scanbonus.text = perfectScan.ToString();

        cartbonus.text = perfectCart.ToString();

        nofallplayer.text = noPlayerFall.ToString();

        nofallitem.text = noItemFall.ToString();

        totalScore.text = level2TotalScore.ToString();

        if(GameManager.Instance.activeCharacter == "PlayerFred")
        {
            GameManager.Instance.level2ScorePaula = level2TotalScore;
        }

        if(GameManager.Instance.activeCharacter == "PlayerFred")
        {
            GameManager.Instance.level2ScoreLinnea = level2TotalScore;
        }

        if(GameManager.Instance.activeCharacter == "PlayerFred")
        {
            GameManager.Instance.level2ScoreCreek = level2TotalScore;
        }
        
        if(GameManager.Instance.activeCharacter == "PlayerFred")
        {
            GameManager.Instance.level2ScoreFred = level2TotalScore;
        }

        GameManager.Instance.level2Completed = true;

    }
}
