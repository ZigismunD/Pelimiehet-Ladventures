﻿using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
    public Image icon;
    public Button removeButton;

    // Current item in the slot
    Item item;

    // Add item to the next available slot
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    // Clears the slot
    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    // If the remove button is pressed, this function will be called
    public void OnRemoveButton()
    {
        Inventory.FindObjectOfType<Inventory>().Remove(item);
    }

    // Uses the item in the slot
    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
	
}
