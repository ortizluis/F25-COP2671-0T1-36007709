using System;
using UnityEngine;

public class Harvesta : MonoBehaviour
{
    public ItemData item;
    public int amount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInventory playerInv = collision.GetComponent<PlayerInventory>();
        if (playerInv != null)
        {
            playerInv.inventory.AddItem(item, amount);
            Destroy(gameObject);
        }
    }
    
public class ItemData
{
}
}