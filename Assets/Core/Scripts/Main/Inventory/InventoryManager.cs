using System;
using System.Collections.Generic;
using UnityEngine;

namespace Demo
{
    public class InventoryManager : MonoBehaviour
    {
        private int _currency = 1000;
        private List<InventoryItemData> _items = new();

        public event Action<int> OnCurrencyAmountChanged;
        public event Action<InventoryItemData> OnInventoryItemAdded;

        public void AddItem(InventoryItemData item)
        {
            _items.Add(item);
            OnInventoryItemAdded?.Invoke(item);
        }

        public void GainCurrency(int amount)
        {
            // reminder to implement int overflow checks in actual product, im lazy here
            _currency += amount;

            OnCurrencyAmountChanged?.Invoke(_currency);
        }

        public bool CanSpend(int amount)
        {
            return _currency >= amount;
        }

        public void SpendCurrency(int amount)
        {
            if (CanSpend(amount))
            {
                _currency -= amount;

                OnCurrencyAmountChanged?.Invoke(_currency);
            }
        }
    }

    [Serializable]
    public class InventoryItemData
    {
        public int ItemID;
        public Sprite ItemIcon;
        public string ItemName;

        public InventoryItemData(int id, Sprite sprite, string name)
        {
            ItemID = id;
            ItemIcon = sprite;
            ItemName = name;
        }
    }
}
