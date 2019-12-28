using System;
using UnityEngine;
using UnityEditor;

public static class EditorHelper
{
    public static void Execute(MonoBehaviour monoBehaviour, Action action)
    {
        action();
        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(monoBehaviour.gameObject.scene);
        EditorUtility.SetDirty(monoBehaviour);
    }

    public static void Execute(MonoBehaviour monoBehaviour, Action action, string actionName)
    {
        Undo.RecordObject(monoBehaviour, actionName);
        Execute(monoBehaviour, action);
    }
}