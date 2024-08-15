using System.Collections;
using System.Diagnostics;
using System;
using UnityEditor.IMGUI.Controls;
using UnityEditor.ShortcutManagement;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEditor.SceneManagement;

namespace JGM.Editor
{
    public static class ToolbarButtons
    {
        private const string scenesFolder = "Scenes";
        private static AdvancedDropdownState scenesState = new AdvancedDropdownState();

        public static T[] GetAtPath<T>(string path)
        {
            ArrayList al = new ArrayList();
            string[] fileEntries = Directory.GetFiles(Application.dataPath + "/" + path);

            foreach (string fileName in fileEntries)
            {
                string temp = fileName.Replace("\\", "/");
                int index = temp.LastIndexOf("/");
                string localPath = "Assets/" + path;

                if (index > 0)
                    localPath += temp.Substring(index);

                System.Object t = AssetDatabase.LoadAssetAtPath(localPath, typeof(T));

                if (t != null)
                    al.Add(t);
            }

            T[] result = new T[al.Count];

            for (int i = 0; i < al.Count; i++)
                result[i] = (T)al[i];

            return result;
        }

        [ToolbarButton("d_winbtn_win_max", "Open Terminal")]
        public static void OpenTerminal()
        {
            var projectPath = Directory.GetParent(Application.dataPath).FullName;

            Process cmd = new Process();
#if UNITY_EDITOR_WIN
            cmd.StartInfo.FileName = "cmd.exe";
#endif
#if UNITY_EDITOR_OSX
            cmd.StartInfo.FileName = "/Applications/Utilities/Terminal.app/Contents/MacOS/Terminal";
#endif
            cmd.StartInfo.WorkingDirectory = projectPath;
            cmd.Start();
        }

        [ToolbarButton("Folder Icon", "Open Folder")]
        public static void OpenFolder()
        {
            var projectPath = Directory.GetParent(Application.dataPath).FullName;

            Process cmd = new Process();
#if UNITY_EDITOR_WIN
            cmd.StartInfo.FileName = "explorer.exe";
#endif
            // #if UNITY_EDITOR_OSX
            //             cmd.StartInfo.FileName = "/bin/bash";
            // #endif
            cmd.StartInfo.Arguments = projectPath;
            cmd.Start();
        }

#if UNITY_EDITOR_WIN
        [ToolbarButton("UnityEditor.VersionControl", "Open Fork")]
        public static void OpenFork()
        {
            var projectPath = Directory.GetParent(Application.dataPath).FullName;
            var forkPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            Process cmd = new Process();
            cmd.StartInfo.FileName = forkPath + "\\Fork\\Fork.exe";

            cmd.StartInfo.Arguments = projectPath;
            cmd.Start();
        }
#endif

        [ToolbarButton(iconName = "Package Manager", tooltip = "Package Manager")]
        public static void ShowPackageManager()
        {
            UnityEditor.PackageManager.UI.Window.Open("");
        }


        [ToolbarButton("Settings", "Show Settings")]
        public static void ShowSettings()
        {
            var a = new GenericMenu();
            a.AddItem(new GUIContent("Project"), false, () => EditorApplication.ExecuteMenuItem("Edit/Project Settings..."));
            a.AddItem(new GUIContent("Preferences"), false, () => EditorApplication.ExecuteMenuItem("Edit/Preferences..."));
            a.ShowAsContext();
        }

        public static string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        public static string ReplaceLast(string Source, string Find, string Replace)
        {
            int place = Source.LastIndexOf(Find);

            if (place == -1)
                return Source;

            string result = Source.Remove(place, Find.Length).Insert(place, Replace);
            return result;
        }

        //[ToolbarButton("UnityEditor.GameView", "Show Bootstrap Scene")]
        //public static void ShowBootstrapScene()
        //{
        //    var bootstrapPath = "Assets/" + scenesFolder + "/bootstrap.unity";
        //    if (!Application.isPlaying && File.Exists(bootstrapPath))
        //        EditorSceneManager.OpenScene(bootstrapPath, OpenSceneMode.Additive);
        //    Selection.activeGameObject = GameObject.FindGameObjectWithTag("Player");
        //    SceneView.FrameLastActiveSceneView();
        //}

        public static void ShowQuickSearch()
        {
            EditorApplication.ExecuteMenuItem("Help/Quick Search");
        }
    }
}