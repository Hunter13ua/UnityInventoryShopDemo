using System;
using UnityEngine;

namespace Demo.UI
{
    public class InventoryPanel : UIPanel
    {
        public override PanelType PanelType => PanelType.Inventory;

        [SerializeField] private GameObject inventoryItemPrefab;

        private InventoryManager inventoryManager;

        private void Awake()
        {
            // use DI framework (e.g. Zenject instead)
            inventoryManager = FindFirstObjectByType<InventoryManager>();
        }

        private void Start()
        {
            if (inventoryManager != null)
            {
                inventoryManager.OnInventoryItemAdded += AddItemInstance;
            }
        }

        private void OnDestroy()
        {
            if (inventoryManager != null)
            {
                inventoryManager.OnInventoryItemAdded -= AddItemInstance;
            }
        }

        private void AddItemInstance(InventoryItemData item)
        {
            // this is not a good way to handle the event
            // at the very least this requires Object Pooling in actual product
            if (inventoryItemPrefab != null)
            {
                GameObject itemGO = Instantiate(inventoryItemPrefab, transform);
                InventoryItem invItem = itemGO.GetComponent<InventoryItem>();
                invItem.SetInfo(item);
            }
        }
    }
}
