using UnityEngine;

namespace Common.Responsiveness
{
    public readonly struct CameraData
    {
        public readonly Camera Camera;
        public readonly float AspectRatio, Width, Height, SizeToPixelRatio;

        public CameraData(Camera camera)
        {
            Camera = camera;
            AspectRatio = camera.aspect;
            Height = camera.orthographicSize * 2f;
            Width = AspectRatio * Height;
            SizeToPixelRatio = camera.orthographicSize / camera.pixelHeight;
        }
    }
}