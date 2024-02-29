using UnityEngine;
using UnityEditor;

#if (UNITY_EDITOR)
public class PrefsEditor : EditorWindow
{
    private float _mouseSensitivity;

    [MenuItem("Window/Prefs Editor")]
    public static void ShowWindow()
    {
        GetWindow<PrefsEditor>("Prefs Editor");
    }

    private void OnGUI()
    {
        GUILayout.Space(10);

        _mouseSensitivity = EditorGUILayout.FloatField("Mouse Sensitivity", PlayerPrefs.GetFloat("MouseSensitivity"));
        PlayerPrefs.SetFloat("MouseSensitivity", _mouseSensitivity);

    }
}
#endif