using System;
using Fighters;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        #region Fields
        [SerializeField] private PlayerInputManager playerInputManager;
        #endregion

        #region Events

        public event Action<PlayerData> PlayerChoseAttack;

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

        private void OnPlayerJoined(PlayerInput playerInput)
        {
            playerInput.GetComponent<Player>().ChoseAttack += OnPlayerChoseAttack;
            DontDestroyOnLoad(playerInput.gameObject);
        }

        private void OnPlayerChoseAttack(PlayerData playerData)
        {
            PlayerChoseAttack.Invoke(playerData);
        }

        private void Start()
        {
            playerInputManager.JoinPlayer(playerIndex: 0, controlScheme: "Keyboard1", pairWithDevice: Keyboard.current);
            playerInputManager.JoinPlayer(playerIndex: 1, controlScheme: "Keyboard2", pairWithDevice: Keyboard.current);
        }

        #endregion
    }
}