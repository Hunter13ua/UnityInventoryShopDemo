using Demo;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private TMPro.TMP_Text itemNameLabel;

    public void SetInfo(InventoryItemData item)
    {
        itemIcon.sprite = item.ItemIcon;
        itemNameLabel.text = item.ItemName;
    }
}
