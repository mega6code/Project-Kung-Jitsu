using System;
using System.Collections.Generic;
using KungJitsu.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace KungJitsu.Fighters
{
    public class FightStateManager : MonoBehaviour
    {
        #region Fields
        private Dictionary<AttackTypes, FightState> states;
        private FightState current_state;
        #endregion

        #region Properties
        #endregion
        
        #region Events
        public event Action<HitData> stateGotHit;
        public event Action<HitData> stateBlocked;
        public event Action<HitData> stateDrawed;
        #endregion

        #region Methods
        public bool ChangeState(AttackTypes attackType)
        {
            if (states.TryGetValue(attackType, out FightState state))
            {
                current_state = state;
                return true;
            }
            else
            {
                current_state = new NoAttackState();
                return false;
            }
        }

        public bool IsStateCurrently(AttackTypes attackType)
        {
            return current_state.Equals(states[attackType]);
        }

        public void IncomingAttack(HitData hit_data)
        {
            current_state.IncomingAttack(hit_data);
        }

        private void Awake()
        {
            states = new Dictionary<AttackTypes, FightState>()
            {
                {AttackTypes.NoAttack, new NoAttackState()},
                {AttackTypes.Kick, new KickState()},
                {AttackTypes.Punch, new PunchState()},
                {AttackTypes.Grab, new GrabState()}
            };
            
            //Debug.Log($"{this.name}'s states[0] is {states[0]} and is null?: {states[10].IsUnityNull()}");
            current_state = states[AttackTypes.NoAttack];
            
        }

        private void OnEnable()
        {
            foreach(KeyValuePair<AttackTypes, FightState> kvp in states)
            {
                //FightState fightState = states[e.Current.Key];
                
                // Debug.Log($"{this.name}'s states Enumartor is currently {states.GetEnumerator().Current.Key} and the e is {e}, {e.Current.Key}, {e.Current.Value}");
                // Debug.Log($"{this.name}'s fightState var is now {fightState.GetType().Name}");
                // Debug.Log($"{this.name}'s OnEnable loop is currently at {i}");
                
                kvp.Value.gotHit += OnGotHit;
                kvp.Value.drawed += OnDrawed;
                kvp.Value.blocked += OnBlocked;
            }
        }

        private void OnDisable()
        {
            foreach(KeyValuePair<AttackTypes, FightState> kvp in states)
            {
                kvp.Value.gotHit += OnGotHit;
                kvp.Value.drawed += OnDrawed;
                kvp.Value.blocked += OnBlocked;
            }
        }
        
        private void OnGotHit(HitData hitData)
        {
            stateGotHit?.Invoke(hitData);
        }

        private void OnDrawed(HitData hitData)
        {
            stateDrawed?.Invoke(hitData);
        }

        private void OnBlocked(HitData hitData)
        {
            stateBlocked?.Invoke(hitData);
        }
        #endregion
    }
}
