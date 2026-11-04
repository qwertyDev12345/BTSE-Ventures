using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

public static class CiBuild
{
    public static void BuildIOS()
    {
        var scenes = EditorBuildSettings.scenes
            .Where(scene => scene.enabled)
            .Select(scene => scene.path)
            .ToArray();
        if (scenes.Length == 0 || scenes.Any(scene => !File.Exists(scene)))
            throw new BuildFailedException("Enabled build scenes are missing or empty.");

        var output = Environment.GetEnvironmentVariable("IOS_UNITY_OUTPUT_PATH");
        if (string.IsNullOrWhiteSpace(output))
            output = "build/iOS/iOS";

        PlayerSettings.SetScriptingBackend(BuildTargetGroup.iOS, ScriptingImplementation.IL2CPP);
        var report = BuildPipeline.BuildPlayer(new BuildPlayerOptions
        {
            scenes = scenes,
            locationPathName = output,
            target = BuildTarget.iOS,
            options = BuildOptions.None
        });
        if (report.summary.result != BuildResult.Succeeded)
            throw new BuildFailedException($"iOS build failed: {report.summary.result}, {report.summary.totalErrors} errors.");
    }
}
