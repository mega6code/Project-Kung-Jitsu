using System;
using KungJitsu.Interfaces;
using UnityEngine;

namespace KungJitsu.Fighters
{
    public class GrabState : FightState
    {
        #region Methods
        protected override void ReceiveKick(HitData hitData)
        {
            Block(hitData);
        }

        protected override void ReceivePunch(HitData hitData)
        {
            GotHit(hitData);
        }

        protected override void ReceiveGrab(HitData hitData)
        {
            Draw(hitData);
        }
        #endregion
    }
}
