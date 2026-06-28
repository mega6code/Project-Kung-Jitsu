using System;
using System.Collections.Generic;
using KungJitsu.Interfaces;
using UnityEngine;

namespace Fighters
{
    public class AttackStateManager : MonoBehaviour
    {
        [SerializeField] private List<IAttackState> attackStates;

        private IAttackState current_state = new NoAttackState();

        public void ReceiveHit(HitData hit_data)
        {
            current_state.ReceiveHit(hit_data);
        }
    }
}