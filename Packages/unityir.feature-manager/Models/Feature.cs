using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityIr.FeatureManager.Models
{
    [Serializable]
    [CreateAssetMenu(fileName = "Feature", menuName = "UnityIr/FeatureManager/New Feature", order = 1)]
    public class Feature : ScriptableObject
    {
        public string title;
        public string symbol;
        public bool isActive = true;
        public List<BuildTarget> targets;
    }
}
