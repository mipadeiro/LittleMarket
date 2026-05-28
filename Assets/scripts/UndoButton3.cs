using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UndoButton3 : MonoBehaviour
{
    public TextMeshProUGUI categoryText;
    public BookMenu3 bookScript;
    public ScannerScript3 scannerScript;

    private void Awake()
    {
        if (bookScript == null)
        {
            bookScript = FindAnyObjectByType<BookMenu3>();
            if (bookScript == null)
            {
                Debug.LogWarning("BookMenu not found");
            }
        }

        if (scannerScript == null)
        {
            scannerScript = FindAnyObjectByType<ScannerScript3>();
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