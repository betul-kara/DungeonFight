using UnityEngine;
using UnityEditor;

public class PrefsEditor : EditorWindow
{
    private int _mouseSensitivity;

    [MenuItem("Window/Prefs Editor")]
    public static void ShowWindow()
    {
        GetWindow<PrefsEditor>("Prefs Editor");
    }

    private void OnGUI()
    {
        GUILayout.Space(10);

        _mouseSensitivity = EditorGUILayout.IntField("Mouse Sensitivity", PlayerPrefs.GetInt("MouseSensitivity"));
        PlayerPrefs.SetInt("MouseSensitivity", _mouseSensitivity);

    }
}
