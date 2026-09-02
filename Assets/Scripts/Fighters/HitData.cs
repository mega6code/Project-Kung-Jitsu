namespace KungJitsu.Fighters
{
    public struct HitData
    {
        public AttackTypes attack_type;
        public float launch_angle;
        public float launch_distance;

        public HitData(AttackTypes attack_type, float launch_angle = 0, float launch_distance = 1)
        {
            this.attack_type = attack_type;
            this.launch_angle = launch_angle;
            this.launch_distance = launch_distance;
        }
    }
}