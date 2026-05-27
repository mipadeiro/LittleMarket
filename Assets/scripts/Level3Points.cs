using UnityEngine;
using TMPro;

public class Level3Points : MonoBehaviour
{
    //endlevel ui
    public GameObject winBook;
    public GameObject firstStar;
    public GameObject secondStar;
    public GameObject thirdStar;
    public GameObject failBook;
    
    //scripts
    public ClientNineScript clientNine;
    public ClientTenScript clientTen;
    public ClientElevenScript clientEleven;
    public ClientTwelveScript clientTwelve;
    public ClientTwelveScript clientThirteen;
    public ClientFourteenScript clientFourteen;
    public SprayBottle sprayScript;
    public NewPlayerController playerScript;
    public GameObject playerCharacter;
    public GameObject level3Controller;

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
    public float timeClient9 = 0;
    public float timeClient10 = 0;
    public float timeClient11 = 0;
    public float timeClient12 = 0;
    public float timeClient13 = 0;
    public float timeClient14 = 0;
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
        if(clientNine == null)
        {
            clientNine = FindAnyObjectByType<ClientNineScript>();
        }
        if(clientTen == null)
        {
            clientTen = FindAnyObjectByType<ClientTenScript>();
        }
        if(clientEleven == null)
        {
            clientEleven = FindAnyObjectByType<ClientElevenScript>();
        }
        if(clientTwelve == null)
        {
            clientTwelve = FindAnyObjectByType<ClientTwelveScript>();
        }
        if(clientThirteen == null)
        {
            clientThirteen = FindAnyObjectByType<ClientTwelveScript>();
        }
        if(clientFourteen == null)
        {
            clientFourteen = FindAnyObjectByType<ClientFourteenScript>();
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

        level3Controller.SetActive(true);

        //CLIENT FOUR
        //time bonus
        timeClient9 =  clientNine.timeSpent;
        timeClient9 = (timeClient9 * 100) / clientNine.maxTime;
        if(timeClient9 < 25)
        {
            timeScore = timeScore + 300;
        }
        else if(timeClient9 > 25 && timeClient9 < 50)
        {
            timeScore = timeScore + 200;
        }
        else if(timeClient9 > 50 && timeClient9 < 75)
        {
            timeScore = timeScore + 100;
        }
        else if(timeClient9 > 75 && timeClient9 < 99)
        {
            timeScore = timeScore + 30;
        }
        else if(timeClient9 > 99)
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
        timeClient10 =  clientTen.timeSpent;
        timeClient10 = (timeClient10 * 100) / clientTen.maxTime;
        if(timeClient10 < 25)
        {
            timeScore = timeScore + 300;
        }
        else if(timeClient10 > 25 && timeClient10 < 50)
        {
            timeScore = timeScore + 200;
        }
        else if(timeClient10 > 50 && timeClient10 < 75)
        {
            timeScore = timeScore + 100;
        }
        else if(timeClient10 > 75 && timeClient10 < 99)
        {
            timeScore = timeScore + 30;
        }
        else if(timeClient10 > 99)
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
        timeClient11 =  clientEleven.timeSpent;
        timeClient11 = (timeClient11 * 100) / clientEleven.maxTime;
        if(timeClient11 < 25)
        {
            timeScore = timeScore + 300;
        }
        else if(timeClient11 > 25 && timeClient11 < 50)
        {
            timeScore = timeScore + 200;
        }
        else if(timeClient11 > 50 && timeClient11 < 75)
        {
            timeScore = timeScore + 100;
        }
        else if(timeClient11 > 75 && timeClient11 < 99)
        {
            timeScore = timeScore + 30;
        }
        else if(timeClient11 > 99)
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
        timeClient12 =  clientTwelve.timeSpent;
        timeClient12 = (timeClient12 * 100) / clientTwelve.maxTime;
        if(timeClient12 < 25)
        {
            timeScore = timeScore + 300;
        }
        else if(timeClient12 > 25 && timeClient12 < 50)
        {
            timeScore = timeScore + 200;
        }
        else if(timeClient12 > 50 && timeClient12 < 75)
        {
            timeScore = timeScore + 100;
        }
        else if(timeClient12 > 75 && timeClient12 < 99)
        {
            timeScore = timeScore + 30;
        }
        else if(timeClient12 > 99)
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
        timeClient13 =  clientThirteen.timeSpent;
        timeClient13 = (timeClient13 * 100) / clientThirteen.maxTime;
        if(timeClient13 < 25)
        {
            timeScore = timeScore + 300;
        }
        else if(timeClient13 > 25 && timeClient13 < 50)
        {
            timeScore = timeScore + 200;
        }
        else if(timeClient13 > 50 && timeClient13 < 75)
        {
            timeScore = timeScore + 100;
        }
        else if(timeClient13 > 75 && timeClient13 < 99)
        {
            timeScore = timeScore + 30;
        }
        else if(timeClient13 > 99)
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
        sprayUses = sprayUses * 20;

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
        if(level2TotalScore < 2000)
        {
            failBook.SetActive(true);
        }
        else if (level2TotalScore < 2800 && level2TotalScore > 2000)
        {
            winBook.SetActive(true);
            firstStar.SetActive(true);
        }
        else if (level2TotalScore < 3200 && level2TotalScore > 2800)
        {
            winBook.SetActive(true);
            firstStar.SetActive(true);
            secondStar.SetActive(true);
        }
        else if (level2TotalScore > 3200)
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

        if(playerCharacter.name.Contains("PlayerPaula"))
        {
            GameManager.Instance.level1ScorePaula = level2TotalScore;
        }

        if(playerCharacter.name.Contains("PlayerLinnea"))
        {
            GameManager.Instance.level1ScoreLinnea = level2TotalScore;
        }

        if(playerCharacter.name.Contains("PlayerCreek"))
        {
            GameManager.Instance.level1ScoreCreek = level2TotalScore;
        }
        
        if(playerCharacter.name.Contains("PlayerFred"))
        {
            GameManager.Instance.level1ScoreCreek = level2TotalScore;
        }
    }
}
