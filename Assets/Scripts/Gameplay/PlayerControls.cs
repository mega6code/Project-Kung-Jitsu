using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;


namespace Gameplay {

    public enum AttackTypes { None, Kick, Punch, Grab }
    public class PlayerControls : MonoBehaviour
    {
        #region Fields
        public AttackTypes attack_choice;
        public InputActionAsset action_asset;
        private Player player;
        public int player_num;
        private InputActionMap action_map;
        private InputAction kick_IA;
        private InputAction punch_IA;
        private InputAction grab_IA;
        
        #endregion


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //player = gameObject.GetComponent<Player>();
            //player.player_number = player_num;
            action_map = action_asset.FindActionMap($"P{player_num}Combat");
            kick_IA = action_map.FindAction("Kick");
            punch_IA = action_map.FindAction("Punch");
            grab_IA = action_map.FindAction("Grab");
            attack_choice = AttackTypes.None;

        }

        // Update is called once per frame
        void Update()
        {
            if (kick_IA.IsPressed())
            {
                if (player_num == 2)
                {
                    Debug.Log("KICK2!!!!!!!!!!!!!!");

                }
                else
                {
                    Debug.Log("KICK1!!!!!!!!!!!!!!");
                   
                }
                attack_choice = AttackTypes.Kick;
            }
            else if (punch_IA.IsPressed())
            {
                if (player_num == 2)
                {
                    Debug.Log("Punchhhhhh2!!!!!!!!!!!!!!");

                }
                else
                {
                    Debug.Log("Punchchhh1!!!!!!!!!!!!!!");
                    
                }
                attack_choice = AttackTypes.Punch;
            }
            else if (grab_IA.IsPressed())
            {
                if (player_num == 2)
                {
                    Debug.Log("Grabbbbb2!!!!!!!!!!!!!!");

                }
                else
                {
                    Debug.Log("Grabbbbb1!!!!!!!!!!!!!!");
                }
                attack_choice = AttackTypes.Grab;
            }

        }
    }
    
}
