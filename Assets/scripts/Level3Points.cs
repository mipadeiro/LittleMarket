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
    public ClientThirteenScript clientThirteen;
    public ClientFourteenScript clientFourteen;
    public SprayBottle3 sprayScript;
    public NewPlayerController3 playerScript;
    public GameObject playerCharacter;
    public GameObject level3Controller;

    //items
    public GameObject conditioner;
    public GameObject flyingFish;
    public GameObject chickenLeg;
    public GameObject ice;
    public GameObject runestick;
    public GameObject bansheeBones;
    public GameObject acorn;
    public GameObject sasquatch;
    public GameObject cilantro;
    public GameObject fishFingers;
    public GameObject steak;
    public GameObject oliveOil;
    public GameObject redWine;
    public GameObject flyingSausage;
    public GameObject blood;
    public GameObject glowTomato;
    public GameObject glowberrySqueeze;
    public GameObject garlicPerfume;
    public GameObject deadlyAxe;
    public GameObject arrows;
    public GameObject mincedGarlic;
    public GameObject mirror;
    public GameObject mandrake;
    public GameObject lizardTail;
    public GameObject redMushroom;
    public GameObject glassBall;

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

    public int level3TotalScore;
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
            clientThirteen = FindAnyObjectByType<ClientThirteenScript>();
        }
        if(clientFourteen == null)
        {
            clientFourteen = FindAnyObjectByType<ClientFourteenScript>();
        }
        if(playerScript == null)
        {
            playerScript = FindAnyObjectByType<NewPlayerController3>();
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
            timeScore = timeScore + 100;
        }
        else if(timeClient9 > 25 && timeClient9 < 50)
        {
            timeScore = timeScore + 75;
        }
        else if(timeClient9 > 50 && timeClient9 < 75)
        {
            timeScore = timeScore + 50;
        }
        else if(timeClient9 > 75 && timeClient9 < 99)
        {
            timeScore = timeScore + 25;
        }
        else if(timeClient9 > 99)
        {
            timeScore = timeScore + 0;
        }

        //item falls
        fallenItems = fallenItems + conditioner.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + flyingFish.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + chickenLeg.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + ice.GetComponent<ItemRespawn>().itemFallen;

        //not scanned
        if(conditioner.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(flyingFish.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(chickenLeg.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(ice.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }

        //wrong scan
        if(conditioner.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(flyingFish.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(chickenLeg.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(ice.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }

        //not in cart
        if(conditioner.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(flyingFish.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(chickenLeg.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(ice.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        
        //wrong cart
        if(conditioner.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(flyingFish.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        
        if(chickenLeg.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(ice.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }

        //CLIENT FIVE
        //time bonus
        timeClient10 =  clientTen.timeSpent;
        timeClient10 = (timeClient10 * 100) / clientTen.maxTime;
        if(timeClient10 < 25)
        {
            timeScore = timeScore + 100;
        }
        else if(timeClient10 > 25 && timeClient10 < 50)
        {
            timeScore = timeScore + 75;
        }
        else if(timeClient10 > 50 && timeClient10 < 75)
        {
            timeScore = timeScore + 50;
        }
        else if(timeClient10 > 75 && timeClient10 < 99)
        {
            timeScore = timeScore + 25;
        }
        else if(timeClient10 > 99)
        {
            timeScore = timeScore + 0;
        }

        //item falls
        fallenItems = fallenItems + runestick.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + bansheeBones.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + acorn.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + sasquatch.GetComponent<ItemRespawn>().itemFallen;

        //not scanned
        if(runestick.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(bansheeBones.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(acorn.GetComponent<RegisterItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(sasquatch.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }

        //wrong scan
        if(runestick.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(bansheeBones.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(acorn.GetComponent<RegisterItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(sasquatch.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }

        //not in cart
        if(runestick.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(bansheeBones.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(acorn.GetComponent<RegisterItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(sasquatch.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        
        //wrong cart
        if(runestick.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(bansheeBones.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(acorn.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(sasquatch.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }

        //CLIENT SIX
        //time bonus
        timeClient11 =  clientEleven.timeSpent;
        timeClient11 = (timeClient11 * 100) / clientEleven.maxTime;
        if(timeClient11 < 25)
        {
            timeScore = timeScore + 100;
        }
        else if(timeClient11 > 25 && timeClient11 < 50)
        {
            timeScore = timeScore + 75;
        }
        else if(timeClient11 > 50 && timeClient11 < 75)
        {
            timeScore = timeScore + 50;
        }
        else if(timeClient11 > 75 && timeClient11 < 99)
        {
            timeScore = timeScore + 25;
        }
        else if(timeClient11 > 99)
        {
            timeScore = timeScore + 0;
        }

        //item falls
        fallenItems = fallenItems + cilantro.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + fishFingers.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + steak.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + oliveOil.GetComponent<ItemRespawn>().itemFallen;

        //not scanned
        if(cilantro.GetComponent<RegisterItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(fishFingers.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(steak.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(oliveOil.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }

        //wrong scan
        if(cilantro.GetComponent<RegisterItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(fishFingers.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(steak.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(oliveOil.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }

        //not in cart
        if(cilantro.GetComponent<RegisterItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(fishFingers.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(steak.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(oliveOil.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        
        //wrong cart
        if(cilantro.GetComponent<RegisterItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(fishFingers.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(steak.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(oliveOil.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }

        //CLIENT SEVEN
        //time bonus
        timeClient12 =  clientTwelve.timeSpent;
        timeClient12 = (timeClient12 * 100) / clientTwelve.maxTime;
        if(timeClient12 < 25)
        {
            timeScore = timeScore + 100;
        }
        else if(timeClient12 > 25 && timeClient12 < 50)
        {
            timeScore = timeScore + 75;
        }
        else if(timeClient12 > 50 && timeClient12 < 75)
        {
            timeScore = timeScore + 50;
        }
        else if(timeClient12 > 75 && timeClient12 < 99)
        {
            timeScore = timeScore + 25;
        }
        else if(timeClient12 > 99)
        {
            timeScore = timeScore + 0;
        }

        //item falls
        fallenItems = fallenItems + redWine.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + flyingSausage.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + blood.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + glowTomato.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + glowberrySqueeze.GetComponent<ItemRespawn>().itemFallen;

        //not scanned
        if(redWine.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(flyingSausage.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(blood.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(glowTomato.GetComponent<RegisterItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(glowberrySqueeze.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }

        //wrong scan
        if(redWine.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(flyingSausage.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(blood.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(glowTomato.GetComponent<RegisterItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(glowberrySqueeze.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }

        //not in cart
        if(redWine.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(flyingSausage.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(blood.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(glowTomato.GetComponent<RegisterItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(glowberrySqueeze.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        
        //wrong cart
        if(redWine.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(flyingSausage.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(blood.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(glowTomato.GetComponent<RegisterItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(glowberrySqueeze.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }

        //CLIENT SEVEN
        //time bonus
        timeClient13 =  clientThirteen.timeSpent;
        timeClient13 = (timeClient13 * 100) / clientThirteen.maxTime;
        if(timeClient13 < 25)
        {
            timeScore = timeScore + 100;
        }
        else if(timeClient13 > 25 && timeClient13 < 50)
        {
            timeScore = timeScore + 75;
        }
        else if(timeClient13 > 50 && timeClient13 < 75)
        {
            timeScore = timeScore + 50;
        }
        else if(timeClient13 > 75 && timeClient13 < 99)
        {
            timeScore = timeScore + 25;
        }
        else if(timeClient13 > 99)
        {
            timeScore = timeScore + 0;
        }

        //item falls
        fallenItems = fallenItems + garlicPerfume.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + deadlyAxe.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + arrows.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + mincedGarlic.GetComponent<ItemRespawn>().itemFallen;

        //not scanned
        if(garlicPerfume.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(deadlyAxe.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(arrows.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(mincedGarlic.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }

        //wrong scan
        if(garlicPerfume.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(deadlyAxe.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(arrows.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(mincedGarlic.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }

        //not in cart
        if(garlicPerfume.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(deadlyAxe.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(arrows.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(mincedGarlic.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        
        //wrong cart
        if(garlicPerfume.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(deadlyAxe.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(arrows.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(mincedGarlic.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }

        //CLIENT SEVEN
        //time bonus
        timeClient13 =  clientThirteen.timeSpent;
        timeClient13 = (timeClient13 * 100) / clientThirteen.maxTime;
        if(timeClient13 < 25)
        {
            timeScore = timeScore + 100;
        }
        else if(timeClient13 > 25 && timeClient13 < 50)
        {
            timeScore = timeScore + 75;
        }
        else if(timeClient13 > 50 && timeClient13 < 75)
        {
            timeScore = timeScore + 50;
        }
        else if(timeClient13 > 75 && timeClient13 < 99)
        {
            timeScore = timeScore + 25;
        }
        else if(timeClient13 > 99)
        {
            timeScore = timeScore + 0;
        }

        //item falls
        fallenItems = fallenItems + mirror.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + mandrake.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + lizardTail.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + redMushroom.GetComponent<ItemRespawn>().itemFallen;
        fallenItems = fallenItems + glassBall.GetComponent<ItemRespawn>().itemFallen;

        //not scanned
        if(mirror.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(mandrake.GetComponent<RegisterItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(lizardTail.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(redMushroom.GetComponent<RegisterItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }
        if(glassBall.GetComponent<BasicItemController3>().isScanned == false)
        {
            notScannedItems = notScannedItems - 20;
        }

        //wrong scan
        if(mirror.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(mandrake.GetComponent<RegisterItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(lizardTail.GetComponent<BasicItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(redMushroom.GetComponent<RegisterItemController3>().correctScan == false)
        {
            wrongScanItems = wrongScanItems - 15;
        }
        if(glassBall.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }

        //not in cart
        if(mirror.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(mandrake.GetComponent<RegisterItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(lizardTail.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(redMushroom.GetComponent<RegisterItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        if(glassBall.GetComponent<BasicItemController3>().inCart == false)
        {
            notInCart = notInCart - 10;
        }
        
        //wrong cart
        if(mirror.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(mandrake.GetComponent<RegisterItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(lizardTail.GetComponent<BasicItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(redMushroom.GetComponent<RegisterItemController3>().correctCart == false)
        {
            notInCart = notInCart - 20;
        }
        if(glassBall.GetComponent<BasicItemController3>().correctCart == false)
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

        level3TotalScore = timeScore + fallenItems + notScannedItems + wrongScanItems + notInCart + wrongCart + sprayUses + perfectScan + perfectCart + noPlayerFall + noItemFall;
        ShowPoints();
    }

    public void ShowPoints()
    {
        if(level3TotalScore < 1900)
        {
            failBook.SetActive(true);
        }
        else if (level3TotalScore < 2750 && level3TotalScore > 1900)
        {
            winBook.SetActive(true);
            firstStar.SetActive(true);
        }
        else if (level3TotalScore < 3850 && level3TotalScore > 2750)
        {
            winBook.SetActive(true);
            firstStar.SetActive(true);
            secondStar.SetActive(true);
        }
        else if (level3TotalScore > 3850)
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

        totalScore.text = level3TotalScore.ToString();

        if(playerCharacter.name.Contains("PlayerPaula"))
        {
            GameManager.Instance.level1ScorePaula = level3TotalScore;
        }

        if(playerCharacter.name.Contains("PlayerLinnea"))
        {
            GameManager.Instance.level1ScoreLinnea = level3TotalScore;
        }

        if(playerCharacter.name.Contains("PlayerCreek"))
        {
            GameManager.Instance.level1ScoreCreek = level3TotalScore;
        }
        
        if(playerCharacter.name.Contains("PlayerFred"))
        {
            GameManager.Instance.level1ScoreCreek = level3TotalScore;
        }
    }
}
