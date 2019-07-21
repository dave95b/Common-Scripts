using UnityEngine;
using System.Collections;

public abstract class CameraDataPreparer : MonoBehaviour
{
    public abstract CameraData Prepare(in CameraData data);
}
