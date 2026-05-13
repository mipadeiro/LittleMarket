using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SprayBottle : MonoBehaviour
{
    public GameObject player;
    public GameObject sprayEffect;
    public GameObject dirtPrefab;
    public BellRinging2 bellRinging2;
    public int dirtLevel = 10;
    public Vector3 dirtSpace = new Vector3(10, 0, 10);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bellRinging2.hasRung == true)
        {
            for(int i = 0; i < dirtLevel; i++)
            {
                AddDirt();
            }
        }
    }

    public void AddDirt()
    {
        //var position = Vector3(Random.Range(-dirtSpace.x, dirtSpace.x), 0, Random.Range(-dirtSpace.z, dirtSpace.z));
        //Instantiate(dirtPrefab, position, Quaternion.identity);
        //Instantiate(dirtPrefab, player.transform.position + player.transform.forward * 2, Quaternion.identity);
        Debug.Log("dirty as hell out here");
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sprayEffect.SetActive(true);
            //Destroy(dirtPrefab);
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sprayEffect.SetActive(false);
        }
    }
}
