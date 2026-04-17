using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item :ScriptableObject
{
    public int itemID = 0;
    public string itemName = "New Item";
    public float value = 0f;
    public float weight = 0f;
    public GameObject prefab = null;
    public List<string> tags = new List<string>();
}