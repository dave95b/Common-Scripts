using UnityEngine;
using System.Reflection;

public static class GameObjectExtensions
{
    public static T AddOrGetComponent<T>(this GameObject gameObject) where T : Component
    {
        T component = gameObject.GetComponent<T>();

        if (component == null)
            component = gameObject.AddComponent<T>();

        return component;
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
