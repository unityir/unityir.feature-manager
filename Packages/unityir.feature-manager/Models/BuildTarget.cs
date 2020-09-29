using System;

namespace UnityIr.FeatureManager.Models
{
    [Serializable]
    public class BuildTarget
    {
        public Platform Platform = Platform.Standalone;
        public bool isActive = true;
    }
}
