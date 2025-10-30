using UnityEngine;

public class DayNightController : MonoBehaviour
{
    [Header("Lighting")]
    public Light worldLight; // 3D Directional Light | 2D Global Light 2D component

    [Header("Light Settings")]
    public Gradient lightColorOverDay;
    public AnimationCurve lightIntensityOverDay;

    void Update()
    {
     
    }
}

