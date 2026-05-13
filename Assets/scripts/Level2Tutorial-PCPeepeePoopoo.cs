using UnityEngine;
using UnityEngine.InputSystem;

public class Level2Tutorial : MonoBehaviour
{
    public GameObject tutorialBG;
    public TMPro.TextMeshProUGUI tutorialText;
    public NewPlayerController newPlayerController;
    public BellRinging bellScript;
    public GameObject scanner;
    public GameObject bag;
    public GameObject tutorialController;
    public FirstItem tutorialItem;

    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;
    public GameObject mouseImg;
    public GameObject joystickImg;
    public GameObject eastButtonImg;
    public GameObject uiControlsImg;

    private enum TutorialStep { Greeting , Grab, Scan, Instructions, Spray, Completed }
    private enum DeviceType { Unknown, Keyboard, Gamepad }

    private TutorialStep currentStep = TutorialStep.Greeting;
    private DeviceType currentDevice = DeviceType.Unknown;
    private bool pickedUpThisStep;
    private bool scannedThisStep;
    private bool sprayedThisStep;

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (newPlayerController == null)
            newPlayerController = FindFirstObjectByType<NewPlayerController>();

        tutorialBG.SetActive(true);
        currentStep = TutorialStep.Greeting;
        pickedUpThisStep = false;
        scannedThisStep = false;
        sprayedThisStep = false;
        //UpdateTutorialText();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStep == TutorialStep.Grab && newPlayerController != null && pickedUpThisStep)
        {
            AdvanceStep();
            return;
        }

        if (currentStep == TutorialStep.Scan && newPlayerController != null && scannedThisStep)
        {
            AdvanceStep();
            return;
        }

        if (currentStep == TutorialStep.Spray && sprayedThisStep)
        {
            AdvanceStep();
            return;
        }
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        //UpdateCurrentDevice(context.control.device);

        if (currentStep == TutorialStep.Greeting)
            AdvanceStep();

        if (currentStep == TutorialStep.Completed)
        {
            Debug.Log("Tutorial completed");
            if (tutorialController != null)
                tutorialController.SetActive(false);
            else
                Debug.LogError("tutorialController reference is null!");
        }
    }

    public void AdvanceStep()
    {
        return; // Temporarily disable tutorial progres
    }
}
