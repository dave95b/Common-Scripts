using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtensions
{
    public static T AddOrGetComponent<T>(this GameObject gameObject) where T : Component
    {
        T component = gameObject.GetComponent<T>();

        if (component == null)
            component = gameObject.AddComponent<T>();

        return component;
    }

    public static void FindInChildren<T>(this Component component, ref T element)
    {
        element = component.GetComponentInChildren<T>();
    }

    public static void FindInChildren<T>(this Component component, ref T[] elements)
    {
        elements = component.GetComponentsInChildren<T>();
    }

    public static void FindInChildren<T>(this Component component, ref MonoBehaviour[] elements)
    {
        T[] interfaces = component.GetComponentsInChildren<T>();
        elements = Array.ConvertAll(interfaces, i => i as MonoBehaviour);
    }

    public static void FindInChildren<T>(this Component component, ref List<T> elements)
    {
        T[] found = component.GetComponentsInChildren<T>();
        elements = new List<T>(found);
    }

    public static void FindInChildren<T>(this Component component, ref List<MonoBehaviour> elements)
    {
        T[] found = component.GetComponentsInChildren<T>();
        elements = new List<MonoBehaviour>(found.Length);
        foreach (var elem in found)
            elements.Add(elem as MonoBehaviour);
    }

    #region Transform Extensions

    public static void SetPositionX(this Transform transform, float x)
    {
        transform.position = transform.position.WithX(x);
    }

    public static void SetPositionY(this Transform transform, float y)
    {
        transform.position = transform.position.WithY(y);
    }

    public static void SetPositionZ(this Transform transform, float z)
    {
        transform.position = transform.position.WithZ(z);
    }


    public static void SetLocalPositionX(this Transform transform, float x)
    {
        transform.localPosition = transform.localPosition.WithX(x);
    }

    public static void SetLocalPositionY(this Transform transform, float y)
    {
        transform.localPosition = transform.localPosition.WithY(y);
    }

    public static void SetLocalPositionZ(this Transform transform, float z)
    {
        transform.localPosition = transform.localPosition.WithZ(z);
    }


    public static void SetLocalScaleX(this Transform transform, float x)
    {
        transform.localScale = transform.localScale.WithX(x);
    }

    public static void SetLocalScaleY(this Transform transform, float y)
    {
        transform.localScale = transform.localScale.WithY(y);
    }

    public static void SetLocalScaleZ(this Transform transform, float z)
    {
        transform.localScale = transform.localScale.WithZ(z);
    }

    #endregion Transform Extensions
}
