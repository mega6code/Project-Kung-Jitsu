using System;
using System.Collections.Generic;
using KungJitsu.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace Fighters
{
    public class FightStateManager: MonoBehaviour
    {
        //private StateManagerUtilities utilities;
        //private Dictionary<AttackTypes, FightState> states;
        private FightState current_state;
        private void Start()
        {
            

            
        }
        
        private Action<HitData> OnGotHit()
        {
            gotHit
        }

        public void ChangeState()
        {
            
        }
        public void ReceiveHit(HitData hit_data)
        {
            current_state.ReceiveHit(hit_data);
        }
        
        
    }
}