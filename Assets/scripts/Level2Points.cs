using UnityEngine;
using TMPro;

public class Level2Points : MonoBehaviour
{
    //scripts
    public ClientFourScript clientFour;
    public ClientFiveScript clientFive;
    public ClientSixScript clientSix;
    public ClientSevenScript clientSeven;
    public ClientEightScript clientEight;
    public SprayBottle sprayScript;
    public NewPlayerController playerScript;

    //items
    public GameObject honey;
    public GameObject hairDye;
    public GameObject superGlue;
    public GameObject unicornHorn;
    public GameObject lembasBread;
    public GameObject goldRing;
    public GameObject wingedShoes;
    public GameObject moonwellWater;
    public GameObject dirtBegone;

    //variables to store points and respective txt
    public float timeClient4 = 0;
    public float timeClient5 = 0;
    public float timeClient6 = 0;
    public float timeClient7 = 0;
    public float timeClient8 = 0;
    public float timeScore = 0;
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

    public float level2TotalScore;
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
        //CLIENT FOUR

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

        //CLIENT FIVE
        //item falls
        fallenItems = fallenItems + hairDye.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + superGlue.GetComponent<ItemRespawn>().itemFallen;  
        fallenItems = fallenItems + unicornHorn.GetComponent<ItemRespawn>().itemFallen;

        //not scanned
        if(hairDye.GetComponent<FirstItem>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(superGlue.GetComponent<FirstItem>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(unicornHorn.GetComponent<FirstItem>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }

        //wrong scan
        if(hairDye.GetComponent<FirstItem>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(superGlue.GetComponent<FirstItem>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(unicornHorn.GetComponent<FirstItem>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }

        //not in cart
        if(hairDye.GetComponent<FirstItem>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(superGlue.GetComponent<FirstItem>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(unicornHorn.GetComponent<FirstItem>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        
        //wrong cart
        if(hairDye.GetComponent<FirstItem>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(superGlue.GetComponent<FirstItem>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(unicornHorn.GetComponent<FirstItem>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }

        //CLIENT SIX
        //time
        timeClient6 =  clientSix.timeSpent;
        if((timeClient6 / 4) < 25)
        {
            timeScore = timeScore + 500;
        }
        else if((timeClient6 / 4) > 25 && (timeClient6 / 4) < 50)
        {
            timeScore = timeScore + 250;
        }
        else if((timeClient6 / 4) > 50 && (timeClient6 / 4) < 75)
        {
            timeScore = timeScore + 100;
        }
        else if((timeClient6 / 4) > 75 && (timeClient6 / 4) < 99)
        {
            timeScore = timeScore + 30;
        }
        else if((timeClient6 / 4) > 99)
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
        if(lembasBread.GetComponent<FirstItem>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(goldRing.GetComponent<FirstItem>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(moonwellWater.GetComponent<FirstItem>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(wingedShoes.GetComponent<FirstItem>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(dirtBegone.GetComponent<FirstItem>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }

        //wrong scan
        if(lembasBread.GetComponent<FirstItem>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(goldRing.GetComponent<FirstItem>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(moonwellWater.GetComponent<FirstItem>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(wingedShoes.GetComponent<FirstItem>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(dirtBegone.GetComponent<FirstItem>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }

        //not in cart
        if(lembasBread.GetComponent<FirstItem>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(goldRing.GetComponent<FirstItem>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(moonwellWater.GetComponent<FirstItem>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(wingedShoes.GetComponent<FirstItem>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(dirtBegone.GetComponent<FirstItem>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        
        //wrong cart
        if(lembasBread.GetComponent<FirstItem>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(goldRing.GetComponent<FirstItem>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(moonwellWater.GetComponent<FirstItem>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(wingedShoes.GetComponent<FirstItem>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(dirtBegone.GetComponent<FirstItem>().correctCart == false)
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

        level2TotalScore = timeScore + fallenItems + notScannedItems + wrongScanItems + notInCart + wrongCart + sprayUses + perfectScan + perfectCart + noPlayerFall + noItemFall;
    }
}
