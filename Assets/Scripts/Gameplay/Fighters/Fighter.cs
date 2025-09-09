using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Gameplay.Fighters
{

    public class Fighter : MonoBehaviour
    {
        protected string fighter_name;
        protected string fighter_subname;
        public string Fighter_name { get { return Fighter_name; } }
        public string Fighter_subname { get => fighter_subname; }

        public virtual void Ability()
        {

        }
        public void DisableFighter()
        {
            this.enabled = false;
        }
        public void EnableFighter()
        {
            this.enabled = true;
        }
        public Fighter()
        {
            this.enabled = false;
        }
    }

    public class GregFighter : Fighter
    {
        public override void Ability()
        {

        }
        public GregFighter() 
        {
            fighter_name = "Greg";
            fighter_subname = "the Fighter";
        }
    }







    //public static class FighterData
    //{
    //    public static List<ArrayList> greg_base = new List<ArrayList>() 
    //    {
    //        new ArrayList() {"Greg"},
    //        new ArrayList() {"Evil Greg"},
    //    };
    //}



}
