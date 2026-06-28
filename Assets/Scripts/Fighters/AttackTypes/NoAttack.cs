using System;
using KungJitsu.Interfaces;
using UnityEngine;

namespace Fighters
{
    public class NoAttackState : MonoBehaviour, IAttackState
    {
        public event Action gotHit;

        public void ReceiveHit()
        {
            gotHit.Invoke();
        }
    }
}
