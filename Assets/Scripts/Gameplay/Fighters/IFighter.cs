using System.Threading;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Gameplay.Fighters
{

    public class Fighter
    {
        protected string name;
        //protected Ability ability;

        public Fighter(ArrayList fighter_base)
        {

            name = fighter_base[0].ToString();
            //ability = 

        }

    }

    public static class FighterData
    {
        public static List<ArrayList> greg_base = new List<ArrayList>() 
        {
            new ArrayList() {"Greg"},
            new ArrayList() {"Evil Greg"},
        };
        

       
  
    }



}
