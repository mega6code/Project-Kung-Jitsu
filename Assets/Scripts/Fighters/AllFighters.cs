using System.Collections.Generic;
using UnityEngine;

namespace Fighters
{
    [CreateAssetMenu(menuName = "Kung-Jitsu/Fighters/All Fighters")]
    public class AllFighters : ScriptableObject
    {
        [SerializeField] public Dictionary<FighterNames, GameObject> listOfAllFighters;
    }
}