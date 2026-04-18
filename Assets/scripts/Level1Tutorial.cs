using UnityEngine;
using UnityEngine.InputSystem;

public class Level1Tutorial : MonoBehaviour
{
    public GameObject tutorialBG;
    public TMPro.TextMeshProUGUI tutorialText;
    public NewPlayerController newPlayerController;

    private enum TutorialStep { Move, Jump, PickUp, Drop, Completed }
    private enum DeviceType { Unknown, Keyboard, Gamepad }

    private TutorialStep currentStep = TutorialStep.Move;
    private DeviceType currentDevice = DeviceType.Unknown;
    private bool jumpPressed;

    void Start()
    {
        if (newPlayerController == null)
            newPlayerController = FindFirstObjectByType<NewPlayerController>();

        tutorialBG.SetActive(true);
        currentStep = TutorialStep.Move;
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
            case TutorialStep.Move:
                actionText = currentDevice == DeviceType.Gamepad
                    ? "Use the left stick to move."
                    : "Use WASD or arrow keys to move.";
                break;
            case TutorialStep.Jump:
                actionText = currentDevice == DeviceType.Gamepad
                    ? "Press the A (south) button to jump."
                    : "Press Space to jump.";
                break;
            case TutorialStep.PickUp:
                actionText = currentDevice == DeviceType.Gamepad
                    ? "Press the pickup button to grab an item."
                    : "Press the pickup key to grab an item.";
                break;
            case TutorialStep.Drop:
                actionText = currentDevice == DeviceType.Gamepad
                    ? "Press the drop button to release the item."
                    : "Press the drop key to release the item.";
                break;
            case TutorialStep.Completed:
                actionText = "Great job! You completed the tutorial.";
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
        if (newPlayerController != null)
        {
            newPlayerController.pickedUpThisStep = false;
            newPlayerController.droppedThisStep = false;
        }

        UpdateTutorialText();
    }
}
