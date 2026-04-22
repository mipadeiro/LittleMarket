using UnityEngine;
using UnityEngine.InputSystem;

public class ClientThree : MonoBehaviour
{
    public BellRinging bellScript;
    public GameObject customerThree;
    public GameObject customerDialogue;
    public GameObject logoImg;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bellScript.clientNumber == 3 && bellScript.hasRung == false)
        {
            StartTransaction();
        }

        if (bellScript.clientNumber == 3 && bellScript.hasRung == true)
        {
            EndTransaction();
        }
    }

    public void StartTransaction()
    {
        customerThree.SetActive(true);
        customerDialogue.SetActive(true);
    }

    public void EndTransaction()
    {
        customerDialogue.SetActive(false);
        bellScript.clientNumber = 4;
        logoImg.SetActive(true);
        bellScript.hasRung = false;
        customerThree.SetActive(false);
    }
}
