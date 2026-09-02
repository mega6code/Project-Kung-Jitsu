using System.Collections.Generic;
using UnityEngine;

namespace KungJitsu.Fighters
{
    [CreateAssetMenu(menuName = "Kung-Jitsu/Fighters/FightersDataBase")]
    public class FighterDatabase : ScriptableObject
    {
        [SerializeField] public List<GameObject> listOfAllFighters;
    }
}