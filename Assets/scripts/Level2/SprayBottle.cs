using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SprayBottle : MonoBehaviour
{
    public GameObject player;
    public GameObject sprayEffect;
    public GameObject dirtPrefab;
    public BellRinging2 bellRinging2;
    public LevelManager levelManager;
    public int dirtLevel = 10;
    public Vector3 spawnAreaMin = new Vector3(-11f, 0f, -1.6f);
    public Vector3 spawnAreaMax = new Vector3(-4.5f, 0f, 1.5f);
    public bool isSpraying = false;
    private bool previousHasRung = false;
    private readonly System.Collections.Generic.List<GameObject> spawnedDirt = new System.Collections.Generic.List<GameObject>();

    public bool isDirty = false;
    public int cleanedDirt = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(levelManager == null)
        {
            levelManager = FindFirstObjectByType<LevelManager>();
        }
        if (player == null)
        {
            player = levelManager.activeCharacter;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bellRinging2.hasRung && !previousHasRung)
        {
            AddDirt();
        }
        previousHasRung = bellRinging2.hasRung;
    }

    public void AddDirt()
    {
        for (int i = 0; i < dirtLevel; i++)
        {
            var position = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                spawnAreaMin.y,
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)
            );
            var dirt = Instantiate(dirtPrefab, position, Quaternion.identity);
            spawnedDirt.Add(dirt);
        }
        Debug.Log("dirty as hell out here");
        isDirty = true;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(isDirty == true)
            {
                cleanedDirt++;
            }
            sprayEffect.SetActive(true);
            isSpraying = true;
            isDirty = false;
            DestroyAllDirt();
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sprayEffect.SetActive(false);
            isSpraying = false;
        }
    }

    private void DestroyAllDirt()
    {
        for (int i = spawnedDirt.Count - 1; i >= 0; i--)
        {
            if (spawnedDirt[i] != null)
            {
                Destroy(spawnedDirt[i]);
            }
        }
        spawnedDirt.Clear();
    }
}
