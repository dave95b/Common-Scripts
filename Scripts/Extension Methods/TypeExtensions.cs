using System;

public static class TypeExtensions
{
    public static bool HasAttribute<T>(this Type type) where T : Attribute
        => type.IsDefined(typeof(T), true);

    public static bool Is<T>(this Type type) where T : class
        => typeof(T).IsAssignableFrom(type);
}
