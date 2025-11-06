using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using System;

public class CropManager : MonoBehaviour
{
    [Header("Tilemap Reference")]
    public Tilemap farmingTilemap; // Assign this in the Inspector

    // Store all grid blocks and planted crops
    private Dictionary<Vector2Int, CropBlock> grid = new Dictionary<Vector2Int, CropBlock>();
    private List<CropBlock> plantedCrops = new List<CropBlock>();

    private void Start()
    {
        // Initialize the farming grid from the tilemap
        CreateGridUsingTilemap(farmingTilemap);
    }

    private void Update()
    {
        foreach (CropBlock block in plantedCrops)
        {
            block.UpdateGrowth(Time.deltaTime);
        }
    }

    // --- Methods to implement ---
    public void CreateGridUsingTilemap(Tilemap tilemap)
    {
        if (tilemap == null)
    {
        Debug.LogError("Tilemap is not assigned!");
        return;
    }

    grid.Clear();

    // Loop through all cells in the tilemap bounds
    foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
    {
        if (tilemap.HasTile(pos))
        {
            Vector2Int gridPos = new Vector2Int(pos.x, pos.y);
            Vector3 worldPos = tilemap.GetCellCenterWorld(pos);

            // Create a new CropBlock for this tile
            CropBlock newBlock = new CropBlock(gridPos, worldPos);
            CreateGridBlock(tilemap, gridPos, worldPos, newBlock);
        }
    }

    Debug.Log($"Farming grid created with {grid.Count} tiles.");
    }
    public void CreateGridBlock(Tilemap tilemap, Vector2Int location, Vector3 position, CropBlock gridBlock)
    {
        if (!grid.ContainsKey(location))
        {
            grid.Add(location, gridBlock);
        }
        else
        {
            Debug.LogWarning($"Grid block already exists at {location}");
        }
    }
    public void AddToPlantedCrops(CropBlock cropBlock)
    {
        if (!plantedCrops.Contains(cropBlock))
        {
             plantedCrops.Add(cropBlock);
        }
    }
    public void RemoveFromPlantedCrops(CropBlock cropBlock)
    {
        if (plantedCrops.Contains(cropBlock))
        {
            plantedCrops.Remove(cropBlock);
        }
    }

    internal void PlantCrop(Vector3Int tilePos, SeedPacket selectedSeed)
    {
        throw new NotImplementedException();
    }
}