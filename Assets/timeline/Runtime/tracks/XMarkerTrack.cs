﻿using System;
using UnityEngine.Timeline.Data;

namespace UnityEngine.Timeline
{
    public class XMarkerTrack : XTrack, ISharedObject<XMarkerTrack>
    {

        public XMarkerTrack next { get; set; }

        public override AssetType AssetType
        {
            get { return AssetType.Marker; }
        }

        public override bool cloneable
        {
            get { return false; }
        }

        public override XTrack Clone()
        {
            throw new Exception("mark track is uncloneable");
        }

        public XMarkerTrack() 
        {
        }

        public override IClip BuildClip(ClipData data)
        {
            throw new System.Exception("marker no clip");
        }

        public override void OnDestroy()
        {
            SharedPool<XMarkerTrack>.Return(this);
            base.OnDestroy();
        }

        public void Dispose()
        {
            next = null;
        }
    }
}
