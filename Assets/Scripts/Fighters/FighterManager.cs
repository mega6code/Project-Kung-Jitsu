using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Fighters
{
    public class FighterManager : MonoBehaviour
    {

        #region Fields
        [SerializeField] private Player player;

        private Fighter fighter;
        #endregion

        #region Methods
        private void Awake()
        {
            player.ChoosingAttack += OnChoosingAttack;
        }

        private void LockInFighter()
        {
            fighter = gameObject.GetComponentInChildren<Fighter>();
            fighter.SetFighterManager(this);
        }
        #endregion

        #region Event Methods
        private void OnMatchStart()
        {
            LockInFighter();
        }
        private void OnBattleStart()
        {

        }
        private void OnChoosingAttack(object sender, AttackTypes e)
        {
            ChoseAttack.Invoke(this, e);
        }
        #endregion

        #region Events
        public event EventHandler<AttackTypes> ChoseAttack;
        #endregion
    }

}