using NaughtyAttributes;
using System.Linq;
using UnityEngine;

namespace Common.Responsiveness
{
    public partial class CameraDataBroadcaster : MonoBehaviour
    {
        public Camera Camera;

        [SerializeField, InfoBox("Can be null if there's nothing to do with the camera before the broadcast.")]
        private CameraDataPreparer preparer;

        [SerializeField, ReorderableList]
        private CameraDataReceiver[] receivers = new CameraDataReceiver[1];


        private void Awake()
        {
            var cameraData = new CameraData(Camera);

            if (preparer != null)
                cameraData = preparer.Prepare(cameraData);

            Broadcast(cameraData);
        }

        public void Broadcast()
        {
            var cameraData = new CameraData(Camera);
            Broadcast(cameraData);
        }

        private void Broadcast(in CameraData cameraData)
        {
            foreach (var handler in receivers)
                handler.ReceiveCameraData(cameraData);
        }

    }

#if UNITY_EDITOR
    public partial class CameraDataBroadcaster
    {
        [Button("Find Handlers")]
        private void FindHanlders()
        {
            receivers = FindObjectsOfType<MonoBehaviour>().OfType<CameraDataReceiver>().ToArray();
        }
    }
#endif
}