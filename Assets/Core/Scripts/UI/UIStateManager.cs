using System;
using System.Collections.Generic;
using UnityEngine;

namespace Demo.UI
{
    [Serializable]
    public enum PanelType
    {
        Default,
        Inventory,
        Shop,
    }

    public class UIStateManager : MonoBehaviour
    {
        private readonly Dictionary<PanelType, UIPanel> panels = new();

        public void RegisterPanel(UIPanel panel)
        {
            if (!panels.ContainsKey(panel.PanelType))
            {
                panels[panel.PanelType] = panel;
            }
        }

        public void ShowPanel(PanelType panel)
        {
            foreach (var p in panels.Values)
            {
                p.Hide();
            }

            if (panels.TryGetValue(panel, out var target))
            {
                target.Show();
            }
            else
            {
                Debug.LogError($"No panel of type {panel} found.");
            }
        }
    }
}