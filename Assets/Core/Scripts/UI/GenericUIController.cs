using UnityEngine;

namespace Demo.UI
{
    public class GenericUIController : MonoBehaviour
    {
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
                inventoryManager.OnBonusEffectTimerChanged += OnBonusEffectTimerUpdated;
            }
        }

        private void OnDestroy()
        {
            if (inventoryManager != null)
            {
                inventoryManager.OnCurrencyAmountChanged -= UpdateCurrencyLabel;
                inventoryManager.OnBonusEffectTimerChanged -= OnBonusEffectTimerUpdated;
            }
        }

        private void UpdateCurrencyLabel(int value)
        {
            if (currencyLabel != null)
            {
                currencyLabel.text = value.ToString();
            }
        }

        private void OnBonusEffectTimerUpdated(int value)
        {
            boostGameObject.SetActive(value > 0);
            boostLabel.text = value.ToString();
        }
    }
}