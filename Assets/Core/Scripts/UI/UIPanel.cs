using UnityEngine;

namespace Demo.UI
{
    public abstract class UIPanel : MonoBehaviour
    {
        protected UIStateManager stateManager;

        // NOTE: For the sake of this test task, using FindObjectOfType for self-registration.
        // In production, inject this dependency via Zenject or similar DI framework.
        protected virtual void Awake()
        {
            stateManager = FindFirstObjectByType<UIStateManager>();
            if (stateManager != null)
                stateManager.RegisterPanel(this);

            Hide();
        }

        public abstract PanelType PanelType { get; }
        public virtual void Show() => gameObject.SetActive(true);
        public virtual void Hide() => gameObject.SetActive(false);
    }
}