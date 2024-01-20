using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public List<InventorySlot> inventorySlots = new List<InventorySlot>(64);
    public List<Button> tabButtons = new List<Button>();  // Add this list to store tab buttons
    private string lastActiveTab = "Meds";  // Initialize the last active tab

    private void OnEnable()
    {
        Inventory.OnInventoryChange += DrawLastActiveTab;
    }

    private void OnDisable()
    {
        Inventory.OnInventoryChange -= DrawLastActiveTab;
    }

    private void Start()
    {
        DrawLastActiveTab(FindObjectOfType<Inventory>().inventory);
    }

    private void DrawLastActiveTab(List<InventoryItem> inventory)
    {
        List<InventoryItem> filteredItems = FilterItemsByType(inventory, lastActiveTab);
        DrawInventory(filteredItems);
    }

    public void OnClickTab(string tabType)
    {
        Inventory inventoryScript = FindObjectOfType<Inventory>();
        List<InventoryItem> inventory = inventoryScript.inventory;
        List<InventoryItem> filteredItems = FilterItemsByType(inventory, tabType);
        DrawInventory(filteredItems);

        // Update the last active tab
        lastActiveTab = tabType;
    }

    private List<InventoryItem> FilterItemsByType(List<InventoryItem> inventory, string tabType)
    {
        List<InventoryItem> filteredItems = new List<InventoryItem>();

        foreach (InventoryItem item in inventory)
        {
            if (item.itemData.type.Equals(tabType, StringComparison.OrdinalIgnoreCase))
            {
                filteredItems.Add(item);
            }
        }

        return filteredItems;
    }



    void ResetInventory()
    {
        foreach (Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
        inventorySlots = new List<InventorySlot>(64);
    }

    void DrawInventory(List<InventoryItem> inventory)
    {
        ResetInventory();

        for (int i = 0; i < inventorySlots.Capacity; i++)
        {
            CreateInventorySlot();
        }

        for (int i = 0; i < inventory.Count; i++)
        {
            inventorySlots[i].DrawSlot(inventory[i]);
        }
    }

    void CreateInventorySlot()
    {
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.SetParent(transform, false);

        InventorySlot newSlotComponent = newSlot.GetComponent<InventorySlot>();
        newSlotComponent.ClearSlot();

        inventorySlots.Add(newSlotComponent);
    }
}
