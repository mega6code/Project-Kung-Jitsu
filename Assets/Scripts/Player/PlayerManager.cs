using System;
using System.Collections.Generic;
using KungJitsu.Fighters;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KungJitsu.Players
{
    public class PlayerManager : MonoBehaviour
    {
        #region Fields
        [SerializeField] private PlayerInputManager playerInputManager;
        private List<PlayerInput> players = new List<PlayerInput>();
        #endregion

        #region Properties

        public PlayerInputManager PlayerInputManager { get => playerInputManager; }

        public List<PlayerInput> Players { get => players; }

        #endregion


        #region Events

        public event Action<PlayerData> P1ChoseAttack;
        public event Action<PlayerData> P2ChoseAttack;
        public event Action P1GoBack;
        public event Action P2GoBack;
        public  event Action PlayerPause;

        #endregion

        #region Methods

        private void OnEnable()
        {
            playerInputManager.onPlayerJoined += OnPlayerJoined;
        }

        private void OnDisable()
        {
            playerInputManager.onPlayerLeft -= OnPlayerJoined;
        }
        private void Start()
        {
            ResetPlayers();
        }

        private void OnPlayerJoined(PlayerInput playerInput)
        {
            players.Add(playerInput);
            
            if (playerInput.playerIndex == 0 || playerInput.playerIndex == 2)
            {
                playerInput.actions["InBattle/Kick"].performed += OnP1Kick;
                playerInput.actions["InBattle/Punch"].performed += OnP1Punch;
                playerInput.actions["InBattle/Grab"].performed += OnP1Grab;
                playerInput.actions["InBattle/GoBack"].performed += OnP1GoBack;

            }
            else
            {
                playerInput.actions["InBattle/Kick"].performed += OnP2Kick;
                playerInput.actions["InBattle/Punch"].performed += OnP2Punch;
                playerInput.actions["InBattle/Grab"].performed += OnP2Grab;
                playerInput.actions["InBattle/GoBack"].performed += OnP2GoBack;
            }
            DontDestroyOnLoad(playerInput);
        }

        private void OnP1Kick(InputAction.CallbackContext obj)
        {
            P1ChoseAttack.Invoke(new PlayerData(AttackTypes.Kick));
        }
       
        private void OnP1Punch(InputAction.CallbackContext obj)
        {
            P1ChoseAttack.Invoke(new PlayerData(AttackTypes.Punch));
        }

        private void OnP1Grab(InputAction.CallbackContext obj)
        {
            P1ChoseAttack.Invoke(new PlayerData(AttackTypes.Grab));
        }
        private void OnP1GoBack(InputAction.CallbackContext obj)
        {
            P1GoBack.Invoke();
        }

        private void OnP2Kick(InputAction.CallbackContext obj)
        {
            P2ChoseAttack.Invoke(new PlayerData(AttackTypes.Kick));
        }

        private void OnP2Punch(InputAction.CallbackContext obj)
        {
            P2ChoseAttack.Invoke(new PlayerData(AttackTypes.Punch));
        }
        private void OnP2Grab(InputAction.CallbackContext obj)
        {
            P2ChoseAttack.Invoke(new PlayerData(AttackTypes.Grab));
        }
        
        private void OnP2GoBack(InputAction.CallbackContext obj)
        {
            P2GoBack.Invoke();
        }

        private void ResetPlayers()
        {
            players.Clear();
            playerInputManager.JoinPlayer(playerIndex: 0, controlScheme: "KeyboardP1", pairWithDevice: Keyboard.current);
            playerInputManager.JoinPlayer(playerIndex: 1, controlScheme: "KeyboardP2", pairWithDevice: Keyboard.current);
        }

        #endregion
    }
}