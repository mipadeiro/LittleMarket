/* using UnityEngine;
using UnityEngine.XR;
using TMPro;

public class ClientTimer : MonoBehaviour
{
    //timer
    public float maxTime = 180f;
    private float currentTime;
    public bool timerRunning;

    public float timeSpent;
    private bool hasStarted = false;

    //clock UI
    public RectTransform meterHand;
    public float startX= -635;
    public float endX = -417f;
    public TextMeshProUGUI timerText;

    public BellRinging2 bellScript;
    public MonoBehaviour clientScript;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (bellScript == null)
        {
            return;
        }

        if(bellScript.clientNumber == clientScript.clientID && !hasStarted)
        {
            maxTime = clientScript.timerMax;
            currentTime = maxTime;
            timerRunning = true;
            hasStarted = true;

            Debug.Log("Timer started");

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

        if(bellScript.hasRung == true && timerRunning)
        {
            timerRunning = false;
            OnTimerFinished();
        }
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
 */