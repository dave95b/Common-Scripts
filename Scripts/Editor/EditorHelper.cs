using System;
using UnityEditor;
using UnityEngine;

public static class EditorHelper
{
    public static void Execute(this MonoBehaviour monoBehaviour, Action action)
    {
        action();
        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(monoBehaviour.gameObject.scene);
        EditorUtility.SetDirty(monoBehaviour);
    }

    public static void Execute(this MonoBehaviour monoBehaviour, Action action, string actionName)
    {
        Undo.RecordObject(monoBehaviour, actionName);
        monoBehaviour.Execute(action);
    }
}