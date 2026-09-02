using KungJitsu.Fighters;
using UnityEngine.InputSystem;

namespace KungJitsu.Players
{
    public struct PlayerData
    {
        public PlayerInput playerInput;
        public AttackTypes attack_type;
        
        public PlayerData(AttackTypes attackType, PlayerInput playerInput = null)
        {
            this.playerInput = playerInput;
            this.attack_type = attackType;
        }
    }
}