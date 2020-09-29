using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityIr.FeatureManager.Models;

namespace UnityIr.FeatureManager.Window
{
    public class FeatureManagerWindow : EditorWindow
    {
        public List<Feature> allFeatures = new List<Feature>();
        private const string TITLE = "[UnityIr] FeatureManager";
        private const string MENU = "Tools/UnityIr/Feature Manager";

        [MenuItem(MENU)]
        public static void ShowWindow()
        {
            var instance = (FeatureManagerWindow) GetWindow(typeof(FeatureManagerWindow));
            instance.titleContent = new GUIContent(TITLE);
            instance.Show();

            instance.RefreshFeatures();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Refresh"))
            {
                RefreshFeatures();
            }

            if (GUILayout.Button("Apply features"))
            {
                SyncAllFeatures();
            }

            ScriptableObject target = this;
            var so = new SerializedObject(target);
            var stringsProperty = so.FindProperty("allFeatures");

            EditorGUILayout.PropertyField(stringsProperty, true);
            so.ApplyModifiedProperties();
        }

        private void RefreshFeatures()
        {
            var guids = AssetDatabase.FindAssets("t:" + nameof(Feature));
            allFeatures = new List<Feature>();
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                allFeatures.Add(AssetDatabase.LoadAssetAtPath<Feature>(path));
            }
        }

        private void SyncAllFeatures()
        {
            foreach (var feature in allFeatures)
            {
                SyncFeature(feature);
            }
        }

        private void SyncFeature(Feature feature)
        {
            foreach (Platform platform in Enum.GetValues(typeof(Platform)))
            {
                SyncPlatform(feature, platform, false, false);
            }

            foreach (var target in feature.targets)
            {
                SyncPlatform(feature, target.platform, feature.isActive && target.isActive);
            }
        }

        private void SyncPlatform(Feature feature, Platform platform, bool isActive, bool withLog = true)
        {
            var definesString =
                PlayerSettings.GetScriptingDefineSymbolsForGroup((BuildTargetGroup) platform);
            var allDefines = definesString.Split(';').Distinct().ToList();
            if (isActive)
            {
                allDefines.Add(feature.symbol);
            }
            else
            {
                allDefines.Remove(feature.symbol);
            }

            definesString = string.Join(";", allDefines.Distinct().ToArray());
            PlayerSettings.SetScriptingDefineSymbolsForGroup((BuildTargetGroup) platform, definesString);
            AssetDatabase.SaveAssets();

            if (!withLog) return;
            if (isActive)
            {
                Debug.Log($"<color=#4A89DC><b>▶ {feature.title}: </b></color>" +
                          $"<color=#48CFAD><b>▶ Activated for {platform}</b></color>");
            }
            else
            {
                Debug.Log($"<color=#4A89DC><b>▶ {feature.title}: </b></color>" +
                          $"<color=#DA4453><b>▶ Deactivated for {platform}</b></color>");
            }
        }
    }
}
