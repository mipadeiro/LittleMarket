using UnityEngine;
using TMPro;

public class Level4Points : MonoBehaviour
{
    //endlevel ui
    public GameObject winBook;
    public GameObject firstStar;
    public GameObject secondStar;
    public GameObject thirdStar;
    public GameObject failBook;
    
    //scripts
    public ClientFifteenScript clientFifteen;
    public ClientSixteenScript clientSixteen;
    public ClientSeventeenScript clientSeventeen;
    public SprayBottle3 sprayScript;
    public NewPlayerController3 playerScript;
    public GameObject playerCharacter;
    public GameObject level3Controller;

    //items
    public GameObject centaurMilk;
    public GameObject goldEgg;
    public GameObject beanCan;
    public GameObject breadSticks;
    public GameObject hairPotion;
    public GameObject redMushroom;
    public GameObject pomegranate;
    public GameObject gummyEyes;
    public GameObject ginger;
    public GameObject rapunzel;
    public GameObject frozenBread;
    public GameObject whiteWine;
    public GameObject krakenStick;
    public GameObject smokedSausages;
    public GameObject chilliPepper;
    public GameObject phoenixAsh;
    public GameObject flamingCroissant;
    public GameObject dragonEgg;
    public LevelManager levelManager;

    //variables to store points and respective txt
    public float timeClient15 = 0;
    public float timeClient16 = 0;
    public float timeClient17 = 0;
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

    public int level4TotalScore;
    public TextMeshProUGUI totalScore;
    //public int noPrjectileHit = 200;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        if(clientFifteen == null)
        {
            clientFifteen = FindAnyObjectByType<ClientFifteenScript>();
        }
        if(clientSixteen == null)
        {
            clientSixteen = FindAnyObjectByType<ClientSixteenScript>();
        }
        if(clientSeventeen == null)
        {
            clientSeventeen = FindAnyObjectByType<ClientSeventeenScript>();
        }
        if(levelManager == null)
        {
            levelManager = FindAnyObjectByType<LevelManager>();
        }
        if(playerScript == null)
        {
            playerScript = FindAnyObjectByType<NewPlayerController3>();
        }
        if(playerCharacter == null)
        {
            playerCharacter = levelManager.activeCharacter;
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

        level3Controller.SetActive(true);

        //CLIENT FOUR
        //time bonus
        timeClient15 =  clientFifteen.timeSpent;
        timeClient15 = (timeClient15 * 100) / clientFifteen.maxTime;
        if(timeClient15 < 25)
        {
            timeScore = timeScore + 100;
        }
        else if(timeClient15 > 25 && timeClient15 < 50)
        {
            timeScore = timeScore + 75;
        }
        else if(timeClient15 > 50 && timeClient15 < 75)
        {
            timeScore = timeScore + 50;
        }
        else if(timeClient15 > 75 && timeClient15 < 99)
        {
            timeScore = timeScore + 25;
        }
        else if(timeClient15 > 99)
        {
            timeScore = timeScore + 0;
        }

        //item falls
        fallenItems = fallenItems + centaurMilk.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + goldEgg.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + beanCan.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + breadSticks.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + hairPotion.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + redMushroom.GetComponent<ItemRespawn>().itemFallen;

        //not scanned
        if(centaurMilk.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(goldEgg.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(beanCan.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(breadSticks.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(hairPotion.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(redMushroom.GetComponent<RegisterItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }

        //wrong scan
        if(centaurMilk.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(goldEgg.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(beanCan.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(breadSticks.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(hairPotion.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(redMushroom.GetComponent<RegisterItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }

        //not in cart
        if(centaurMilk.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(goldEgg.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(beanCan.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(breadSticks.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(hairPotion.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(redMushroom.GetComponent<RegisterItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        
        //wrong cart
        if(centaurMilk.GetComponent<BasicItemController3>().correctCart == false)
        {
            wrongCart = wrongCart - 20;
        }
        if(goldEgg.GetComponent<BasicItemController3>().correctCart == false)
        {
            wrongCart = wrongCart - 20;
        }
        
        if(beanCan.GetComponent<BasicItemController3>().correctCart == false)
        {
            wrongCart = wrongCart - 20;
        }
        if(breadSticks.GetComponent<BasicItemController3>().correctCart == false)
        {
            wrongCart = wrongCart - 20;
        }
        if(hairPotion.GetComponent<BasicItemController3>().correctCart == false)
        {
            wrongCart = wrongCart - 20;
        }
        if(redMushroom.GetComponent<RegisterItemController3>().correctCart == false)
        {
            wrongCart = wrongCart - 20;
        }

        //CLIENT FIVE
        //time bonus
        timeClient16 =  clientSixteen.timeSpent;
        timeClient16 = (timeClient16 * 100) / clientSixteen.maxTime;
        if(timeClient16 < 25)
        {
            timeScore = timeScore + 100;
        }
        else if(timeClient16 > 25 && timeClient16 < 50)
        {
            timeScore = timeScore + 75;
        }
        else if(timeClient16 > 50 && timeClient16 < 75)
        {
            timeScore = timeScore + 50;
        }
        else if(timeClient16 > 75 && timeClient16 < 99)
        {
            timeScore = timeScore + 25;
        }
        else if(timeClient16 > 99)
        {
            timeScore = timeScore + 0;
        }

        //item falls
        fallenItems = fallenItems + pomegranate.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + gummyEyes.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + ginger.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + rapunzel.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + frozenBread.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + whiteWine.GetComponent<ItemRespawn>().itemFallen;

        //not scanned
        if(pomegranate.GetComponent<RegisterItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(gummyEyes.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(ginger.GetComponent<RegisterItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(rapunzel.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(frozenBread.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(whiteWine.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }

        //wrong scan
        if(pomegranate.GetComponent<RegisterItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(gummyEyes.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(ginger.GetComponent<RegisterItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(rapunzel.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(frozenBread.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(whiteWine.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        

        //not in cart
        if(pomegranate.GetComponent<RegisterItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(gummyEyes.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(ginger.GetComponent<RegisterItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(rapunzel.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(frozenBread.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(whiteWine.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        
        //wrong cart
        if(pomegranate.GetComponent<RegisterItemController3>().correctCart == false)
        {
            wrongCart = wrongCart - 20;
        }
        if(gummyEyes.GetComponent<BasicItemController3>().correctCart == false)
        {
            wrongCart = wrongCart - 20;
        }
        if(ginger.GetComponent<RegisterItemController3>().correctCart == false)
        {
            wrongCart = wrongCart - 20;
        }
        if(rapunzel.GetComponent<BasicItemController3>().correctCart == false)
        {
            wrongCart = wrongCart - 20;
        }
        if(frozenBread.GetComponent<BasicItemController3>().correctCart == false)
        {
            wrongCart = wrongCart - 20;
        }
        if(whiteWine.GetComponent<BasicItemController3>().correctCart == false)
        {
            wrongCart = wrongCart - 20;
        }

        //CLIENT SIX
        //time bonus
        timeClient17 =  clientSeventeen.timeSpent;
        timeClient17 = (timeClient17 * 100) / clientSeventeen.maxTime;
        if(timeClient17 < 25)
        {
            timeScore = timeScore + 100;
        }
        else if(timeClient17 > 25 && timeClient17 < 50)
        {
            timeScore = timeScore + 75;
        }
        else if(timeClient17 > 50 && timeClient17 < 75)
        {
            timeScore = timeScore + 50;
        }
        else if(timeClient17 > 75 && timeClient17 < 99)
        {
            timeScore = timeScore + 25;
        }
        else if(timeClient17 > 99)
        {
            timeScore = timeScore + 0;
        }

        //item falls
        fallenItems = fallenItems + krakenStick.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + smokedSausages.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + chilliPepper.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + phoenixAsh.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + flamingCroissant.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + dragonEgg.GetComponent<ItemRespawn>().itemFallen;

        //not scanned
        if(krakenStick.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(smokedSausages.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(chilliPepper.GetComponent<RegisterItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(phoenixAsh.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(flamingCroissant.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(dragonEgg.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }

        //wrong scan
        if(krakenStick.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(smokedSausages.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(chilliPepper.GetComponent<RegisterItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(phoenixAsh.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(flamingCroissant.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(dragonEgg.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }

        //not in cart
        if(krakenStick.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(smokedSausages.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(chilliPepper.GetComponent<RegisterItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(phoenixAsh.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(flamingCroissant.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(dragonEgg.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        
        //wrong cart
        if(krakenStick.GetComponent<BasicItemController3>().correctCart == false)
        {
            wrongCart = wrongCart - 20;
        }
        if(smokedSausages.GetComponent<BasicItemController3>().correctCart == false)
        {
            wrongCart = wrongCart - 20;
        }
        if(chilliPepper.GetComponent<RegisterItemController3>().correctCart == false)
        {
            wrongCart = wrongCart - 20;
        }
        if(phoenixAsh.GetComponent<BasicItemController3>().correctCart == false)
        {
            wrongCart = wrongCart - 20;
        }
        if(flamingCroissant.GetComponent<BasicItemController3>().correctCart == false)
        {
            wrongCart = wrongCart - 20;
        }
        if(dragonEgg.GetComponent<BasicItemController3>().correctCart == false)
        {
            wrongCart = wrongCart - 20;
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

        level4TotalScore = timeScore + fallenItems + notScannedItems + wrongScanItems + notInCart + wrongCart + sprayUses + perfectScan + perfectCart + noPlayerFall + noItemFall;
        ShowPoints();
    }

    public void ShowPoints()
    {
        if(level4TotalScore < 1900)
        {
            failBook.SetActive(true);
            winBook.SetActive(false);
            firstStar.SetActive(false);
            secondStar.SetActive(false);
            thirdStar.SetActive(false);
        }
        else if (level4TotalScore < 2750 && level4TotalScore > 1900)
        {
            failBook.SetActive(false);
            winBook.SetActive(true);
            firstStar.SetActive(true);
            secondStar.SetActive(false);
            thirdStar.SetActive(false);
        }
        else if (level4TotalScore < 3850 && level4TotalScore > 2750)
        {
            failBook.SetActive(false);
            winBook.SetActive(true);
            firstStar.SetActive(true);
            secondStar.SetActive(true);
            thirdStar.SetActive(false);
        }
        else if (level4TotalScore > 3850)
        {
            failBook.SetActive(false);
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

        totalScore.text = level4TotalScore.ToString();

        if(GameManager.Instance.activeCharacter == "PlayerPaula")
        {
            GameManager.Instance.level4ScorePaula = level4TotalScore;
        }

        if(GameManager.Instance.activeCharacter == "PlayerLinnea")
        {
            GameManager.Instance.level4ScoreLinnea = level4TotalScore;
        }

        if(GameManager.Instance.activeCharacter == "PlayerCreek")
        {
            GameManager.Instance.level4ScoreCreek = level4TotalScore;
        }
        
        if(GameManager.Instance.activeCharacter == "PlayerFred")
        {
            GameManager.Instance.level4ScoreFred = level4TotalScore;
        }

        GameManager.Instance.level4Completed = true;

    }
}
