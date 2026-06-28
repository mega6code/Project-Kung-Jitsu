using Fighters;

namespace KungJitsu.Interfaces
{
    interface IAttackState
    {
        void ReceiveHit(HitData hit_data);
    }
}