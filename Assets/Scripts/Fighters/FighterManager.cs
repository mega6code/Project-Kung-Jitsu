using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KungJitsu.Fighters
{
    public class FighterManager : MonoBehaviour
    {

        #region Fields
        [SerializeField] public FighterDatabase fighterDatabase;
        private Fighter player1;
        private Fighter player2;
        private List<Fighter> other_players;
        #endregion

        #region Events
        public event Action<AttackTypes> ChoseAttack;
        #endregion
        
        #region Methods
        /// <summary>
        /// Instantiate a Fighter prefab
        /// </summary>
        /// <param name="fighterName"></param>
        /// <param name="transform"></param>
        /// <param name="playerNumber">1 = player1; 2 = player2;</param>
        public void InstantiateFighter(FighterNames fighterName, Transform transform, int playerNumber = -1)
        {
            //int fighterID = int(fighterName);
            GameObject fighter = fighterDatabase.listOfAllFighters[0];
            fighter = Instantiate(fighter, transform);
            
            //assigns the Fighter component of the Fighter prefab that was just initialized
            switch(playerNumber)
            {
                case 1:
                    player1 = fighter.GetComponent<Fighter>();
                    break;
                case 2:
                    player2 = fighter.GetComponent<Fighter>();
                    break;
                default:
                    other_players.Add(fighter.GetComponent<Fighter>());
                    break;
            }
        }
        #endregion

    }
}