using UnityEngine;

[CreateAssetMenu(fileName = "New Seed Packet", menuName = "Farming/Seed Packet")]
public class SeedPacket : ScriptableObject
{
    [Header("Crop Info")]
    public string cropName;

    [Header("Growth Settings")]
    [Tooltip("Sprites showing the crop’s appearance at each growth stage.")]
    public Sprite[] growthSprites;

    [Header("UI and Prefab")]
    [Tooltip("The image shown in the seed selection UI.")]
    public Sprite coverImage;

    [Tooltip("Prefab that appears when the crop is ready to harvest.")]
    public Harvestable harvestablePrefab;
}