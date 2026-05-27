using UnityEngine;

// Attach this to the GameObject you want to activate (recommended) or any other helper object.
// In the Button OnClick, drag the same GameObject and choose ActivateOnClick -> Activate().
public class ActivateOnClick : MonoBehaviour
{
    // The target GameObject to activate. If left empty, this script's GameObject is used.
    public GameObject target;

    // If true, clicking the button for an already-active target will deactivate it (toggle behavior).
    public bool toggleOnSame = false;

    // Tracks the currently active target across all instances
    private static GameObject activeTarget;

    void Awake()
    {
        if (target == null)
            target = gameObject;
    }

    // Call this from a UI Button OnClick()
    public void Activate()
    {
        if (target == null)
        {
            Debug.LogWarning("ActivateOnClick: no target assigned and no default available.");
            return;
        }

        // If this target is already active
        if (activeTarget == target)
        {
            if (toggleOnSame)
            {
                target.SetActive(false);
                activeTarget = null;
            }
            return;
        }

        // Deactivate previous active target
        if (activeTarget != null)
        {
            activeTarget.SetActive(false);
        }

        // Activate this one and track it
        target.SetActive(true);
        activeTarget = target;
    }

    // Public static helper to deactivate the currently active target from anywhere
    public static void DeactivateCurrent()
    {
        if (activeTarget != null)
        {
            activeTarget.SetActive(false);
            activeTarget = null;
        }
    }

    // Instance wrapper so you can attach this script once to a manager GameObject
    // and call DeactivateCurrentInstance from a Button OnClick in the Inspector.
    public void DeactivateCurrentInstance()
    {
        DeactivateCurrent();
    }
}
