using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public Item(int anAmount)
    {
        amount = anAmount;
    }

    private int amount;

    public int GetAmount()
    {
        return amount;
    }

    public void AddAmount(int anAmount)
    {
        amount += anAmount;
    }

    public void RemoveAmount(int anAmount)
    {
        amount -= anAmount;
    }
}
