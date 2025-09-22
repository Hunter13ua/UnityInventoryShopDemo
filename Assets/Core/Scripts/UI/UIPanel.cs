using UnityEngine;

namespace Demo.UI
{
    public abstract class UIPanel : MonoBehaviour
    {
        protected virtual void Awake() => Hide();

        public abstract PanelType PanelType { get; }
        public virtual void Show() => gameObject.SetActive(true);
        public virtual void Hide() => gameObject.SetActive(false);
    }
}