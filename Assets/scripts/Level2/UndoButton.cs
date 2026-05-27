using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UndoButton : MonoBehaviour
{
    public TextMeshProUGUI categoryText;
    public BookMenu bookScript;
    public ScannerScript scannerScript;

    private void Awake()
    {
        if (bookScript == null)
        {
            bookScript = FindAnyObjectByType<BookMenu>();
            if (bookScript == null)
            {
                Debug.LogWarning("BookMenu not found");
            }
        }

        if (scannerScript == null)
        {
            scannerScript = FindAnyObjectByType<ScannerScript>();
            if (scannerScript == null)
            {
                Debug.LogWarning("ScannerScript not found");
            }
         }
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hovering undo button");
            bookScript.hoveredCategory = categoryText.text;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("left undo button");
            bookScript.hoveredCategory = null;
        }
    }
}