using UnityEngine;

public class ActivateCharacter : MonoBehaviour
{
    public Transform characterLocation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterLocation.position = new Vector3(0.116999999f,-0.920000017f,-0.586000025f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
