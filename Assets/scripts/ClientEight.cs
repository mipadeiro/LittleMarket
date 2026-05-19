using UnityEngine;
using UnityEngine.InputSystem;

public class ClientEight : MonoBehaviour
{
    public BellRinging2 bellScript;
    public GameObject customerEight;
    public GameObject customerDialogue;
    public Animator bellAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bellScript.clientNumber == 8 && bellScript.hasRung == false)
        {
            StartTransaction();
        }

        if (bellScript.clientNumber == 8 && bellScript.hasRung == true)
        {
            for (int i = 0; i < 1; i++)
            {
                EndTransaction();
            }
        }
    }

    public void StartTransaction()
    {
        customerEight.SetActive(true);
        customerDialogue.SetActive(true);
    }

    public void EndTransaction()
    {
        customerDialogue.SetActive(false);
        bellScript.clientNumber = 9;
        customerEight.SetActive(false);
        bellAnimator.SetBool("hasRung", false);
    }
}
