using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;

    const float timeLimitValue = 3f;
    public float TimeValue { get; private set; }
    bool timerStarted;

    void Start()
    {
        TimeValue = timeLimitValue;
        timerText.text = "Time Left: " + timeLimitValue;
        Invoke("StartTimer", 3f);
    }

    void Update()
    {
        if (timerStarted)
        {
            TimeValue -= Time.deltaTime;
            if (TimeValue <= 0)
                TimeValue = 0;

            var seconds = Mathf.RoundToInt(TimeValue);
            timerText.text = "Time Left: " + seconds;
        }
    }

    void StartTimer()
    {
        timerStarted = true;
    }
}
