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
    private Item damagePotion = new Item(1);
    private Item throwingKnife = new Item(1);

    private Dictionary<Items, List<Item>> _Items = new Dictionary<Items, List<Item>>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            AddItem(Items.knives, throwingKnife);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            AddItem(Items.potions, healthPotion);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            AddItem(Items.potions, damagePotion);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RemoveItem(Items.knives, throwingKnife);
            RemoveItem(Items.potions, healthPotion);
            RemoveItem(Items.potions, damagePotion);
        }
    }

    void AddItem(Items itemType, Item item)
    {
        if (!_Items.ContainsKey(itemType)) {
            _Items[itemType] = new List<Item>();
            Debug.Log("Created list for " + itemType);
        }
        if(!_Items[itemType].Contains(item)) {
            _Items[itemType].Add(item);
            Debug.Log(item + " added to the list");
        }
        else {
            foreach(Item i in _Items[itemType]) {
                if(i == item) {
                    item.AddAmount(1);
                    Debug.Log("Added the item to the list");
                }
            }
        }
    }

    void RemoveItem(Items itemType, Item item)
    {
        if (_Items.ContainsKey(itemType)) {
            if (_Items[itemType].Contains(item)) {
                foreach (Item i in _Items[itemType]) {
                    if (i == item) {
                        item.RemoveAmount(1);
                        Debug.Log("Removed the item to the list " + itemType);
                        if (item.GetAmount() <= 0) {
                            _Items.Remove(itemType);
                            Debug.Log("No more items of this type left");
                        }
                        return;
                    }
                }
                Debug.Log(item + " added to the list");
            }
        }
        else
            Debug.Log("No more items left in " + itemType);
    }
}
