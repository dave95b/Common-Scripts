using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public static class EditorHelper
{
    public static void Execute(MonoBehaviour monoBehaviour, Action action)
    {
        action();
#if UNITY_EDITOR
        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(monoBehaviour.gameObject.scene);
        EditorUtility.SetDirty(monoBehaviour);
#endif
    }

    public static void Execute(MonoBehaviour monoBehaviour, Action action, string actionName)
    {
#if UNITY_EDITOR
        Undo.RecordObject(monoBehaviour, actionName);
#endif
        Execute(monoBehaviour, action);
    }
}