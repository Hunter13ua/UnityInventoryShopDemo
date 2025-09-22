using System;
using UnityEngine;

namespace Demo.UI
{
    public class InventoryPanel : UIPanel
    {
        public override PanelType PanelType => PanelType.Inventory;

        [SerializeField] private GameObject inventoryItemPrefab;

        [Header("References")]
        [SerializeField] private TMPro.TMP_Text currencyLabel;
        [SerializeField] private GameObject boostGameObject;
        [SerializeField] private TMPro.TMP_Text boostLabel;

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
                inventoryManager.OnCurrencyAmountChanged += UpdateCurrencyLabel;
                inventoryManager.OnInventoryItemAdded += AddItemInstance;
            }
        }

        private void OnDestroy()
        {
            if (inventoryManager != null)
            {
                inventoryManager.OnCurrencyAmountChanged -= UpdateCurrencyLabel;
                inventoryManager.OnInventoryItemAdded -= AddItemInstance;
            }
        }

        private void UpdateCurrencyLabel(int value)
        {
            if (currencyLabel != null)
            {
                currencyLabel.text = value.ToString();
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
