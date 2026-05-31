using UnityEngine;
using UnityEngine.InputSystem;

public class Level2Tutorial : MonoBehaviour
{
    public GameObject tutorialBG;
    public TMPro.TextMeshProUGUI tutorialText;
    public NewPlayerController newPlayerController;
    public BellRinging2 bellScript;
    public ScannerScript scannerScript;
    public SprayBottle sprayScript;
    public GameObject tutorialController;
    public RegisterItemController tutorialItemScript;
    public GameObject tutorialItem;

    public GameObject arrowGrab;
    public GameObject arrowScan;
    public GameObject arrowRegister;
    public GameObject arrowSpray;
    public GameObject mouseLeft;
    public GameObject buttonEast;

    private enum TutorialStep { Greeting , Grab, Scan, Register, Instructions, Wait, Spray, Completed }
    private enum DeviceType { Unknown, Keyboard, Gamepad }

    private TutorialStep currentStep = TutorialStep.Greeting;
    private DeviceType currentDevice = DeviceType.Unknown;

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (newPlayerController == null)
            newPlayerController = FindFirstObjectByType<NewPlayerController>();

        if (scannerScript == null)
            scannerScript = FindFirstObjectByType<ScannerScript>();

        if (sprayScript == null)
            sprayScript = FindFirstObjectByType<SprayBottle>();

        tutorialBG.SetActive(true);
        currentStep = TutorialStep.Greeting;
        newPlayerController.pickedUpThisStep = false;
        UpdateTutorialText();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStep == TutorialStep.Grab && newPlayerController != null && newPlayerController.heldObject == tutorialItem)
        {
            AdvanceStep();
            return;
        }

        if (currentStep == TutorialStep.Scan && scannerScript != null && scannerScript.itemsInScanner.Contains(tutorialItem))
        {
            AdvanceStep();
            return;
        }

        if (currentStep == TutorialStep.Register && tutorialItemScript != null && tutorialItemScript.correctScan == true)
        {
            AdvanceStep();
            return;
        }

        if (currentStep == TutorialStep.Wait && bellScript != null && bellScript.clientNumber == 5)
        {
            AdvanceStep();
            return;
        }

        if (currentStep == TutorialStep.Spray && sprayScript.cleanedDirt == 1)
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

        if (currentStep == TutorialStep.Greeting)
            AdvanceStep();

        if (currentStep == TutorialStep.Instructions)
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
        currentStep++;
        if (currentStep == TutorialStep.Completed)
        {
            UpdateTutorialText();
            return;
        }

        arrowGrab.SetActive(false);
        arrowScan.SetActive(false);
        arrowRegister.SetActive(false);
        arrowSpray.SetActive(false);
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
            case TutorialStep.Greeting:
                actionText = "Welcome again, hero! Today we shall tackle the scanning of fruits, vegetables, mushrooms and even seaweed! ";
                break;
            case TutorialStep.Grab:
                actionText = "To properly register them, the player must first grab the intended object.";
                arrowGrab.SetActive(true);
                break;
            case TutorialStep.Scan:
                actionText = "Then, set it down onto the magical symbol.";
                arrowScan.SetActive(true);
                break;
            case TutorialStep.Register:
                actionText = "Now, our hero must jump on the book, and click above the button that matches the category of the item. Then, confirm the type of item. If the item still isn't listed, try picking it back and dropping it again.";
                arrowRegister.SetActive(true);
                buttonEast.SetActive(true);
                mouseLeft.SetActive(true);
                break;
            case TutorialStep.Instructions:
                actionText = "Such natural talent! Now our protagonist is prepared to tackle any challenge thrown their way.";
                break;
            case TutorialStep.Wait:
                actionText = ":p";
                tutorialBG.SetActive(false);
                break;
            case TutorialStep.Spray:
                actionText = "Great heavens! It seems the previous client's items have left some dirt behind. Thankfully, our hero easily conquers this obstacle by jumping on the cleaning spray!";
                tutorialBG.SetActive(true);
                arrowSpray.SetActive(true);
                break;
            case TutorialStep.Completed:
                actionText = "Very impressive! There truly is no better shopkeep in all the land.";
                arrowSpray.SetActive(false);
                break;
        }

        tutorialText.text = actionText;
    }
}
