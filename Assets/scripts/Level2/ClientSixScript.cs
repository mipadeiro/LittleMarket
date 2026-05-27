using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ClientSixScript : MonoBehaviour
{
    public BellRinging2 bellScript;
    public GameObject customerDialogue;
    public Animator bellAnimator;
    public int clientID = 6;
    private bool hasEnded = false;


    //timer things
    public float maxTime = 180f;
    private float currentTime;
    public bool timerRunning;
    public float timeSpent;
    private bool hasStarted = false;
    //clock UI
    public RectTransform meterHand;
    public float startX= -1351;
    public float endX = -304f;
    public TextMeshProUGUI timerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(bellScript == null)
        {
            FindAnyObjectByType<BellRinging2>();
            if(bellScript == null)
            {
                Debug.Log("can't find bellscript");
            }
        }

        StartTransaction();
    }

    // Update is called once per frame
    void Update()
    {
        if(bellScript.clientNumber != clientID)
        {
            return;
        }

        if (bellScript == null)
        {
            return;
        }

        if(bellScript.clientNumber == clientID && !hasStarted)
        {
            currentTime = maxTime;
            timerRunning = true;
            hasStarted = true;
            hasEnded = false;

            Debug.Log("Timer started");

        }

        if (bellScript.clientNumber == 6 && bellScript.hasRung == true)
        {
            EndTransaction();

            if(timerRunning)
            {
                timerRunning = false;
                OnTimerFinished();
            }
        }

        if(!timerRunning)
        {
            return;
        }

        currentTime -= Time.deltaTime;

        UpdateTimerText();
        UpdateHand();

        if(currentTime <= 0f)
        {
            currentTime = 0f;
            timerRunning = false;
            OnTimerFinished();
        }
    }

    public void StartTransaction()
    {
        customerDialogue.SetActive(true);
    }

    public void EndTransaction()
    {
        if (hasEnded)
        {
            return;
        }
        hasEnded = true;

        customerDialogue.SetActive(false);
        bellScript.clientNumber = 7;
        bellScript.hasRung = false;
        bellAnimator.SetBool("hasRung", false);
    }

        void UpdateHand()
    {
        float t = currentTime / maxTime;
        float x = Mathf.Lerp(endX, startX, t);
        meterHand.anchoredPosition = new Vector2(x, meterHand.anchoredPosition.y);
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    void OnTimerFinished()
    {
        timeSpent = maxTime - currentTime;
        Debug.Log("Client timed out at:" + timeSpent);
    }
}
