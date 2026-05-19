using UnityEngine;
using UnityEngine.InputSystem;

public class ClientSeven : MonoBehaviour
{
    public BellRinging2 bellScript;
    public GameObject customerDialogue;
    public Animator bellAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bellScript.clientNumber == 7 && bellScript.hasRung == false)
        {
            StartTransaction();
        }

        if (bellScript.clientNumber == 7 && bellScript.hasRung == true)
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
        bellScript.clientNumber = 8;
        bellAnimator.SetBool("hasRung", false);
    }
}
