using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;

    bool timerStarted;
    const float timeLimitValue = 60;
    public float TimeValue { get; private set; }

    void Start()
    {
        TimeValue = timeLimitValue;
        timerText.text = string.Format("Time Left: {0}", timeLimitValue);
        Invoke("StartTimer", 3);
    }

    void Update()
    {
        if (timerStarted)
        {
            TimeValue -= Time.deltaTime;
            if (TimeValue <= 0)
                TimeValue = 0;

            var seconds = Mathf.RoundToInt(TimeValue);
            timerText.text = string.Format("Time Left: {0}", seconds);
        }
    }

    void StartTimer()
    {
        timerStarted = true;
    }
}
