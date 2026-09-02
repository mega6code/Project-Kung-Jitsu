using System;
using KungJitsu.Interfaces;
using UnityEngine;

namespace KungJitsu.Fighters
{
    public class KickState : FightState
    {
        #region Methods
        protected override void ReceiveKick(HitData hitData)
        {
            Draw(hitData);
        }

        protected override void ReceivePunch(HitData hitData)
        {
            Block(hitData);
        }

        protected override void ReceiveGrab(HitData hitData)
        {
            GotHit(hitData);
        }
        #endregion
    }
}
