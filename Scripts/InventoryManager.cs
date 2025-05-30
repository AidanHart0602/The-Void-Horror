using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{

    public static InventoryManager Instance;

    public List<ItemList> _inventoryItems = new List<ItemList>();

    public enum ItemList
    {
        MedbayCard,
        CargoCard,
        SecurityCard,
        EngineCard,
    }

    private void Awake()
    {
        Instance = this;
    }

    public void CreateItems(ItemList items)
    {
        if (!_inventoryItems.Contains(items))
        {
            _inventoryItems.Add(items);
        }
    }
}

