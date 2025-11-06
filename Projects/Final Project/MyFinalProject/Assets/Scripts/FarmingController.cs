using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Events;

public class FarmingController : MonoBehaviour
{
    [Header("References")]
    public CropManager cropManager;
    public Tilemap farmTilemap;

    [Header("Input Settings")]
    public Camera mainCamera;

    // Example tiles for soil visuals
    public Tile tilledSoilTile;

    // Currently selected block
    private CropBlock selectedBlock;

    // --- Events for farming actions ---
    public UnityEvent onTillSoil;
    public UnityEvent onWaterSoil;
    public UnityEvent onPlantSeed;
    public UnityEvent onHarvest;

    private void Start()
    {
        // Subscribe to events
        onTillSoil.AddListener(TillSelectedBlock);
        onWaterSoil.AddListener(WaterSelectedBlock);
        onPlantSeed.AddListener(PlantSelectedBlock);
        onHarvest.AddListener(HarvestSelectedBlock);
    }

    private void Update()
    {
        HandleMouseSelection();
        HandlePlayerInput();
    }

    private void HandleMouseSelection()
    {
        if (mainCamera == null || cropManager == null || farmTilemap == null)
            return;

        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = farmTilemap.WorldToCell(mouseWorldPos);

        // Check if the cell exists in the crop grid
        //if (cropManager.TryGetBlockAtPosition(cellPosition, out CropBlock block))
        //{
        //    selectedBlock = block;
        //}
        //else
        //{
        //    selectedBlock = null;
        //}
    }

    //public bool TryGetBlockAtPosition(Vector3Int cellPos, out CropBlock block)
    //{
    //    Vector2Int pos2D = new Vector2Int(cellPos.x, cellPos.y);
        //return grid.TryGetValue(pos2D, out block);
    //}

    private void HandlePlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) onTillSoil.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha2)) onWaterSoil.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha3)) onPlantSeed.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha4)) onHarvest.Invoke();
    }
    
    private void TillSelectedBlock()
    {
        if (selectedBlock != null)
        {
            selectedBlock.TillSoil(tilledSoilTile);
            cropManager.AddToPlantedCrops(selectedBlock);
        }
    }

    private void WaterSelectedBlock()
    {
        if (selectedBlock != null)
            selectedBlock.WaterSoil();
    }

    private void PlantSelectedBlock()
    {
        if (selectedBlock != null)
        {
            // Example: you could track selected seed in a toolbar
            SeedPacket selectedSeed = ToolbarManager.CurrentSeed;
            if (selectedSeed != null)
                selectedBlock.PlantSeed(selectedSeed);
        }
    }

    private void HarvestSelectedBlock()
    {
        if (selectedBlock != null)
        {
            selectedBlock.HarvestPlants();
            cropManager.RemoveFromPlantedCrops(selectedBlock);
        }
    }
}
