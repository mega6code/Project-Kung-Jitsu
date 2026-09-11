using System;
using KungJitsu.Fighters;
using KungJitsu.Players;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


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
        [SerializeField] private Camera battleCamera;

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
            playerManager.P1GoBack += OnP1GoBack;
            playerManager.P2ChoseAttack += OnP2ChoseAttack;
            playerManager.P2GoBack += OnP2GoBack;
            
            fighter1.gotKKnocked += OnGotKKnocked;
            fighter1.landed += OnLanded;
            fighter2.gotKKnocked += OnGotKKnocked;
            fighter2.landed += OnLanded;
        }

        private void OnDisable()
        {
            playerManager.P1ChoseAttack -= OnP1ChoseAttack;
            playerManager.P1GoBack -= OnP1GoBack;
            playerManager.P2ChoseAttack -= OnP2ChoseAttack;
            playerManager.P2GoBack -= OnP2GoBack;
            
            fighter1.gotKKnocked -= OnGotKKnocked;
            fighter1.landed -= OnLanded;
            fighter2.gotKKnocked -= OnGotKKnocked;
            fighter2.landed -= OnLanded;
        }

        private void OnGotKKnocked(Camera fighterCamera)
        {
            battleCamera.enabled = false;
            fighterCamera.enabled = true;
        }
        
        private void OnLanded(Camera fighterCamera, Transform fighterSpace)
        {
            battleCamera.transform.position = new Vector3(battleCamera.transform.position.x, 
                battleCamera.transform.position.y, 
                fighterSpace.transform.position.z);
            Debug.Log($"{this.name}: {battleCamera.transform.position.x}, {battleCamera.transform.position.y}, {fighterSpace.transform.position.z}");
            //mainCamera.gameObject.transform.
            battleCamera.enabled = true;
            
            fighterCamera.enabled = false;
        }

        private void OnP1GoBack()
        {
            fighter1.ChangeAttackChoice(AttackTypes.NoAttack);
        }

        private void OnP2GoBack()
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