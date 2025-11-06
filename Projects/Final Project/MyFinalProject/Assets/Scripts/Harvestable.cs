using UnityEngine;

public class Harvestable : MonoBehaviour
{
    public string cropName;

    // Optional: method called when player harvests
    public void OnHarvest()
    {
        Debug.Log($"{cropName} harvested!");
        Destroy(gameObject);
    }
}
