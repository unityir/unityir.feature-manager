using System;
using UnityEditor;

namespace UnityIr.FeatureManager.Models
{
    [Serializable]
    public class BuildTarget
    {
        public BuildTargetGroup target;
        public bool isActive = true;

        public override string ToString()
        {
            return $"Target: {target}";
        }
    }
}
