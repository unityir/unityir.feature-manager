using System;

namespace UnityIr.FeatureManager.Models
{
    [Serializable]
    public class BuildTarget
    {
        public Platform platform = Platform.Standalone;
        public bool isActive = true;
    }
}
