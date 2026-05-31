using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsSceneSwitcher : MonoBehaviour
{
    [SerializeField] private int nextSceneIndex = 0;
    [SerializeField] private float delay = 33f;

    private bool hasSwitched = false;
    public GameObject skipButton;

    void Start()
    {
        Invoke(nameof(LoadScene), delay);
    }

    void Update()
    {
        if (hasSwitched) return;

        bool keyboard = Input.anyKeyDown;
        bool mouse = Input.GetMouseButtonDown(0);

        if (keyboard || mouse)
        {
            skipButton.SetActive(true);
        }
    }

    public void LoadScene()
    {
        if (hasSwitched) return;

        hasSwitched = true;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void BackToMenu()
    {
        if (hasSwitched) return;

        hasSwitched = true;
        SceneManager.LoadScene("MainMenu");
    }
}