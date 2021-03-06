﻿using UnityEngine;

namespace Common.Responsiveness
{
    public abstract class CameraDataPreparer : MonoBehaviour
    {
        public abstract CameraData Prepare(in CameraData data);
    }
}