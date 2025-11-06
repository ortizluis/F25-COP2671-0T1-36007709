using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ToolbarController : MonoBehaviour
{
    [Header("Tool Buttons")]
    public Button hoeButton;
    public Button waterButton;
    public Button plantButton;
    public Button harvestButton;

    void Start()
    {
        // Assign button listeners
        hoeButton.onClick.AddListener(OnHoe);
        waterButton.onClick.AddListener(OnWater);
        plantButton.onClick.AddListener(OnSeed);
        harvestButton.onClick.AddListener(OnGather);
    }

    public void OnHoe()
    {
        Debug.Log("Hoe tool selected!");
        // Trigger hoe tool logic here
    }

    public void OnWater()
    {
        Debug.Log("Water tool selected!");
        // Trigger water tool logic here
    }

    public void OnSeed()
    {
        Debug.Log("Plant tool selected!");
        // Trigger planting logic here
    }

    public void OnGather()
    {
        Debug.Log("Harvest tool selected!");
        // Trigger harvesting logic here
    }
}
