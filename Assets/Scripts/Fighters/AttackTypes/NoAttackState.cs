using System;
using KungJitsu.Interfaces;
using UnityEngine;

namespace Fighters
{
    public class NoAttackState : MonoBehaviour, IAttackState
    {
        #region Fields
        #endregion

        #region Events
        private event Action<HitData> gotHit;
        private event Action<HitData> blocked;
        private event Action<HitData> drawed;
        #endregion

        #region Properties
        public Action<HitData> GotHit => gotHit;
        public Action<HitData> Blocked => blocked;
        public Action<HitData> Drawed => drawed;
        #endregion

        #region Methods
        public void ReceiveHit(HitData hitData)
        {
            IAttackState.CheckAttackTypeReceived(this, hitData);
        }

        public void ReceiveKick(HitData hitData)
        {
            gotHit?.Invoke(hitData);
        }

        public void ReceivePunch(HitData hitData)
        {
            gotHit?.Invoke(hitData);
        }

        public void ReceiveGrab(HitData hitData)
        {
            gotHit?.Invoke(hitData);
        }
        #endregion
    }
}
