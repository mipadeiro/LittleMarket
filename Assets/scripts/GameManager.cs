using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool firstPlay = true;

    //linnea
    public int level1ScoreLinnea;
    public int level2ScoreLinnea;
    public int level3ScoreLinnea;
    public int level4ScoreLinnea;

    //paula
    public int level1ScorePaula;
    public int level2ScorePaula;
    public int level3ScorePaula;
    public int level4ScorePaula;

    //creek
    public int level1ScoreCreek;
    public int level2ScoreCreek;
    public int level3ScoreCreek;
    public int level4ScoreCreek;
    
    //fred
    public int level1ScoreFred;
    public int level2ScoreFred;
    public int level3ScoreFred;
    public int level4ScoreFred;

    //store characters
    public string activeCharacter;

    //level completion
    public bool level1Completed = false;
    public bool linneaLevel1Completed = false;
    public bool creekLevel1Completed = false;
    public bool fredLevel1Completed = false;
    public bool paulaLevel1Completed = false;
    public bool level2Completed = false;
    public bool linneaLevel2Completed = false;
    public bool creekLevel2Completed = false;
    public bool fredLevel2Completed = false;
    public bool paulaLevel2Completed = false;
    public bool level3Completed = false;
    public bool linneaLevel3Completed = false;
    public bool creekLevel3Completed = false;
    public bool fredLevel3Completed = false;
    public bool paulaLevel3Completed = false;
    public bool level4Completed = false;
    public bool linneaLevel4Completed = false;
    public bool creekLevel4Completed = false;
    public bool fredLevel4Completed = false;
    public bool paulaLevel4Completed = false;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (string.IsNullOrEmpty(activeCharacter))
        {
            activeCharacter = "PlayerLinnea";
        }
    }

    public int GetTotalScoreLinnea()
    {
        return level1ScoreLinnea + level2ScoreLinnea + level3ScoreLinnea + level4ScoreLinnea;
    }

    public int GetTotalScorePaula()
    {
        return level1ScorePaula + level2ScorePaula + level3ScorePaula + level4ScorePaula;
    }

    public int GetTotalScoreCreek()
    {
        return level1ScoreCreek + level2ScoreCreek + level3ScoreCreek + level4ScoreCreek;
    }

    public int GetTotalScoreFred()
    {
        return level1ScoreFred + level2ScoreFred + level3ScoreFred + level4ScoreFred;
    }

}