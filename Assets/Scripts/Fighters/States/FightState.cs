using System;
using KungJitsu.Interfaces;
using UnityEngine;


namespace KungJitsu.Fighters
{
    public abstract class FightState : KungJitsu.Interfaces.IState
    {

        #region Events
        public event Action<HitData> gotHit;
        public event Action<HitData> blocked;
        public event Action<HitData> drawed;
        #endregion

        #region Methods
        public virtual void IncomingAttack(HitData hitData)
        {
            CheckAttackTypeReceived(hitData);
        }

        protected abstract void ReceiveKick(HitData hitData);

        protected abstract void ReceivePunch(HitData hitData);

        protected abstract void ReceiveGrab(HitData hitData);

        protected void CheckAttackTypeReceived(HitData hitData)
        {
            switch (hitData.attack_type)
            {
                case AttackTypes.Kick:
                {
                    ReceiveKick(hitData);
                    break;
                }
                case AttackTypes.Punch:
                {
                    ReceivePunch(hitData);
                    break;
                }
                case AttackTypes.Grab:
                {
                    ReceiveGrab(hitData);
                    break;
                }
            }
        }

        protected void Draw(HitData hitData)
        {
            drawed?.Invoke(hitData);
        }
        protected void Block(HitData hitData)
        {
            blocked?.Invoke(hitData);
        }
        protected void GotHit(HitData hitData)
        {
            gotHit?.Invoke(hitData);
        }
        #endregion
       
    }
}
