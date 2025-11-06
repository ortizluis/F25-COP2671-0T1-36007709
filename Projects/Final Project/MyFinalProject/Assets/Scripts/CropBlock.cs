using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class CropBlock
{
    public Vector2Int gridPosition;
    public Vector3 worldPosition;

    // --- Crop Growth Fields ---
    public SeedPacket plantedSeed;      // Reference to SeedPacket data
    public int currentGrowthStage = 0;  // 0–3 (4 total stages)
    public float growthTimer = 0f;      // Time since last growth stage

    // --- Soil States ---
    public bool isTilled = false;
    public bool isWatered = false;
    public bool hasCrop = false;

    // Reference to the tilemap for updating visuals
    private Tilemap tilemap;

    public CropBlock(Vector2Int gridPos, Vector3 worldPos)
    {
        gridPosition = gridPos;
        worldPosition = worldPos;
    }

    // Initialize with tilemap reference
    public void Initialize(Tilemap map)
    {
        tilemap = map;
    }

    // ----------------------------------------------------------
    // INTERACTIONS
    // ----------------------------------------------------------

    public void TillSoil(Tile tilledSoilTile)
    {
        if (!isTilled)
        {
            isTilled = true;
            tilemap.SetTile((Vector3Int)gridPosition, tilledSoilTile);
        }
    }

    public void WaterSoil()
    {
        if (isTilled && !isWatered)
        {
            isWatered = true;
            Debug.Log($"Soil at {gridPosition} watered.");
        }
    }

    public void PlantSeed(SeedPacket seed)
    {
        if (isTilled && !hasCrop && seed != null)
        {
            plantedSeed = seed;
            hasCrop = true;
            currentGrowthStage = 0;
            growthTimer = 0f;
            UpdateTileSprite();
            Debug.Log($"Planted {seed.cropName} at {gridPosition}");
        }
    }

    public void HarvestPlants()
    {
        if (hasCrop && plantedSeed != null && currentGrowthStage >= 3)
        {
            Debug.Log($"{plantedSeed.cropName} harvested at {gridPosition}");
            GameObject.Instantiate(plantedSeed.harvestablePrefab, worldPosition, Quaternion.identity);

            // Reset soil
            plantedSeed = null;
            hasCrop = false;
            isWatered = false;
            isTilled = false;
            currentGrowthStage = 0;
            growthTimer = 0f;
        }
    }

    // ----------------------------------------------------------
    // GROWTH LOGIC
    // ----------------------------------------------------------

    public void UpdateGrowth(float deltaTime)
    {
        if (!hasCrop || plantedSeed == null)
            return;

        if (!isWatered)
            return; // Must be watered to grow

        growthTimer += deltaTime;

        // Simple example: grow every 5 seconds
        if (growthTimer >= 5f && currentGrowthStage < plantedSeed.growthSprites.Length - 1)
        {
            growthTimer = 0f;
            currentGrowthStage++;
            UpdateTileSprite();

            Debug.Log($"{plantedSeed.cropName} grew to stage {currentGrowthStage}!");
        }
    }

    private void UpdateTileSprite()
    {
        if (plantedSeed != null && tilemap != null)
        {
            Sprite sprite = plantedSeed.growthSprites[currentGrowthStage];
            Tile tile = ScriptableObject.CreateInstance<Tile>();
            tile.sprite = sprite;

            tilemap.SetTile((Vector3Int)gridPosition, tile);
        }
    }
}