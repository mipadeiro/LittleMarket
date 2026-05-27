using UnityEngine;

// Simple script to attach to each Button GameObject.
// In the Button OnClick() assign this GameObject and choose ButtonActivate -> ActivateTarget().
public class ButtonActivate : MonoBehaviour
{
    public GameObject target; // the GameObject this button should activate

    // tracks currently active target across all buttons
    private static GameObject activeTarget;

    void Awake()
    {
        if (target == null)
            target = gameObject; // default to self if not set
    }

    // Call from Button.OnClick()
    public void ActivateTarget()
    {
        if (target == null)
        {
            Debug.LogWarning("ButtonActivate: no target assigned.");
            return;
        }

        // if this is already active, do nothing
        if (activeTarget == target)
            return;

        // deactivate previous
        if (activeTarget != null)
            activeTarget.SetActive(false);

        // activate this
        target.SetActive(true);
        activeTarget = target;
    }
}
