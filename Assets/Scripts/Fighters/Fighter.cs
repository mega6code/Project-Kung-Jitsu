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

        private FighterManager f_manager;
        private AttackType current_attack_type = new NoAttack();
        #endregion

        #region Properties
        public string F_name { get => f_name;}
        public string F_title { get => f_title;}
        #endregion

        #region Methods
        public void SetFighterManager(FighterManager fm)
        {
            f_manager = fm;
            f_manager.ChoseAttack += OnChoseAttack;
        }
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

        #region Event Methods
        private void OnChoseAttack(object sender, AttackTypes e)
        {
            this.attack_choice = e;
        }
        #endregion

        #region Events
        #endregion








    }
}
