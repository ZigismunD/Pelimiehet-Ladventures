using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {


    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    // Amount of item spaces
    public int space = 20;

    // Our current list of item in the inventory
    public List<Item> items = new List<Item>();

    // Checks if the house can be built
    // If axe and stick are found in inventory houseCanBeBuilt will turn to true
    public static bool houseCanBeBuilt = false;
    private bool axeInInventory = false;
    private bool stickInInventory = false;

    // Keep checking if the inventory has items Axe and Stick in it
    // Only do the check if all previous checks are false
    void Update()
    {
        
        if (!houseCanBeBuilt)
        {
            if (axeInInventory && stickInInventory)
            {
                houseCanBeBuilt = true;
            }
        } else if (!axeInInventory || !stickInInventory)
        {
            houseCanBeBuilt = false;
        }
    }

    // Add new item if there is enough room
    // If the added item is Axe or Stick the respective variable is set to true
    public bool Add (Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough room.");
            return false;
        }

        if (item.name.Equals("Axe"))
        {
            axeInInventory = true;
        }

        if (item.name.Equals("Stick")) {
            stickInInventory = true;
        }

        items.Add(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        return true;
    }

    // Remove an item from the inventory
    public void Remove (Item item)
    {
        if (item.name.Equals("Axe"))
        {
            axeInInventory = false;
        }

        if (item.name.Equals("Stick"))
        {
            stickInInventory = false;
        }
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

   

    

}
