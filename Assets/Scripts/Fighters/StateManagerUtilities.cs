using System;
using System.Collections.Generic;
using KungJitsu.Interfaces;
using UnityEngine;

namespace Fighters
{
    [Serializable]
    public struct StateManagerUtilities
    {
        public bool ChangeState<K, V>(K key, Dictionary<K, V> states, out V current_state)
        {
            if (states.TryGetValue(key, out V state))
            {
                current_state = state;
                return true;
            }
            else
            {
                current_state = default(V);
                return false;
                
            }
        }
        //public StateManagerUtilities() { 
        //}
        //public StateManagerUtilities(List<Component> listOfStates)
        //{
        //    states = new Dictionary<Enum, T>();
        //    foreach (var state in listOfStates)
        //    {

        //        this.states.Add(, state);

        //    }
        //}

    }
}