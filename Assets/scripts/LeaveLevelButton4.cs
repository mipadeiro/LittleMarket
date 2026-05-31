using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveLevelButton4 : MonoBehaviour
{
    public GameObject newCharacterScreen;
    public GameObject scoreMenu;
    public int delayTime = 20;

    public void NextScene()
    {
        SceneManager.LoadScene("Hubs");
    }
}