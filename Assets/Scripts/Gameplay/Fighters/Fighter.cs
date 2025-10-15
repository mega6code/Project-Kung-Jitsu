using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Gameplay.Fighters
{

    public class Fighter : MonoBehaviour
    {
        private string f_name;
        private string f_title;

        //protected string Name { get => name; set => name = value; }
        //protected string Title { get => title; set => title = value; }

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

    //public class GregFighter : Fighter
    //{
    //    public override void Ability()
    //    {

    //    }
    //    public GregFighter() 
    //    {
    //        fighter_name = "Greg";
    //        fighter_title = "the Fighter";
    //    }
    //}







    //public static class FighterData
    //{
    //    public static List<ArrayList> greg_base = new List<ArrayList>() 
    //    {
    //        new ArrayList() {"Greg"},
    //        new ArrayList() {"Evil Greg"},
    //    };
    //}



}
