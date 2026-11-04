//using Facebook.Unity.Editor;
//using Facebook.Unity.Settings;
using Sirenix.OdinInspector;
using UnityEditor;
#if UNITY_ANDROID
using UnityEditor.Android;
#endif
using UnityEditor.Build;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(MyProjectSettings), fileName = "My project settings")]
public class MyProjectSettings : ScriptableObject
{
    //public AppsFlyerObjectScript appsFlyerObject;
    //public Initialization initialization;
    public GameplaySettings gameplaySettings;
    public int targetSdkVersion = 33;

    [Header("Version")]
    public string version = "1.0";
    public int bundleVersionCode = 1;

    [Header("Unique")]
    [OnValueChanged(nameof(BuildPackageName))]
    public string appName;
    [OnValueChanged(nameof(BuildPackageName))]
    public string company;
    public string packageName;
    public Texture2D icon;
    [Header("Sdk")]
    public string devKey;
    public string config;
    public string privacyPolicy;
    [Header("Release")]
    public string keyStorePassword;

    [Button("Apply settings")]
    public void ApplySettings()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
        PlayerSettings.defaultInterfaceOrientation = UIOrientation.Portrait;

        PlayerSettings.bundleVersion = version;
        PlayerSettings.Android.bundleVersionCode = bundleVersionCode;

        PlayerSettings.productName = appName;
        PlayerSettings.companyName = company;
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, packageName);
        PlayerSettings.Android.targetSdkVersion = (AndroidSdkVersions)targetSdkVersion;

#if UNITY_ANDROID
        var icons = PlayerSettings.GetPlatformIcons(NamedBuildTarget.Android, AndroidPlatformIconKind.Adaptive);
        icons[0].SetTextures(icon, icon);
        PlayerSettings.SetPlatformIcons(NamedBuildTarget.Android, AndroidPlatformIconKind.Adaptive, icons);
#endif

        //appsFlyerObject.devKey = devKey;
        //EditorUtility.SetDirty(appsFlyerObject);
        //initialization._confPath = config;
        //EditorUtility.SetDirty(initialization);
        gameplaySettings.privacyPolicyLink = privacyPolicy;
        EditorUtility.SetDirty(gameplaySettings);
    }

    [Button("Set debug build")]
    public void SetDebugBuild()
    {
        PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARMv7;
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.Mono2x);

        PlayerSettings.Android.useCustomKeystore = false;

        build = "Debug build set";
    }



    [Button("Set release build")]
    public void SetReleaseBuild()
    {
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
        PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64 | AndroidArchitecture.ARMv7;

        PlayerSettings.Android.useCustomKeystore = true;
        PlayerSettings.Android.keystoreName = $@"C:\Users\gitar\Desktop\{appName}.keystore";
        PlayerSettings.Android.keystorePass = keyStorePassword;
        PlayerSettings.Android.keyaliasName = appName.ToLower();
        PlayerSettings.Android.keyaliasPass = keyStorePassword;

        build = "Release build set";
    }

    void BuildPackageName()
    {
        packageName = $"com.{company}.{appName}".Replace(" ", "");
    }

    [DisplayAsString]
    public string build = "";
}
