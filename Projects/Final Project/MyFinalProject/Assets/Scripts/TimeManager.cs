using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public int minutes = 6;
    public int hours = 5;  // Start the day at 6:00 AM
    public float timeSpeed = 50; // 1 = normal, 2 = twice as fast, etc.
    private float timer;

    void Update()
    {
        // Accumulate time based on real seconds
        timer += Time.deltaTime * timeSpeed;

        // Every 1 second = 1 in-game minute (adjustable)
        if (timer >= 1f)
        {
            minutes++;
            timer = 0f;

            if (minutes >= 60)
            {
                minutes = 0;
                hours++;

                if (hours >= 24)
                {
                    hours = 0;
                }
            }
        }
    }

    public string GetTimeString()
    {
        return hours.ToString("00") + ":" + minutes.ToString("00");
    }
}
