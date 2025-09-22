using System;
using System.Collections.Generic;
using UnityEngine;

namespace Demo
{
    [CreateAssetMenu(fileName = "ShopScriptableObject", menuName = "Scriptable Objects/ShopScriptableObject")]
    public class ShopScriptableObject : ScriptableObject
    {
        public List<ShopItemData> shopItems;
    }

    [Serializable]
    public class ShopItemData
    {
        public string ItemName;
        public Sprite ItemIcon;
        public string ItemDescription;
        public int ItemPrice;

        public ShopItemType ItemType;
        public int Value;
    }
}
