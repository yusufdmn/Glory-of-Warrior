using System.Collections.Generic;
using UnityEngine;
using Inventory_System.ScriptableObjects;

namespace Inventory_System
{
    public class ItemStorage: MonoBehaviour
    {
        [SerializeField] private Item[] allItems;

        public Item[] AllItems => allItems;
    }
}