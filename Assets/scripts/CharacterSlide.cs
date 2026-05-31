using UnityEngine;

public class CharacterSlide : MonoBehaviour
{
    // Animator on another GameObject. Assign in the Inspector.
    public Animator targetAnimator;

    // The Trigger parameter name defined in the target Animator. Assign in the Inspector.
    public string triggerName = "";

    // Call this from a UI Button OnClick to start the animation on the target animator.
    public void PlayAnimation()
    {
        if (targetAnimator == null)
        {
            Debug.LogWarning("LevelsSlide: targetAnimator is not assigned.");
            return;
        }

        if (string.IsNullOrEmpty(triggerName))
        {
            Debug.LogWarning("LevelsSlide: triggerName is not set. Configure a Trigger parameter in the Animator and set its name here.");
            return;
        }

        targetAnimator.SetTrigger(triggerName);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
