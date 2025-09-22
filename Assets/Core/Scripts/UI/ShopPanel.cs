using UnityEngine;

namespace Demo.UI
{
    public class ShopPanel : UIPanel
    {
        public override PanelType PanelType => PanelType.Shop;

        [SerializeField] private GameObject shopItemPrefab;

        private ShopManager shopManager;
        
        public override void Initialize()
        {
            // use DI framework (e.g. Zenject instead)
            shopManager = FindFirstObjectByType<ShopManager>();

            base.Initialize();

            if (shopManager != null && shopItemPrefab != null)
            {
                foreach (var item in shopManager.ShopItemList.shopItems)
                {
                    GameObject itemGO = Instantiate(shopItemPrefab, transform);
                    ShopItem shopItem = itemGO.GetComponent<ShopItem>();
                    shopItem.SetInfo(item);
                }
            }
        }
    }
}
