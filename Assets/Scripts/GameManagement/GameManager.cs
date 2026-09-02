using System;
using KungJitsu.Fighters;
using KungJitsu.Players;
using UnityEngine;
using UnityEngine.InputSystem;


namespace GameManagement
{
    public class GameManager : MonoBehaviour
    {
        #region Fields

        private static GameManager instance;

        //[SerializeField] private InputManager inputManager;
        //[SerializeField] private UIManager uiManager;
        [SerializeField] private PlayerManager playerManager;
        [SerializeField] private FighterManager fighterManager;
        
        //testingggggg
        [SerializeField] private Fighter fighter1;
        [SerializeField] private Fighter fighter2;

        #endregion

        #region Properties

        #endregion

        #region Methods

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void OnEnable()
        {
            playerManager.P1ChoseAttack += OnP1ChoseAttack;
            playerManager.P1GoBack += P1GoBack;
            playerManager.P2ChoseAttack += OnP2ChoseAttack;
            playerManager.P2GoBack += P2GoBack;
        }

        private void P1GoBack()
        {
            fighter1.ChangeAttackChoice(AttackTypes.NoAttack);
        }

        private void P2GoBack()
        {
            fighter2.ChangeAttackChoice(AttackTypes.NoAttack);
        }

        private void OnP1ChoseAttack(PlayerData obj)
        {
            fighter1.ChangeAttackChoice(obj.attack_type);
        }

        private void OnP2ChoseAttack(PlayerData obj)
        {
            fighter2.ChangeAttackChoice(obj.attack_type);
        }
        
        // private void OnPlayerChoseAttack(PlayerData obj)
        // {
        //     
        // }
        

        private void Update()
        {
            if (Keyboard.current.enterKey.isPressed)
            {
                foreach (PlayerInput player in playerManager.Players)
                {
                    player.SwitchCurrentActionMap("InBattle");
                }
                fighter1.EnterCombat();
                fighter2.EnterCombat();
            }
            
            if (Keyboard.current.spaceKey.isPressed)
            {
                fighter1.Attack();
                fighter2.Attack();
            }
        }

        #endregion

    }

}