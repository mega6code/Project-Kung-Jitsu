using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Fighters
{
    public class Fighter : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private string f_name;
        [SerializeField]
        private string f_title;
        [SerializeField]
        private int energy;
        [SerializeField]
        private AttackTypes attack_choice = AttackTypes.NoAttack;

        private AttackType current_attack_type = new NoAttack();
        #endregion

        #region Properties
        public string F_name { get => f_name;}
        public string F_title { get => f_title;}
        #endregion

        #region Methods
        private void ChangeAttackType()
        {
            switch (this.attack_choice)
            {
                case AttackTypes.NoAttack:
                    this.current_attack_type = new NoAttack();
                    break;
                case AttackTypes.Kick:
                    this.current_attack_type = new Kick();
                    break;
                case AttackTypes.Punch:
                    this.current_attack_type = new Punch();
                    break;
                case AttackTypes.Grab:
                    this.current_attack_type = new Grab();
                    break;
            }
        }
        #endregion

        #region Events
        public void OnChangeAttackChoice(AttackTypes attack_choice)
        {
            this.attack_choice = attack_choice;
        }

        #endregion





    }
}
