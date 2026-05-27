using System;
using UnityEngine;

namespace Fighters
{
    public class Fighter : MonoBehaviour
    {
        #region Fields
        [SerializeField] private string f_name;
        [SerializeField] private string f_title;
        [SerializeField] private int energy;
        [SerializeField] private AttackTypes attack_choice = AttackTypes.NoAttack;
        [SerializeField] Animator animator;
        
        private AttackType current_attack_type = new NoAttack();
        #endregion

        #region Properties
        public string F_name { get => f_name;}
        public string F_title { get => f_title;}
        #endregion
        
        #region Events
        #endregion

        #region Methods

        public void Attack()
        {
            animator.SetBool("attack", true);
        }

        public void GetHit()
        {
            
        }
        
        public void ChangeAttackType()
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

        /*private void OnCollisionEnter(Collision collision)
        {
            collision.gameObject.TryGetComponent()
            current_attack_type.OnCollisionEnter(collision.);
        }*/

        #endregion










    }
}
