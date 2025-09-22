using System;
using UnityEngine;

namespace Demo
{
    public class ShopManager : MonoBehaviour
    {
        // NOTE: for the sake of avoiding any packages or SDKs using a scriptable object
        // For actual product, replace this with Remote Config data
        [SerializeField] private ShopScriptableObject shopItemList;

        // this class would be responsible in loading and handling shop data
        // before passing it further into ShopPanel for UI visualization
        public ShopScriptableObject ShopItemList { get { return shopItemList; } }
    }

    [Serializable]
    public enum ShopItemType
    {
        Currency,
        Item,
        Boost,
    }
}
