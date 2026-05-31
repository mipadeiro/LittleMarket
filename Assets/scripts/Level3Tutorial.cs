using UnityEngine;
using UnityEngine.InputSystem;

public class Level3Tutorial : MonoBehaviour
{
    public GameObject tutorialBG;
    public TMPro.TextMeshProUGUI tutorialText;
    public NewPlayerController3 newPlayerController;
    public BellRinging3 bellScript;
    public ScannerScript3 scannerScript;
    public SprayBottle3 sprayScript;
    public GameObject tutorialController;
    public RegisterItemController3 tutorialItemScript;
    public GameObject tutorialItem1;
    public GameObject tutorialItem2;

    public GameObject arrowGrab1;
    public GameObject arrowGrab2;
    public GameObject arrowBag;
    public GameObject mouseLeft;
    public GameObject buttonEast;

    private enum TutorialStep {Grab, Bag, Completed }
    private enum DeviceType { Unknown, Keyboard, Gamepad }

    private TutorialStep currentStep = TutorialStep.Grab;
    private DeviceType currentDevice = DeviceType.Unknown;

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (newPlayerController == null)
            newPlayerController = FindFirstObjectByType<NewPlayerController3>();

        if (scannerScript == null)
            scannerScript = FindFirstObjectByType<ScannerScript3>();

        if (sprayScript == null)
            sprayScript = FindFirstObjectByType<SprayBottle3>();

        tutorialBG.SetActive(true);
        currentStep = TutorialStep.Grab;
        newPlayerController.pickedUpThisStep = false;
        UpdateTutorialText();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStep == TutorialStep.Grab && newPlayerController != null && (newPlayerController.heldObject == tutorialItem1 || newPlayerController.heldObject == tutorialItem2))
        {
            AdvanceStep();
            return;
        }

        if (currentStep == TutorialStep.Bag && scannerScript != null && (tutorialItem1.GetComponent<BasicItemController3>().correctCart == true || tutorialItem2.GetComponent<BasicItemController3>().correctCart == true))
        {
            AdvanceStep();
            return;
        }
    }

    public void OnPickUp(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        // The actual pickup success is tracked in NewPlayerController.
        // The tutorial will advance when that flag becomes true.
        if (currentStep != TutorialStep.Grab)
            return;
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        //UpdateCurrentDevice(context.control.device);

        if (currentStep == TutorialStep.Completed)
        {
            Debug.Log("Tutorial completed");
            if (tutorialController != null)
            {
                mouseLeft.SetActive(false);
                buttonEast.SetActive(false);
                tutorialController.SetActive(false);
            }
            else
            {
                Debug.LogError("tutorialController reference is null!");
            }
        }
    }

    public void AdvanceStep()
    {
        currentStep++;
        if (currentStep == TutorialStep.Completed)
        {
            UpdateTutorialText();
            return;
        }

        arrowGrab1.SetActive(false);
        arrowGrab2.SetActive(false);
        arrowBag.SetActive(false);
        mouseLeft.SetActive(false);
        buttonEast.SetActive(false);

        newPlayerController.pickedUpThisStep = false;

        UpdateTutorialText();
    }

    private void UpdateTutorialText()
    {
        if (tutorialText == null)
            return;

        string actionText = "";
        switch (currentStep)
        {
            case TutorialStep.Grab:
                actionText = "It seems our brave hero has encountered a new kind of item! The cold items, marked by a snowflake. As usual, they must be picked up and scanned.";
                arrowGrab1.SetActive(true);
                arrowGrab2.SetActive(true);
                break;
            case TutorialStep.Bag:
                actionText = "After scanning, our protagonist must store it in the proper container, to remain cold.";
                arrowBag.SetActive(true);
                break;
            case TutorialStep.Completed:
                actionText = "A simple task for our capable hero! Any items without a snowflake, must be stored in the regular basket.";
                mouseLeft.SetActive(true);
                buttonEast.SetActive(true);
                break;
        }

        tutorialText.text = actionText;
    }
}
