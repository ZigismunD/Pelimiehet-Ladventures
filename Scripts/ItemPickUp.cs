
using UnityEngine;

public class ItemPickUp : Interactable {

    public Item item; // Item to be put in the inventory if picked up

    // When the player interacts with the item
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    // Method picks up the item, adds it to the inventory and destroys it on the map
    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        FindObjectOfType<Inventory>().Add(item);
        Destroy(gameObject);
    }

}
