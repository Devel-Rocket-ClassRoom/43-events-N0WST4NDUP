using System;

Inventory inventory = new Inventory();
InventoryUI ui = new InventoryUI();
AutoBuyer autoBuyer = new AutoBuyer();
inventory.ItemChanged += ui.ItemChanged;
inventory.ItemChanged += autoBuyer.ItemEmpty;

inventory.AddItem("포션", 5);
inventory.AddItem("화살", 10);
inventory.AddItem("포션", 3);
inventory.RemoveItem("화살", 7);
inventory.RemoveItem("화살", 7);