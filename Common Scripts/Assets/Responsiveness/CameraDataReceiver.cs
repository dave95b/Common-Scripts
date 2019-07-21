using UnityEngine;

public abstract class CameraDataReceiver : MonoBehaviour
{
    public abstract void ReceiveCameraData(in CameraData data);
}
