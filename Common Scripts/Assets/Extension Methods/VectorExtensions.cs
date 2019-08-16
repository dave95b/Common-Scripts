using UnityEngine;

public static class VectorExtensions
{
    #region Vector2

    public static Vector2 WithX(this Vector2 vector, float x) => new Vector2(x, vector.y);

    public static Vector2 WithY(this Vector2 vector, float y) => new Vector2(vector.x, y);

    public static Vector2 xx(this Vector2 vector) => new Vector2(vector.x, vector.x);
    public static Vector2 xy(this Vector2 vector) => new Vector2(vector.x, vector.y);
    public static Vector2 yx(this Vector2 vector) => new Vector2(vector.y, vector.x);
    public static Vector2 yy(this Vector2 vector) => new Vector2(vector.y, vector.y);

    #endregion Vector2

    #region Vector3

    public static Vector3 WithX(this Vector3 vector, float x) => new Vector3(x, vector.y, vector.z);

    public static Vector3 WithY(this Vector3 vector, float y) => new Vector3(vector.x, y, vector.z);

    public static Vector3 WithZ(this Vector3 vector, float z) => new Vector3(vector.x, vector.y, z);


    public static Vector3 xxx(this Vector3 vector) => new Vector3(vector.x, vector.x, vector.x);
    public static Vector3 xxy(this Vector3 vector) => new Vector3(vector.x, vector.x, vector.y);
    public static Vector3 xxz(this Vector3 vector) => new Vector3(vector.x, vector.x, vector.z);

    public static Vector3 xyx(this Vector3 vector) => new Vector3(vector.x, vector.y, vector.x);
    public static Vector3 xyy(this Vector3 vector) => new Vector3(vector.x, vector.y, vector.y);
    public static Vector3 xyz(this Vector3 vector) => new Vector3(vector.x, vector.y, vector.z);

    public static Vector3 xzx(this Vector3 vector) => new Vector3(vector.x, vector.z, vector.x);
    public static Vector3 xzy(this Vector3 vector) => new Vector3(vector.x, vector.z, vector.y);
    public static Vector3 xzz(this Vector3 vector) => new Vector3(vector.x, vector.z, vector.z);


    public static Vector3 yxx(this Vector3 vector) => new Vector3(vector.y, vector.x, vector.x);
    public static Vector3 yxy(this Vector3 vector) => new Vector3(vector.y, vector.x, vector.y);
    public static Vector3 yxz(this Vector3 vector) => new Vector3(vector.y, vector.x, vector.z);

    public static Vector3 yyx(this Vector3 vector) => new Vector3(vector.y, vector.y, vector.x);
    public static Vector3 yyy(this Vector3 vector) => new Vector3(vector.y, vector.y, vector.y);
    public static Vector3 yyz(this Vector3 vector) => new Vector3(vector.y, vector.y, vector.z);

    public static Vector3 yzx(this Vector3 vector) => new Vector3(vector.y, vector.z, vector.x);
    public static Vector3 yzy(this Vector3 vector) => new Vector3(vector.y, vector.z, vector.y);
    public static Vector3 yzz(this Vector3 vector) => new Vector3(vector.y, vector.z, vector.z);


    public static Vector3 zxx(this Vector3 vector) => new Vector3(vector.z, vector.x, vector.x);
    public static Vector3 zxy(this Vector3 vector) => new Vector3(vector.z, vector.x, vector.y);
    public static Vector3 zxz(this Vector3 vector) => new Vector3(vector.z, vector.x, vector.z);

    public static Vector3 zyx(this Vector3 vector) => new Vector3(vector.z, vector.y, vector.x);
    public static Vector3 zyy(this Vector3 vector) => new Vector3(vector.z, vector.y, vector.y);
    public static Vector3 zyz(this Vector3 vector) => new Vector3(vector.z, vector.y, vector.z);

    public static Vector3 zzx(this Vector3 vector) => new Vector3(vector.z, vector.z, vector.x);
    public static Vector3 zzy(this Vector3 vector) => new Vector3(vector.z, vector.z, vector.y);
    public static Vector3 zzz(this Vector3 vector) => new Vector3(vector.z, vector.z, vector.z);

    #endregion Vector3
}
