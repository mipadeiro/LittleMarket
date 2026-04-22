using UnityEngine;
using UnityEngine.InputSystem;

public class ClientOne : MonoBehaviour
{
    public BellRinging bellScript;
    public GameObject customerOne;
    public GameObject customerDialogue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartTransaction();
    }

    // Update is called once per frame
    void Update()
    {
        if (bellScript.hasRung == true)
        {
            EndTransaction();
        }
    }

    public void StartTransaction()
    {
        customerOne.SetActive(true);
        customerDialogue.SetActive(true);
    }

    public void EndTransaction()
    {
        customerOne.SetActive(false);
        customerDialogue.SetActive(false);
        bellScript.clientNumber = 2;
        bellScript.hasRung = false;
    }
}
