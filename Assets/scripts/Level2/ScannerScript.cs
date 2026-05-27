using UnityEngine;
using System.Collections.Generic;

public class ScannerScript : MonoBehaviour
{
    //lists of present items
    public List<GameObject> itemsInScanner = new List<GameObject>();
    //other scripts
    public BookMenu bookMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Pickup")) return;

        if (other.CompareTag("Pickup"))
        {
            //add gameobject to list
            Debug.Log("Scanner: new item entered scanner: " + other.gameObject.name + " (parent=" + (other.transform.parent? other.transform.parent.name : "null") + ")");
            itemsInScanner.Add(other.gameObject);
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            RemoveItem(other.gameObject);
        }
    }

    public void RemoveItem(GameObject item)
    {
        if (!itemsInScanner.Contains(item))
        {
            return;
        }
        
        //remove gameobject from list
        itemsInScanner.Remove(item);

        Debug.Log("Scanner: item removed from scanner: " + item.name + " (remaining count=" + itemsInScanner.Count + ")");
        
    }   
}
