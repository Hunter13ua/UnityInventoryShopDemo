using UnityEngine;

namespace Demo.UI
{
    public abstract class UIPanel : MonoBehaviour
    {
        public abstract PanelType PanelType { get; }
        public virtual void Show() => gameObject.SetActive(true);
        public virtual void Hide() => gameObject.SetActive(false);
        public virtual void Initialize() => Hide();
    }
}