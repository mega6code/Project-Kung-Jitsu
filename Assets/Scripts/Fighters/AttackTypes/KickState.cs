using System;
using KungJitsu.Interfaces;
using UnityEngine;
using static UnityEngine.Analytics.IAnalytic;

namespace Fighters
{
    public class KickState : FightState
    {
        #region Methods
        public override void ReceiveHit(HitData hitData)
        {
            CheckAttackTypeReceived(this, hitData);
        }
        
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