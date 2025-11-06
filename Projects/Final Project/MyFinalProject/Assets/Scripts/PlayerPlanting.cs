using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerPlanting : MonoBehaviour
{
    public CropManager cropManager;
    public Tilemap farmTilemap;
    public SeedPacket selectedSeed;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int tilePos = farmTilemap.WorldToCell(worldPos);

            cropManager.PlantCrop(tilePos, selectedSeed);
        }
    }
}
