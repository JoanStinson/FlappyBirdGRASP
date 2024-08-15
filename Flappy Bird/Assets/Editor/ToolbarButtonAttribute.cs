using System.Diagnostics;
using System;

namespace JGM.Editor
{
    [Conditional("UNITY_EDITOR"), AttributeUsage(AttributeTargets.Method)]
    public class ToolbarButtonAttribute : Attribute
    {
        public string tooltip;
        public string iconName;
        public int order = 0;

        public ToolbarButtonAttribute() { }

        public ToolbarButtonAttribute(string iconName, string tooltip = null, int order = 0)
        {
            this.iconName = iconName;
            this.tooltip = tooltip;
            this.order = order;
        }
    }
}