using UnityEngine;
using UnityEngine.InputSystem;

public class Level1Tutorial : MonoBehaviour
{
    public GameObject tutorialBG;
    public TMPro.TextMeshProUGUI tutorialText;
    public NewPlayerController newPlayerController;
    public BellRinging bellScript;
    public GameObject scanner;
    public GameObject bag;
    public GameObject tutorialController;
    public FirstItem tutorialItem;

    private enum TutorialStep { Greeting,Move, Jump, PickUp, Drop, Scan, Bag, Bell, Completed }
    private enum DeviceType { Unknown, Keyboard, Gamepad }

    private TutorialStep currentStep = TutorialStep.Move;
    private DeviceType currentDevice = DeviceType.Unknown;
    private bool jumpPressed;
    private bool scannedThisStep;


    void Start()
    {
        if (newPlayerController == null)
            newPlayerController = FindFirstObjectByType<NewPlayerController>();

        tutorialBG.SetActive(true);
        currentStep = TutorialStep.Greeting;
        jumpPressed = false;
        UpdateTutorialText();
    }

    void Update()
    {
        if (currentStep == TutorialStep.PickUp && newPlayerController != null && newPlayerController.pickedUpThisStep)
        {
            AdvanceStep();
            return;
        }

        if (currentStep == TutorialStep.Drop && newPlayerController != null && newPlayerController.droppedThisStep)
        {
            AdvanceStep();
            return;
        }

        if (currentStep == TutorialStep.Scan && scannedThisStep)
        {
            AdvanceStep();
            return;
        }

        if (currentStep == TutorialStep.Bag && tutorialItem != null && tutorialItem.isInCart)
        {
            AdvanceStep();
            return;
        }

        if (currentStep == TutorialStep.Bell && bellScript.clientNumber == 2)
        {
            AdvanceStep();
            return;
        }
    }

    public void OnItemScanned()
    {
        if (currentStep == TutorialStep.Scan)
        {
            scannedThisStep = true;
        }
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        UpdateCurrentDevice(context.control.device);
        if (currentStep == TutorialStep.Greeting)
            AdvanceStep();

        UpdateCurrentDevice(context.control.device);
        if (currentStep == TutorialStep.Completed)
            tutorialController.SetActive(false);
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        UpdateCurrentDevice(context.control.device);
        if (currentStep == TutorialStep.Greeting)
            AdvanceStep();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        UpdateCurrentDevice(context.control.device);
        Vector2 moveValue = context.ReadValue<Vector2>();

        if (currentStep != TutorialStep.Move)
            return;

        if (moveValue.sqrMagnitude > 0.01f)
        {
            AdvanceStep();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        UpdateCurrentDevice(context.control.device);

        if (currentStep != TutorialStep.Jump)
            return;

        jumpPressed = true;
        AdvanceStep();
    }

    public void OnPickUp(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        UpdateCurrentDevice(context.control.device);

        // The actual pickup success is tracked in NewPlayerController.
        // The tutorial will advance when that flag becomes true.
        if (currentStep != TutorialStep.PickUp)
            return;
    }

    public void OnDrop(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        UpdateCurrentDevice(context.control.device);

        if (currentStep != TutorialStep.Drop)
            return;
    }

    private void UpdateCurrentDevice(InputDevice device)
    {
        if (device is Gamepad)
            currentDevice = DeviceType.Gamepad;
        else
            currentDevice = DeviceType.Keyboard;

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
                actionText = "Our brave hero's first day as a shopkeeper! How exciting, but also daunting";
                break;
            case TutorialStep.Move:
                actionText = currentDevice == DeviceType.Gamepad
                    ? "Thankfully, our protagonist is capable of impressive physical feats. Like walking, with the left joystick."
                    : "Thankfully, our protagonist is capable of impressive physical feats. Like walking, with WASD.";
                break;
            case TutorialStep.Jump:
                actionText = currentDevice == DeviceType.Gamepad
                    ? "And that's not all! Their athleticism (the south button) allows them to jump great heights."
                    : "And that's not all! Their athleticism (the spacebar) allows them to jump great heights.";
                break;
            case TutorialStep.PickUp:
                actionText = currentDevice == DeviceType.Gamepad
                    ? "With their significant strength, and the east button,they can pick up almost anything! Even if it's much bigger than them. "
                    : "With their significant strength, and the left mouse button,they can pick up almost anything! Even if it's much bigger than them. ";
                break;
            case TutorialStep.Drop:
                actionText = currentDevice == DeviceType.Gamepad
                    ? "And, of course, swiftly put them down. (With the east button again)."
                    : "And, of course, swiftly put them down. (With the left mouse button again).";
                break;
            case TutorialStep.Scan:
                actionText = "Now, our intrepid shopkeep can use all of these skills together to register items to the book. They need only set the item down on the symbol etched into the table.";
                break;
            case TutorialStep.Bag:
                actionText = "Lastly, they must set the registered item into the client's basket.";
                break;
            case TutorialStep.Bell:
                actionText = "Now that all the customer's items have been safely put away, the hero shall end the transaction by jumping on the bell to ring it.";
                break;
            case TutorialStep.Completed:
                actionText = "What an aweinspiring performance! This shop is truly in safe hands. Now it is up to our hero to use their skills for the rest of the day!";
                break;
        }

        tutorialText.text = actionText;
    }

    private void AdvanceStep()
    {
        currentStep++;
        if (currentStep == TutorialStep.Completed)
        {
            UpdateTutorialText();
            return;
        }

        jumpPressed = false;
        scannedThisStep = false;
        if (newPlayerController != null)
        {
            newPlayerController.pickedUpThisStep = false;
            newPlayerController.droppedThisStep = false;
        }

        UpdateTutorialText();
    }
}
