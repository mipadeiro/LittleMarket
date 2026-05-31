using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject playerLinnea;
    public GameObject playerCreek;
    public GameObject playerFred;
    public GameObject playerPaula;

    public GameObject activeCharacter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(GameManager.Instance.activeCharacter == "PlayerLinnea")
        {
            playerLinnea.SetActive(true);
            playerCreek.SetActive(false);
            playerFred.SetActive(false);
            playerPaula.SetActive(false);
            activeCharacter = playerLinnea;
        }
        if(GameManager.Instance.activeCharacter == "PlayerCreek")
        {
            playerLinnea.SetActive(false);
            playerCreek.SetActive(true);
            playerFred.SetActive(false);
            playerPaula.SetActive(false);
            activeCharacter = playerCreek;
        }
        if(GameManager.Instance.activeCharacter == "PlayerFred")
        {
            playerLinnea.SetActive(false);
            playerCreek.SetActive(false);
            playerFred.SetActive(true);
            playerPaula.SetActive(false);
            activeCharacter = playerFred;
        }
        if(GameManager.Instance.activeCharacter == "PlayerPaula")
        {
            playerLinnea.SetActive(false);
            playerCreek.SetActive(false);
            playerFred.SetActive(false);
            playerPaula.SetActive(true);
            activeCharacter = playerPaula;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
