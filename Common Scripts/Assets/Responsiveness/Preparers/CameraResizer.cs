using UnityEngine;
using System.Collections.Generic;

namespace Common.Responsiveness
{
    public class CameraResizer : CameraDataPreparer
    {
        [SerializeField]
        private Transform boundBottomLeft, boundTopRight;

        public override CameraData Prepare(in CameraData data)
        {
            Vector3 bottomLeft = boundBottomLeft.position;
            Vector3 topRight = boundTopRight.position;

            float width = bottomLeft.x - topRight.x;
            float height = topRight.y - bottomLeft.y;

            float targetHeight = Mathf.Max(height, width / data.AspectRatio) / 2f;

            var camera = data.Camera;
            camera.orthographicSize = targetHeight;

            float verticalCenter = (bottomLeft.y + topRight.y) / 2f;
            Vector3 cameraPosition = camera.transform.position;
            cameraPosition.y = verticalCenter;
            camera.transform.position = cameraPosition;

            return new CameraData(camera);
        }
    }
}