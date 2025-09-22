using UnityEngine;

namespace Demo.UI
{
    public class PanelSelectorButton : MonoBehaviour
    {
        [SerializeField] private PanelType panelType;

        private UIStateManager stateManager;

        // NOTE: For the sake of this test task, using FindObjectOfType.
        // In production, inject this dependency via Zenject or similar DI framework.
        protected virtual void Awake()
        {
            stateManager = FindFirstObjectByType<UIStateManager>();
        }

        public void OnButtonClick()
        {
            if (stateManager != null)
            {
                stateManager.ShowPanel(panelType);
            }
        }
    }
}
