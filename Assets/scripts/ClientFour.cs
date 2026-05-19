using UnityEngine;
using UnityEngine.InputSystem;

public class ClientFour : MonoBehaviour
{
    public BellRinging2 bellScript;
    public GameObject customerDialogue;
    public Animator bellAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartTransaction();
    }

    // Update is called once per frame
    void Update()
    {
        if (bellScript.clientNumber == 4 && bellScript.hasRung == true)
        {
            EndTransaction();
        }
    }

    public void StartTransaction()
    {
        customerDialogue.SetActive(true);
    }

    public void EndTransaction()
    {
        customerDialogue.SetActive(false);
        bellScript.clientNumber = 5;
        bellScript.hasRung = false;
        bellAnimator.SetBool("hasRung", false);
    }
}
