
using UnityEngine;

namespace Fighters
{
    public class FightStyleManager : MonoBehavior
    {
        [SerializeField] private Dictionary<AttackTypes, FightStyle> fightStyles;
    
    }
    
    public class FightStyle : Style 
    {
        protected AnimationClip specialAnimation;
    
    }
    
    // Holds animation clips of a particular action,
    // like if u wanted to randomize a certain action's aniamtion
    // but with a set of similar animations(different punches, kciks, walks, etc...).
    [Serizable]
    public class Style
    {
        protected <AnimationClip> animations;
    }

    public class FightStyle_All : ScriptableObject
    {
        List<FightStyle> allFightStyles;
    }
}

