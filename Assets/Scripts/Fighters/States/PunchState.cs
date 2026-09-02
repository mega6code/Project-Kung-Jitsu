using System;
using KungJitsu.Interfaces;
using UnityEngine;

namespace KungJitsu.Fighters
{
    public class PunchState : FightState
    {
        #region Methods
        protected override void ReceiveKick(HitData hitData)
        {
            GotHit(hitData);
        }

        protected override void ReceivePunch(HitData hitData)
        {
            Draw(hitData);
        }

        protected override void ReceiveGrab(HitData hitData)
        {
            Block(hitData);
        }
        #endregion
    }
}
