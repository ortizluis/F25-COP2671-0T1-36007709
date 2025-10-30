using UnityEngine;

public class DayNightEvents : MonoBehaviour
{
    public TimeManager timeManager;

    public int sunriseHour = 6;
    public int sunsetHour = 18;

    private bool sunriseTriggered = false;
    private bool sunsetTriggered = false;

    private void Start()
    {
        // Auto-connect if on the same GameObject
        if (timeManager == null)
            timeManager = GetComponent<TimeManager>();
    }

    private void Update()
    {
        int currentHour = timeManager.hours;

        // Sunrise Event
        if (currentHour == sunriseHour && !sunriseTriggered)
        {
            sunriseTriggered = true;
            sunsetTriggered = false; // reset sunset
            OnSunrise();
        }

        // Sunset Event
        if (currentHour == sunsetHour && !sunsetTriggered)
        {
            sunsetTriggered = true;
            sunriseTriggered = false; // reset sunrise
            OnSunset();
        }
    }

    private void OnSunrise()
    {
        Debug.Log("🌅 Sunrise event triggered!");
        // Example: Brighten the scene, open shops, spawn NPCs
    }

    private void OnSunset()
    {
        Debug.Log("🌇 Sunset event triggered!");
        // Example: Darken lights, close shops, spawn different NPCs
    }
}
