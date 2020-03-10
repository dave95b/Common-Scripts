using UnityEngine;

public static class VectorExtensions
{
    #region Vector2

    public static Vector2 WithX(this in Vector2 vector, float x) => new Vector2(x, vector.y);

    public static Vector2 WithY(this in Vector2 vector, float y) => new Vector2(vector.x, y);

    public static Vector2 xx(this in Vector2 vector) => new Vector2(vector.x, vector.x);

    public static Vector2 xy(this in Vector2 vector) => new Vector2(vector.x, vector.y);

    public static Vector2 yx(this in Vector2 vector) => new Vector2(vector.y, vector.x);

    public static Vector2 yy(this in Vector2 vector) => new Vector2(vector.y, vector.y);

    #endregion Vector2

    #region Vector3

    public static Vector3 WithX(this in Vector3 vector, float x) => new Vector3(x, vector.y, vector.z);

    public static Vector3 WithY(this in Vector3 vector, float y) => new Vector3(vector.x, y, vector.z);

    public static Vector3 WithZ(this in Vector3 vector, float z) => new Vector3(vector.x, vector.y, z);

    public static Vector3 xxx(this in Vector3 vector) => new Vector3(vector.x, vector.x, vector.x);

    public static Vector3 xxy(this in Vector3 vector) => new Vector3(vector.x, vector.x, vector.y);

    public static Vector3 xxz(this in Vector3 vector) => new Vector3(vector.x, vector.x, vector.z);

    public static Vector3 xyx(this in Vector3 vector) => new Vector3(vector.x, vector.y, vector.x);

    public static Vector3 xyy(this in Vector3 vector) => new Vector3(vector.x, vector.y, vector.y);

    public static Vector3 xyz(this in Vector3 vector) => new Vector3(vector.x, vector.y, vector.z);

    public static Vector3 xzx(this in Vector3 vector) => new Vector3(vector.x, vector.z, vector.x);

    public static Vector3 xzy(this in Vector3 vector) => new Vector3(vector.x, vector.z, vector.y);

    public static Vector3 xzz(this in Vector3 vector) => new Vector3(vector.x, vector.z, vector.z);

    public static Vector3 yxx(this in Vector3 vector) => new Vector3(vector.y, vector.x, vector.x);

    public static Vector3 yxy(this in Vector3 vector) => new Vector3(vector.y, vector.x, vector.y);

    public static Vector3 yxz(this in Vector3 vector) => new Vector3(vector.y, vector.x, vector.z);

    public static Vector3 yyx(this in Vector3 vector) => new Vector3(vector.y, vector.y, vector.x);

    public static Vector3 yyy(this in Vector3 vector) => new Vector3(vector.y, vector.y, vector.y);

    public static Vector3 yyz(this in Vector3 vector) => new Vector3(vector.y, vector.y, vector.z);

    public static Vector3 yzx(this in Vector3 vector) => new Vector3(vector.y, vector.z, vector.x);

    public static Vector3 yzy(this in Vector3 vector) => new Vector3(vector.y, vector.z, vector.y);

    public static Vector3 yzz(this in Vector3 vector) => new Vector3(vector.y, vector.z, vector.z);

    public static Vector3 zxx(this in Vector3 vector) => new Vector3(vector.z, vector.x, vector.x);

    public static Vector3 zxy(this in Vector3 vector) => new Vector3(vector.z, vector.x, vector.y);

    public static Vector3 zxz(this in Vector3 vector) => new Vector3(vector.z, vector.x, vector.z);

    public static Vector3 zyx(this in Vector3 vector) => new Vector3(vector.z, vector.y, vector.x);

    public static Vector3 zyy(this in Vector3 vector) => new Vector3(vector.z, vector.y, vector.y);

    public static Vector3 zyz(this in Vector3 vector) => new Vector3(vector.z, vector.y, vector.z);

    public static Vector3 zzx(this in Vector3 vector) => new Vector3(vector.z, vector.z, vector.x);

    public static Vector3 zzy(this in Vector3 vector) => new Vector3(vector.z, vector.z, vector.y);

    public static Vector3 zzz(this in Vector3 vector) => new Vector3(vector.z, vector.z, vector.z);

    #endregion Vector3
}