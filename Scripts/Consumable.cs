using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that is used to objects that the player can consume to heal
/// </summary>
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Consumable")]
public class Consumable : Item {

    public float healthGain;

    // Use method consumes the consumable and gives the player some health back
    public override void Use()
    {
        Debug.Log("Consuming " + name);
        PlayerHealthManager.FindObjectOfType<PlayerHealthManager>().Heal(healthGain);
        RemoveFromInventory();
    }
}
