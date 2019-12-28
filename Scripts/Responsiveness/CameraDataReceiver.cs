using UnityEngine;

namespace Common.Responsiveness
{
    public abstract class CameraDataReceiver : MonoBehaviour
    {
        public abstract void ReceiveCameraData(in CameraData data);
    }
}