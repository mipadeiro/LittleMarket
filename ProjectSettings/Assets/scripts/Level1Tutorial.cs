using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class Level1Tutorial : MonoBehaviour
{
    public GameObject tutorialBG;
    public TMPro.TextMeshProUGUI tutorialText;
    public PlayerInput playerInput;
    public GameObject scanTrigger;

    bool movementDetected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //check for control type? maybe not
        tutorialBG.SetActive(true);

        MoveTutorial();

        //jumping tutorial
        //pickup tutorial
        //drop tutorial
        //scan tutorial
        //bag tutorial
        //ring bell
        //second client start
        //third client has timer
    }

    public void MoveTutorial()
    {
        //initial tutorial for movement
        if (Keyboard.current != null)
        {
            tutorialText.text = "Our brave protagonist's first day as a shopkeeper. How exciting! And also daunting. But our hero can do anything! Like walking, with WASD.";
        }
        else if (Gamepad.current != null)
        {
            tutorialText.text = "Our brave protagonist's first day as a shopkeeper. How exciting! And also daunting. But our hero can do anything! Like walking, with the Left Joystick.";
        }

        playerInput.onActionTriggered += context =>
        {
            if (!movementDetected && context.action.name == "Move" && context.performed)
            {
                movementDetected = true;
                JumpTutorial();
            }
        };

    }

    public void JumpTutorial()
    {
        if (Keyboard.current != null)
        {
            tutorialText.text = "Very impressive! Our hero is also gifted with a talent for jumping, with the spacebar.";
        }
        else if (Gamepad.current != null)
        {
            tutorialText.text = "Very impressive! Our hero is also gifted with a talent for jumping, with the south button.";
        }
        playerInput.onActionTriggered += context =>
        {
            if (context.action.name == "Jump" && context.performed)
            {
                PickupTutorial();
            }
        };
    }

    public void PickupTutorial()
    {
        if (Keyboard.current != null)
        {
            tutorialText.text = "And that's not all, with their incredible strength (and the Left Mouse Button) they can pick up any object, no matter the size!.";
        }
        else if (Gamepad.current != null)
        {
            tutorialText.text = "And that's not all, with their incredible strength (and the East Button) they can pick up any object, no matter the size!.";
        }
        playerInput.onActionTriggered += context =>
        {
            if (context.action.name == "Pickup" && context.performed)
            {
                DropTutorial();
            }
        };
    }

    public void DropTutorial()
    {
        if (Keyboard.current != null)
        {
            tutorialText.text = "And swiftly put them down with the Right Mouse Button.";
        }
        else if (Gamepad.current != null)
        {
            tutorialText.text = "And swiftly put them down with the West Button.";
        }
        playerInput.onActionTriggered += context =>
        {
            if (context.action.name == "Drop" && context.performed)
            {
                ScanTutorial();
            }
        };
    }
    public void ScanTutorial()
    {
        if (Keyboard.current != null)
        {
            tutorialText.text = "The most important thing as a shopkeeper";
        }
        else if (Gamepad.current != null)
        {
            tutorialText.text = "And of course, the most important skill of all, scanning items with the north button.";
        }
        //find held item and check if isscanned is true, move on to bagging
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
