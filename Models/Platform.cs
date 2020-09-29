using UnityEditor;

namespace UnityIr.FeatureManager.Models
{
    public enum Platform
    {
        Standalone = BuildTargetGroup.Standalone,
        iOS = BuildTargetGroup.iOS,
        Android = BuildTargetGroup.Android,
        WebGL = BuildTargetGroup.WebGL,
        WSA = BuildTargetGroup.WSA,
        PS4 = BuildTargetGroup.PS4,
        XboxOne = BuildTargetGroup.XboxOne,
        tvOS = BuildTargetGroup.tvOS,
        Switch = BuildTargetGroup.Switch,
        Lumin = BuildTargetGroup.Lumin,
        Stadia = BuildTargetGroup.Stadia,
    }
}
