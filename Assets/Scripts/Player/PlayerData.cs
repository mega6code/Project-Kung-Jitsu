using Fighters;

namespace Player
{
    public struct PlayerData
    {
        public Player player;
        public AttackTypes attack_type;

        public PlayerData(Player player, AttackTypes attackType)
        {
            this.player = player;
            this.attack_type = attackType;
        }
    }
}