using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;


public class BellRinging : MonoBehaviour
{
    public bool hasRung;

    public int clientNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clientNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasRung = true;
            Debug.Log("Ding!");
            //add sfx
            clientNumber++;
        }
    }
        
}
