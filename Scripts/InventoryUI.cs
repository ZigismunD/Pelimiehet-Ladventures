using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This object manages the inventory UI */

public class InventoryUI : MonoBehaviour {
    //The parent object of all items
    public Transform itemsParent;
    // The entire UI
    public GameObject inventoryUI;

    // Our current inventory
    Inventory inventory;
    InventorySlot[] slots;

	// Use this for initialization
	void Start () {
        inventory = Inventory.FindObjectOfType<Inventory>();
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}
	
	// Check to see if we should open or close the inventory
	void Update () {
		if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
	}

    // Update the inventory by adding items and clearing slots
    // This is called using a delegate on the Inventory
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            } else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
