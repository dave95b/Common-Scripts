using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
public class Union<T1, T2>
{
    [FieldOffset(0)]
    private T1 value1;
    [FieldOffset(0)]
    private T2 value2;


}
