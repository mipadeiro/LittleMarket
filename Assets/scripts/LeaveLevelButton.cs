using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveLevelButton : MonoBehaviour
{
    public GameObject newCharacterScreen;
    public GameObject scoreMenu;
    public int delayTime = 5;

    public void NextScene()
    {
        newCharacterScreen.SetActive(true);
        scoreMenu.SetActive(false);
        StartCoroutine(CharacterDelay(delayTime));
        SceneManager.LoadScene("Hubs");
    }

    public IEnumerator CharacterDelay(float duration)
    {
        Debug.Log("Showing new character before leaving");
        yield return new WaitForSeconds(duration);
    }
}