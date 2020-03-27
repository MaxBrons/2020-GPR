using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private enum Items
    {
        knives,
        potions
    }

    private Item healthPotion = new Item(1);
    private Item damagePotion = new Item(5);
    private Item throwingKnife = new Item(3);

    private Dictionary<Items, List<Item>> _Items;

    private void Start()
    {
        AddItem(Items.knives, throwingKnife);
        AddItem(Items.potions, healthPotion);
        AddItem(Items.potions, damagePotion);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RemoveItem(Items.knives, throwingKnife);
            RemoveItem(Items.potions, healthPotion);
            RemoveItem(Items.potions, damagePotion);
        }
    }

    void AddItem(Items itemType, Item item)
    {
        if(!_Items[itemType].Contains(item))
        {
            _Items[itemType].Add(item);
            Debug.Log(item + " added to the list");
        }
    }

    void RemoveItem(Items itemType, Item item)
    {
        if (_Items[itemType].Contains(item))
        {
            _Items[itemType].Remove(item);
            Debug.Log(item + " removed from the list");
        }
        else
            Debug.Log("Item not found");
    }
}
