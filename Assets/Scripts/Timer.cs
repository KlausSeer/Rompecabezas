using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float maxTime;
    private float remindingTime;
    public TextMeshProUGUI timerText;
    public bool won;

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Start()
    {
        won = false;
        remindingTime = maxTime;
        DisplayTime(remindingTime);
    }

    void Update()
    {
        if (!won)
        {
            remindingTime -= Time.deltaTime;
            if (remindingTime <= 0.0f)
            {
                remindingTime = 0.0f;
                DisplayTime(remindingTime);
                FindObjectOfType<juego>().Perder();
            }
            DisplayTime(remindingTime);
        }
    }
}
