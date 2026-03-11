using System;

public class InventoryUI
{
    public void ItemChanged(string name, int oldCount, int newCount)
    {
        Console.WriteLine($"[UI] {name}: {oldCount} -> {newCount}");
    }
}