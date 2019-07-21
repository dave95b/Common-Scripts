using UnityEngine;
using System.Collections.Generic;

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

    public static void FindInChildren<T>(this Component component, ref List<T> elements)
    {
        T[] found = component.GetComponentsInChildren<T>();
        elements = new List<T>(found);
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

    #endregion Transform Extensions
}
