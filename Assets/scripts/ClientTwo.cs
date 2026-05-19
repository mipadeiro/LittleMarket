using UnityEngine;
using UnityEngine.InputSystem;

public class ClientTwo : MonoBehaviour
{
    public BellRinging1 bellScript;
    public GameObject customerDialogue;
    public Animator bellAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bellScript.clientNumber == 2 && bellScript.hasRung == false)
        {
            StartTransaction();
        }

        if (bellScript.clientNumber == 2 && bellScript.hasRung == true)
        {
            for (int i = 0; i < 1; i++)
            {
                EndTransaction();
            }
        }
    }

    public void StartTransaction()
    {
        customerDialogue.SetActive(true);
    }

    public void EndTransaction()
    {
        customerDialogue.SetActive(false);
        bellScript.clientNumber = 3;
        bellAnimator.SetBool("hasRung", false);
    }
}
