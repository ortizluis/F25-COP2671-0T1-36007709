using UnityEngine;

[RequireComponent(typeof(Light))]
public class DayNightLighting : MonoBehaviour
{
    public TimeManager timeManager;      // Reference to your TimeManager
    public Light directionalLight;       // Directional light representing the sun
    public AnimationCurve intensityCurve; // Controls light intensity over 24 hours
    public Gradient colorGradient;       // Controls light color over 24 hours

    void Start()
    {
        if (timeManager == null)
            timeManager = GetComponent<TimeManager>();

        if (directionalLight == null)
            directionalLight = FindFirstObjectByType<Light>();
    }

    void Update()
    {
        if (timeManager == null || directionalLight == null) return;

        // Convert time to 0-1 range (0 = 0:00, 1 = 24:00)
        float time01 = (timeManager.hours + timeManager.minutes / 60f) / 24f;

        // Set intensity and color based on AnimationCurve & Gradient
        directionalLight.intensity = intensityCurve.Evaluate(time01);
        directionalLight.color = colorGradient.Evaluate(time01);

        // Optional: rotate light to simulate sun movement
        directionalLight.transform.rotation = Quaternion.Euler((time01 * 360f) - 90f, 170f, 0f);
    }
}
