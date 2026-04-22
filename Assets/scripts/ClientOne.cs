using UnityEngine;
using UnityEngine.InputSystem;

public class ClientOne : MonoBehaviour
{
    public BellRinging bellScript;
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
        customerDialogue.SetActive(true);
    }

    public void EndTransaction()
    {
        customerDialogue.SetActive(false);
        bellScript.clientNumber = 2;
        bellScript.hasRung = false;
    }
}
