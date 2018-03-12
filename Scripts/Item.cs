using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The base item class. All items should be derived from this. */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "New Item"; // Name of the item
    public Sprite icon = null; // Icon of the item

    // Called when the item is pressed in the inventory
    public virtual void Use()
    {
        // Use the item
        // Something might happen
    }

    // Call this method to remove the item from the inventory
    public void RemoveFromInventory()
    {
        FindObjectOfType<Inventory>().Remove(this);
    }

    // Call this method if you want to retrieve the name of the item
    public string GetName()
    {
        return this.name;
    }
}
