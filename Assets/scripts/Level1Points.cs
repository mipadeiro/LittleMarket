using UnityEngine;
using TMPro;

public class Level1Points : MonoBehaviour
{
    public GameObject level1Controller;
    public ClientOneScript clientOne;
    public ClientTwoScript clientTwo;
    public ClientThreeScript clientThree;
    public ClientTimer1 timerScript;
    public NewPlayerController1 playerScript;
    public GameObject playerCharacter;
    public GameObject honey;
    public GameObject hairDye;
    public GameObject superGlue;
    public GameObject unicornHorn;
    public GameObject lembasBread;
    public GameObject goldRing;
    public GameObject wingedShoes;
    public GameObject moonwellWater;
    public GameObject dirtBegone;

    //variables to store points
    public float timeClient1 = 0;
    public float timeClient2 = 0;
    public float timeClient3 = 0;
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
    //public int sprayUses = 0;
    //public TextMeshProUGUI cleanbonus;
    public int perfectScan = 0;
    public TextMeshProUGUI scanbonus;
    public int perfectCart = 0;
    public TextMeshProUGUI cartbonus;
    public int noPlayerFall = 0;
    public TextMeshProUGUI nofallplayer;
    public int noItemFall = 0;
    public TextMeshProUGUI nofallitem;

    public int level1TotalScore;
    public TextMeshProUGUI totalScore;
    //public int noPrjectileHit = 200;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        if(clientOne == null)
        {
            clientOne = FindAnyObjectByType<ClientOneScript>();
        }
        if(clientTwo == null)
        {
            clientTwo = FindAnyObjectByType<ClientTwoScript>();
        }
        if(clientThree == null)
        {
            clientThree = FindAnyObjectByType<ClientThreeScript>();
        }
        if(timerScript == null)
        {
            timerScript = FindAnyObjectByType<ClientTimer1>();
        }
        if(playerScript == null)
        {
            playerScript = FindAnyObjectByType<NewPlayerController1>();
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

        level1Controller.SetActive(true);
        //first client

        //item falls
        fallenItems = fallenItems + honey.GetComponent<ItemRespawn>().itemFallen;

        //not scanned
        if(honey.GetComponent<FirstItem>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }

        //wrong scan
        if(honey.GetComponent<FirstItem>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }

        //not in cart
        if(honey.GetComponent<FirstItem>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        
        //wrong cart
        if(honey.GetComponent<FirstItem>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }

        //cleaned dirt
        //sprayUses = sprayScript.cleanedDirt;

        //second client
        //item falls
        fallenItems = fallenItems + hairDye.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + superGlue.GetComponent<ItemRespawn>().itemFallen;  
        fallenItems = fallenItems + unicornHorn.GetComponent<ItemRespawn>().itemFallen;

        //not scanned
        if(hairDye.GetComponent<BasicItemController1>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(superGlue.GetComponent<BasicItemController1>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(unicornHorn.GetComponent<BasicItemController1>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }

        //wrong scan
        if(hairDye.GetComponent<BasicItemController1>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(superGlue.GetComponent<BasicItemController1>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(unicornHorn.GetComponent<BasicItemController1>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }

        //not in cart
        if(hairDye.GetComponent<BasicItemController1>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(superGlue.GetComponent<BasicItemController1>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(unicornHorn.GetComponent<BasicItemController1>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        
        //wrong cart
        if(hairDye.GetComponent<BasicItemController1>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(superGlue.GetComponent<BasicItemController1>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(unicornHorn.GetComponent<BasicItemController1>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }

        //third client
        //time
        timeClient1 =  timerScript.timeSpent;
        if((timeClient1 / 4) < 25)
        {
            timeScore = timeScore + 500;
        }
        else if((timeClient1 / 4) > 25 && (timeClient1 / 4) < 50)
        {
            timeScore = timeScore + 250;
        }
        else if((timeClient1 / 4) > 50 && (timeClient1 / 4) < 75)
        {
            timeScore = timeScore + 100;
        }
        else if((timeClient1 / 4) > 75 && (timeClient1 / 4) < 99)
        {
            timeScore = timeScore + 30;
        }
        else if((timeClient1 / 4) > 99)
        {
            timeScore = timeScore + 0;
        }

        //item falls
        fallenItems = fallenItems + lembasBread.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + goldRing.GetComponent<ItemRespawn>().itemFallen;  
        fallenItems = fallenItems + moonwellWater.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + wingedShoes.GetComponent<ItemRespawn>().itemFallen;  
        fallenItems = fallenItems + dirtBegone.GetComponent<ItemRespawn>().itemFallen;

        //not scanned
        if(lembasBread.GetComponent<BasicItemController1>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(goldRing.GetComponent<BasicItemController1>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(moonwellWater.GetComponent<BasicItemController1>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(wingedShoes.GetComponent<BasicItemController1>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(dirtBegone.GetComponent<BasicItemController1>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }

        //wrong scan
        if(lembasBread.GetComponent<BasicItemController1>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(goldRing.GetComponent<BasicItemController1>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(moonwellWater.GetComponent<BasicItemController1>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(wingedShoes.GetComponent<BasicItemController1>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(dirtBegone.GetComponent<BasicItemController1>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }

        //not in cart
        if(lembasBread.GetComponent<BasicItemController1>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(goldRing.GetComponent<BasicItemController1>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(moonwellWater.GetComponent<BasicItemController1>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(wingedShoes.GetComponent<BasicItemController1>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(dirtBegone.GetComponent<BasicItemController1>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        
        //wrong cart
        if(lembasBread.GetComponent<BasicItemController1>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(goldRing.GetComponent<BasicItemController1>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(moonwellWater.GetComponent<BasicItemController1>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(wingedShoes.GetComponent<BasicItemController1>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(dirtBegone.GetComponent<BasicItemController1>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }

        //final calculations

        fallenItems = -fallenItems;
        fallenItems = fallenItems * 5;

        //sprayUses = sprayUses * 20;

        if(notScannedItems == 0 && wrongScanItems == 0)
        {
            perfectScan = 75;
        }
        if(notInCart == 0 && wrongCart == 0)
        {
            perfectCart = 50;
        }
        if(playerScript.fallenPlayer == 0)
        {
            noPlayerFall = 150;
        }
        if(fallenItems == 0)
        {
            noItemFall = 100;
        }

        level1TotalScore = timeScore + fallenItems + notScannedItems + wrongScanItems + notInCart + wrongCart + perfectScan + perfectCart + noPlayerFall + noItemFall;
        ShowPoints();
    }

    public void ShowPoints()
    {

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

        totalScore.text = level1TotalScore.ToString();

        if(playerCharacter.name.Contains("PlayerPaula"))
        {
            GameManager.Instance.level1ScorePaula = level1TotalScore;
        }

        if(playerCharacter.name.Contains("PlayerLinnea"))
        {
            GameManager.Instance.level1ScoreLinnea = level1TotalScore;
        }

        if(playerCharacter.name.Contains("PlayerCreek"))
        {
            GameManager.Instance.level1ScoreCreek = level1TotalScore;
        }
        
        if(playerCharacter.name.Contains("PlayerFred"))
        {
            GameManager.Instance.level1ScoreCreek = level1TotalScore;
        }
    }
}
