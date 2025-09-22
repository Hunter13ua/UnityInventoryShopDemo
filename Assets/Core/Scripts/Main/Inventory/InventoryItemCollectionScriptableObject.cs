using System;
using System.Collections.Generic;
using UnityEngine;

namespace Demo
{
    [CreateAssetMenu(fileName = "InventoryItemCollectionScriptableObject", menuName = "Scriptable Objects/InventoryItemCollectionScriptableObject")]
    public class InventoryItemCollectionScriptableObject : ScriptableObject
    {
        public List<InventoryItemData> itemCollection;
    }

}