using System;
using System.Collections.Generic;

public class Inventory
{
    private Dictionary<string, int> _inventory = new();

    public event Action<string, int, int> ItemChanged;

    public void AddItem(string name, int count)
    {
        int itemCount = _inventory.GetValueOrDefault(name, 0);
        _inventory[name] = itemCount + count;

        ItemChanged(name, itemCount, _inventory[name]);
    }

    public void RemoveItem(string name, int count)
    {
        int itemCount = _inventory.GetValueOrDefault(name, 0);
        _inventory[name] = Math.Max(0, itemCount - count);

        ItemChanged(name, itemCount, _inventory[name]);
    }
}