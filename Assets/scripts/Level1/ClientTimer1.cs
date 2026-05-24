using UnityEngine;
using UnityEngine.XR;

public class ClientTimer1 : MonoBehaviour
{
    //timer
    public float maxTime = 120f;
    private float currentTime;
    public bool timerRunning;

    public float timeLeft;
    private bool hasStarted = false;

    //clock UI
    public RectTransform meterHand;
    public float startAngle = 90f;
    public float endAngle = -90f;

    public BellRinging1 bellScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(bellScript == null)
        {
            FindAnyObjectByType<BellRinging1>();
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

        if(bellScript.clientThreeActivated && !hasStarted)
        {
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

        UpdateHand();

        if(currentTime <= 0f)
        {
            currentTime = 0f;
            timerRunning = false;
            OnTimerFinished();
        }

        if(bellScript.hasRung)
        {
            timerRunning = false;
            OnTimerFinished();
        }
    }

    void UpdateHand()
    {
        float t = currentTime / maxTime;
        float angle = Mathf.Lerp(endAngle, startAngle, t);
        meterHand.localRotation = Quaternion.Euler(0, 0, angle);

    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    void OnTimerFinished()
    {
        timeLeft = maxTime - currentTime;
        Debug.Log("Client timed out at:" + timeLeft);
    }
}
