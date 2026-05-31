using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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
    public GameObject playerLinnea;
    public GameObject playerCreek;
    public GameObject playerFred;
    public GameObject playerPaula;

    //level completion
    public bool level1Completed = false;
    public bool level2Completed = false;
    public bool level3Completed = false;
    public bool level4Completed = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
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