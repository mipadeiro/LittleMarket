using UnityEngine;
using UnityEngine.InputSystem;

public class ClientTwo : MonoBehaviour
{
    public BellRinging bellScript;
    public GameObject customerSprite;
    public GameObject customerDialogue;
    public GameObject customerItems;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ()
        if (bellScript.hasRung == true)
        {
            EndTransaction();
        }
    }

    public void StartTransaction()
    {
        customerItems.SetActive(true);
        customerSprite.SetActive(true);
        customerDialogue.SetActive(true);
    }

    public void EndTransaction()
    {
        customerItems.SetActive(false);
        customerSprite.SetActive(false);
        customerDialogue.SetActive(false);
        bellScript.hasRung = false;
        bellScript.clientNumber = 3;
    }
}
