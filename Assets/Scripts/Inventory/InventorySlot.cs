using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image icon;
    public TextMeshProUGUI stackSizeText;

    private InventoryItem currentItem;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (currentItem != null)
        {
            DisplayDetailedInformation(currentItem);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideDetailedInformation();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            DropItem();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            UseOrEquipItem();
        }
    }

    private void DisplayDetailedInformation(InventoryItem item)
    {
        UIManager.Instance.UpdateDetailedInfo(item.itemData);
    }

    private void HideDetailedInformation()
    {
        UIManager.Instance.ClearDetailedInfo();
    }

    private void DropItem()
    {
        if (currentItem != null)
        {
            // Implement the logic for dropping the item
            Debug.Log("Item Dropped: " + currentItem.itemData.name);
        }
        else
        {
            Debug.LogWarning("No item to drop.");
        }
    }

    private void UseOrEquipItem()
    {
        if (currentItem != null)
        {
            // Implement the logic for using/equipping the item
            Debug.Log("Item Used/Equipped: " + currentItem.itemData.name);
            ItemManager.Instance.ItemList(currentItem);
        }
        else
        {
            Debug.LogWarning("No item to use/equip.");
        }
    }


    public void ClearSlot()
    {
        icon.enabled = false;
        stackSizeText.enabled = false;
    }

    public void DrawSlot(InventoryItem item)
    {
        currentItem = item;
        if (item == null)
        {
            ClearSlot();
            return;
        }

        icon.enabled = true;
        stackSizeText.enabled = true;

        icon.sprite = item.itemData.icon;
        stackSizeText.text = item.stackSize.ToString();
    }
}
