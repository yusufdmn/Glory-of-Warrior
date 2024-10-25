using System.Collections.Generic;
using System.Linq;
using Inventory_System.ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Inventory_System.View
{
    public enum SpawnParent
    {
        RightHand,
        LeftHand,
        Player
    }
    
    public class InventoryView: MonoBehaviour
    {
        private Dictionary<SpawnParent, Transform> _spawnParents;
        private Dictionary<Item,GameObject> _createdObjects = new();
        [Inject] DiContainer _container;
        
        [SerializeField] private Transform _rightHandTransform;
        [SerializeField] private Transform _leftHandTransform;
        [FormerlySerializedAs("_armotSlotTransform")] [SerializeField] private Transform _armorSlotTransform;
        
        
        internal void Start()
        {
            _spawnParents = new Dictionary<SpawnParent, Transform>(3)
            {
                [SpawnParent.LeftHand] = _leftHandTransform,
                [SpawnParent.RightHand] = _rightHandTransform,
                [SpawnParent.Player] = _armorSlotTransform
            };
        }
        
        public void OnItemEquipment(Item item)
        {
            if(_createdObjects.ContainsKey(item) && _createdObjects[item].activeSelf)
                RemoveItem(item);
            else 
                EquipItem(item);
        }
        
        public void RemoveReplacedItem(int exceptionItemId, ItemType itemType)
        {
            var itemToRemove = _createdObjects.Keys.FirstOrDefault(keyItem =>
                keyItem.Type == itemType && _createdObjects[keyItem].activeSelf && exceptionItemId != keyItem.Id);
            
            if(itemToRemove != null)
                RemoveItem(itemToRemove);
        }

        private void EquipItem(Item item)
        {
            if (_createdObjects.ContainsKey(item)) // If there is already gameobject created with same item id, actiavte it.
            {
                _createdObjects[item].SetActive(true);
                return;
            }
            GameObject itemObject = _container.InstantiatePrefab(item.ItemPrefab, _spawnParents[item.SpawnParent]);
            _createdObjects.Add(item, itemObject);
        }

        private void RemoveItem(Item item)
        {
            _createdObjects[item].SetActive(false);
        }

        private void OnDisable()  // Destroy Unequipped items
        {
            foreach (GameObject equipment in _createdObjects.Values)
            {
                if (equipment.activeSelf == false)
                    Destroy(equipment);
            }
        }
    }
}