using System.Diagnostics;
using System;

namespace JGM.Editor
{
    [Conditional("UNITY_EDITOR"), AttributeUsage(AttributeTargets.Method)]
    public class ToolbarButtonAttribute : Attribute
    {
        public string IconName;
        public string Tooltip;
        public int Order;

        public ToolbarButtonAttribute() { }

        public ToolbarButtonAttribute(string iconName, string tooltip, int order = 0)
        {
            IconName = iconName;
            Tooltip = tooltip;
            Order = order;
        }
    }
}