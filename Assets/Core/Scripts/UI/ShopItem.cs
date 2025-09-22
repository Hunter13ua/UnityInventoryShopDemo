using UnityEngine;
using UnityEngine.UI;

namespace Demo.UI
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] private Image itemIcon;
        [SerializeField] private TMPro.TMP_Text itemNameLabel;
        [SerializeField] private TMPro.TMP_Text itemDescriptionLabel;
        [SerializeField] private TMPro.TMP_Text itemPriceLabel;

        private int _price;
        private ShopItemType _shopItemType;
        private int _value;

        private InventoryManager inventoryManager;

        public void SetInfo(ShopItemData shopItem, InventoryManager inventoryReference)
        {
            _price = shopItem.ItemPrice;
            _shopItemType = shopItem.ItemType;
            _value = shopItem.Value;

            itemIcon.sprite = shopItem.ItemIcon;
            itemNameLabel.text = shopItem.ItemName;
            itemDescriptionLabel.text = shopItem.ItemDescription;
            itemPriceLabel.text = _price.ToString();

            inventoryManager = inventoryReference;
        }

        public void OnButtonClicked()
        {
            if (inventoryManager != null && inventoryManager.CanSpend(_price))
            {
                inventoryManager.SpendCurrency(_price);

                switch (_shopItemType)
                {
                    case ShopItemType.Currency:
                        inventoryManager.GainCurrency(_value);
                        break;
                    case ShopItemType.Item:
                        InventoryItemData data = new(_value, itemIcon.sprite);
                        inventoryManager.AddItem(data);
                        break;
                    case ShopItemType.Boost:
                        break;
                }
            }
        }
    }
}
