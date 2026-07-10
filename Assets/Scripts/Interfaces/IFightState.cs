using System;
using Fighters;
using static UnityEngine.Analytics.IAnalytic;

namespace KungJitsu.Interfaces
{
    interface IFightState
    {
        static void CheckAttackTypeReceived(IFightState fightState, HitData hitData)
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

        Action<HitData> GotHit { get; }
        Action<HitData> Blocked { get; }
        Action<HitData> Drawed { get; }

        void ReceiveHit(HitData hitData);
        void ReceiveKick(HitData hitData);
        void ReceivePunch(HitData hitData);
        void ReceiveGrab(HitData hitData);

    }

}