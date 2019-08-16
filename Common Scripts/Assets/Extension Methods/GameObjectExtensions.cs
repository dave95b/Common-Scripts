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

    #region Component Extensions

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

    #endregion Component Extensions

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


    public static void AddPositionX(this Transform transform, float delta)
    {
        Vector3 position = transform.position;
        position.x += delta;
        transform.position = position;
    }

    public static void AddPositionY(this Transform transform, float delta)
    {
        Vector3 position = transform.position;
        position.y += delta;
        transform.position = position;
    }

    public static void AddPositionZ(this Transform transform, float delta)
    {
        Vector3 position = transform.position;
        position.z += delta;
        transform.position = position;
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


    public static void AddLocalPositionX(this Transform transform, float delta)
    {
        Vector3 position = transform.localPosition;
        position.x += delta;
        transform.position = position;
    }

    public static void AddLocalPositionY(this Transform transform, float delta)
    {
        Vector3 position = transform.localPosition;
        position.y += delta;
        transform.position = position;
    }

    public static void AddLocalPositionZ(this Transform transform, float delta)
    {
        Vector3 position = transform.localPosition;
        position.z += delta;
        transform.position = position;
    }


    public static void SetScale(this Transform transform, float scale)
    {
        transform.localScale = Vector3.one * scale;
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
