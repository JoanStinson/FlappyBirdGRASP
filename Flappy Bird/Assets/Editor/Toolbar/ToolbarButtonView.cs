using System;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine.UIElements;

namespace JGM.Editor
{
    [InitializeOnLoad]
    public static class ToolbarButtonView
    {
        private const int m_buttonsOrderInToolbar = 2;

        private static ScriptableObject m_currentToolbar = null;
        private static Type m_toolbarType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.Toolbar");
        private static VisualElement m_parent;
        private static int m_lastInstanceID;

        static ToolbarButtonView()
        {
            EditorApplication.update -= OnUpdate;
            EditorApplication.update += OnUpdate;
        }

        private static void OnUpdate()
        {
            SetCurrentToolbar();
            RecreateGUI();
            SetToolbar();
        }

        private static void SetCurrentToolbar()
        {
            if (m_currentToolbar != null)
            {
                return;
            }

            var toolbars = Resources.FindObjectsOfTypeAll(m_toolbarType);
            m_currentToolbar = (toolbars.Length > 0) ? (ScriptableObject)toolbars[0] : null;
        }

        private static void RecreateGUI()
        {
            if (!ShouldRecreateGUI())
            {
                return;
            }

            m_parent.RemoveFromHierarchy();
            m_parent = null;
            m_lastInstanceID = m_currentToolbar.GetInstanceID();
        }

        private static bool ShouldRecreateGUI()
        {
            return m_currentToolbar != null && m_parent != null && m_currentToolbar.GetInstanceID() != m_lastInstanceID;
        }

        private static void SetToolbar()
        {
            if (!ShouldSetToolbar())
            {
                return;
            }

            var root = m_currentToolbar.GetType().GetField("m_Root", BindingFlags.NonPublic | BindingFlags.Instance);
            if (root == null)
            {
                return;
            }

            var rawRoot = root.GetValue(m_currentToolbar);
            if (rawRoot == null)
            {
                return;
            }

            m_parent?.RemoveFromHierarchy();
            m_parent = null;
            m_parent = new VisualElement()
            {
                style =
                {
                    flexDirection = FlexDirection.Row,
                    alignItems = Align.FlexStart,
                    justifyContent = Justify.FlexStart,
                    marginLeft = -1
                }
            };

            var mRoot = rawRoot as VisualElement;
            var toolbarZoneLeftAlign = mRoot.Q("ToolbarZoneLeftAlign");
            toolbarZoneLeftAlign.Insert(m_buttonsOrderInToolbar, m_parent);
            OnAttachToToolbar(m_parent);
        }

        private static bool ShouldSetToolbar()
        {
            return m_currentToolbar != null && m_parent == null;
        }

        private static void OnAttachToToolbar(VisualElement parent)
        {
            var methods = TypeCache.GetMethodsWithAttribute<ToolbarButtonAttribute>();
            var allAttributes = new Dictionary<MethodInfo, ToolbarButtonAttribute>();

            foreach (var method in methods)
            {
                var attribute = (ToolbarButtonAttribute)method.GetCustomAttributes(typeof(ToolbarButtonAttribute), false).First();
                if (attribute != null)
                {
                    allAttributes.Add(method, attribute);
                }
            }

            foreach (var attr in allAttributes.OrderByDescending(x => x.Value.Order))
            {
                parent.Add(CreateToolbarButton(attr.Value.IconName, () => attr.Key.Invoke(null, null), attr.Value.Tooltip));
            }
        }

        private static VisualElement CreateToolbarButton(string icon, Action onClick, string tooltip = null)
        {
            Button buttonVE = new Button(onClick);
            buttonVE.tooltip = tooltip;
            FitChildrenStyle(buttonVE);

            VisualElement iconVE = new VisualElement();
            iconVE.AddToClassList("unity-editor-toolbar-element__icon");
#if UNITY_2021_2_OR_NEWER
            iconVE.style.backgroundImage = Background.FromTexture2D((Texture2D)EditorGUIUtility.IconContent(icon).image);
            iconVE.style.height = 16;
            iconVE.style.width = 16;
            iconVE.style.alignSelf = Align.Center;
#else
            iconVE.style.backgroundImage = Background.FromTexture2D(EditorGUIUtility.FindTexture(icon));
#endif
            buttonVE.Add(iconVE);

            return buttonVE;
        }

        private static void FitChildrenStyle(VisualElement element)
        {
            element.AddToClassList("unity-toolbar-button");
            element.AddToClassList("unity-editor-toolbar-element");
            element.RemoveFromClassList("unity-button");
#if UNITY_2021_2_OR_NEWER
            element.style.paddingRight = 8;
            element.style.paddingLeft = 8;
            element.style.justifyContent = Justify.Center;
            element.style.display = DisplayStyle.Flex;
            element.style.borderTopLeftRadius = 2;
            element.style.borderTopRightRadius = 2;
            element.style.borderBottomLeftRadius = 2;
            element.style.borderBottomRightRadius = 2;
            element.style.marginRight = 2;
            element.style.marginLeft = 2;
#else
            element.style.marginRight = 2;
            element.style.marginLeft = 2;
#endif
        }
    }
}