using System;
using Fighters;
using Player;
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

        /*private void OnEnable()
    {
        playerManager.PlayerChoseAttack += Player
    }*/

        #endregion

    }

}