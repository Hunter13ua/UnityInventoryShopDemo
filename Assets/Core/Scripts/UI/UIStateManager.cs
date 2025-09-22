using System;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEngine;

namespace Demo.UI
{
    public class UIStateManager : MonoBehaviour
    {
        public List<PanelEntry> panels = new();

        public void ShowPanel(PanelType panel)
        {
            foreach (var p in panels)
            {
                p.panelReference.Hide();
            }

            var target = panels.Find(x => x.panelType == panel);
            if (target != null)
            {
                target.panelReference.Show();
            }
            else
            {
                Debug.LogError($"No panel of type {panel} found.");
            }
        }
    }

    [Serializable]
    public enum PanelType
    {
        Default,
        Inventory,
        Shop,
    }

    [Serializable]
    public class PanelEntry
    {
        public PanelType panelType;
        public UIPanel panelReference;
    }
}