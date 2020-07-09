﻿using UnityEngine.Timeline.Data;

namespace UnityEngine.Timeline
{
    [MarkUsage(AssetType.Marker)]
    public class XJumpMarker : XMarker, ISharedObject<XJumpMarker>
    {
        private JumpMarkData _data;

        public XJumpMarker next { get; set; }

        public float jump
        {
            get { return _data.jump; }
            set { _data.jump = value; }
        }

        protected override void OnPostBuild()
        {
            base.OnPostBuild();
            _data = (JumpMarkData)Data;
        }


        public override void OnTriger()
        {
            base.OnTriger();
            if (jump != timeline.Time)
            {
                timeline.JumpTo(jump);
            }
        }

        public override void OnDestroy()
        {
            SharedPool<XJumpMarker>.Return(this);
            base.OnDestroy();
        }

        public void Dispose()
        {
            next = null;
        }
    }
}
