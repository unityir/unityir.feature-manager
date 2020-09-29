using System;

namespace UnityIr.FeatureManager.Models
{
    [Serializable]
    public class BuildTarget
    {
        public Platform Platform;
        public bool isActive = true;
    }
}
