using System;
using KungJitsu.Interfaces;
using UnityEngine;

namespace KungJitsu.Fighters
{
    public class NoAttackState : FightState
    {
        #region Methods
        protected override void ReceiveKick(HitData hitData)
        {
            GotHit(hitData);
        }

        protected override void ReceivePunch(HitData hitData)
        {
            GotHit(hitData);
        }

        protected override void ReceiveGrab(HitData hitData)
        {
            GotHit(hitData);
        }
        #endregion
    }
}
