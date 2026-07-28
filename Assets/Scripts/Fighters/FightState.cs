using System;
using KungJitsu.Interfaces;
using UnityEngine;

namespace Fighters
{
    public class FightState : MonoBehaviour
    {
        protected static void CheckAttackTypeReceived(FightState fightState, HitData hitData)
        {
            switch (hitData.attack_type)
            {
                case AttackTypes.Kick:
                    {
                        fightState.ReceiveKick(hitData);
                        break;
                    }
                case AttackTypes.Punch:
                    {
                        fightState.ReceivePunch(hitData);
                        break;
                    }
                case AttackTypes.Grab:
                    {
                        fightState.ReceiveGrab(hitData);
                        break;
                    }
            }

        }

        public event Action<HitData> gotHit;
        public event Action<HitData> blocked;
        public event Action<HitData> drawed;

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
        public virtual void ReceiveHit(HitData hitData)
        {
            throw new NotImplementedException();
        }
        protected virtual void ReceiveKick(HitData hitData)
        {
            throw new NotImplementedException();
        }
        protected virtual void ReceivePunch(HitData hitData)
        { 
            throw new NotImplementedException(); 
        }
        protected virtual void ReceiveGrab(HitData hitData)
        {
            throw new NotImplementedException();
        }
    }
}