using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;


public class BellRinging : MonoBehaviour
{
    public bool hasRung;

    public int clientNumber;
    public GameObject clientTwo;
    public GameObject clientThree;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clientNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (clientNumber == 2 && hasRung == false)
        {
            clientTwo.SetActive(true);
        }

        if (clientNumber == 3 && hasRung == false)
        {
            clientThree.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasRung = true;
            Debug.Log("Ding!");
            //add sfx
            clientNumber++;
        }
    }
        
}
