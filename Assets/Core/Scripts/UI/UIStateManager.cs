using System;
using System.Collections.Generic;
using UnityEngine;

namespace Demo.UI
{
    public class UIStateManager : MonoBehaviour
    {
        [SerializeField] private List<PanelEntry> panels;

        private void Start()
        {
            foreach (var p in panels)
            {
                p.panelReference.Initialize();
            }
        }

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