//using System.Threading;
//using System;
//using Unity.VisualScripting;
//using UnityEngine;
//using Gameplay.Fighters;

//namespace Gameplay
//{
//    public class BattleManager : MonoBehaviour
//    {
//        //stuff stuff
//        public GameObject Player1;
//        public GameObject Player2;
//        public GameObject FightingPlatform;

//        //stuff stuff on da inside
//        private AttackTypes p1_atkchoice;
//        private AttackTypes p2_atkchoice;
//        private FightingPlatformStuff FPStuff;

//        //num stuff
//        private int atkchoice_result;
//        private int turn_winner;     
//        private float reposition_distance;

//        //timers and stuff
//        private float timer = 10;  //the actual live timer
//        public float fightprep_time = 10; //how long until fight auto ends
//        public float fight_time = 2; //how long the fight lasts in seconds

//        //bools and balls
//        private bool IsFightTime = false;
//        private bool IsPostFight = false;


//        //Even if u cannot punch, stand, see, feel, or breath, so long as u have the will to, you can fight.


//        void OnEnable()
//        {
//            Player1.GetComponent<PlayerCore>().MatchStartPositioning();
//            Player2.GetComponent<PlayerCore>().MatchStartPositioning();
//            Player1.GetComponent<PlayerControls>().enabled = true;
//            Player2.GetComponent<PlayerControls>().enabled = true;
//            Debug.Log("MATCH START!");
//        }

//        private void OnDisable()
//        {
//            FPStuff.enabled = false;
//            gameObject.GetComponent<ChiefGameManager>().enabled = true;
//            Debug.Log("MATCH OVER!");
//        }

//        void Update()
//        {
//            if (IsPostFight)
//            {
//                PostFight();
//            }
//            else if (IsFightTime)
//            {
//                Fight();
//            }
//            else
//            {
//                if (IsFightPrepDone())
//                {
//                    DetermineFightWinner();
//                    Player1.GetComponent<PlayerControls>().enabled = false;
//                    Player2.GetComponent<PlayerControls>().enabled = false;
//                    timer = fight_time;
//                    IsFightTime = true;
//                }
//            }
//        }

//        private void FighterAssigning(Player player, Fighter selected_fighter)
//        {
            
//           player.GetComponent<PlayerCore>().Current_fighter.DisableFighter();
//           player.GetComponent<PlayerCore>().Current_fighter = selected_fighter;
//        }
//        //private 
//        private bool IsFightPrepDone()
//        {
//            p1_atkchoice = Player1.GetComponent<PlayerControls>().Attack_choice;
//            p2_atkchoice = Player2.GetComponent<PlayerControls>().Attack_choice;

//            Debug.Log($"P1 Currently: {p1_atkchoice}");
//            Debug.Log($"P2 Currently: {p2_atkchoice}");

//            if (!(p1_atkchoice == AttackTypes.None) || !(p2_atkchoice == AttackTypes.None))
//            {
//                Countdown();

//                if (timer <= 0 || (!(p1_atkchoice == AttackTypes.None) && !(p2_atkchoice == AttackTypes.None)))
//                {
//                    Debug.Log("FIGHT TIMEEEEEE");
//                    return true;
//                }
//            }
//            else
//            {
//                timer = fightprep_time;
//            }
//                return false;
//        }

//        private void Countdown() 
//        {
//            timer -= Time.deltaTime;
//            Debug.Log(Convert.ToInt32(timer));
//        }

//        /* 1 = p1 wins | 2 = p2 wins | 0 = draw */
//        private void DetermineFightWinner() 
//        {

//            if (p1_atkchoice == p2_atkchoice)
//            {
//                FightResult(0);

//            }
//            else if (p1_atkchoice == 0)
//            {
//                FightResult(2);
//            }
//            else if (p2_atkchoice == 0)
//            {
//                FightResult(1);
//            }
//            else
//            {
//                atkchoice_result = p1_atkchoice - p2_atkchoice;
//                switch (atkchoice_result)
//                {
//                    case -2:
//                        FightResult(2);
//                        break;
//                    case -1:
//                        FightResult(1);
//                        break;
//                    case 1:
//                        FightResult(2);
//                        break;
//                    case 2:
//                        FightResult(1);
//                        break;
//                }
//            }
//        }
        
//        /// <summary>
//        /// Used within DetermineFightWinner() to log fight result
//        /// </summary>
//        private void FightResult(int winner)
//        {
//            Debug.Log($"Player {winner} wins the Turn! :D");

//            switch (winner)
//            {
//                case 1:
//                    turn_winner = 1;          
//                    break;
//                case 2:
//                    turn_winner = 2;
//                    break;
//                case 0:                  
//                    turn_winner = 0;               
//                    break;
//            }
//        }
        

//        private void Fight()
//        {
//            Countdown();
//            if (timer <= 0)
//            {
//                IsFightTime = false;
//                IsPostFight = true;
//            }
//            else
//            {
//                switch (turn_winner)
//                {
//                    case 1:
//                        Player2.GetComponent<PlayerCore>().MoveBackwards(2);
//                        break;
//                    case 2:
//                        Player1.GetComponent<PlayerCore>().MoveBackwards(2);
//                        break;
//                    case 0:
//                        if (timer > (fight_time / 2))
//                        {
//                            Player1.GetComponent<PlayerCore>().MoveBackwards(1);
//                            Player2.GetComponent<PlayerCore>().MoveBackwards(1);
//                        }
//                        else
//                        {
//                            //lmao will this work
//                            Player1.GetComponent<PlayerCore>().MoveForward(1);
//                            Player2.GetComponent<PlayerCore>().MoveForward(1);

//                        }
//                        break;
//                }
//            }

//        }

//        private void PostFight()
//        {
//            if (CheckIfPlayerIsKO(Player1))
//            {
//                this.enabled = false;
//            }
//            else if (CheckIfPlayerIsKO(Player2))
//            {
//                this.enabled = false;
//            }
//            else
//            {
//                if (turn_winner != 0)
//                {
//                    reposition_distance = Math.Abs(Player1.transform.position.z - Player2.transform.position.z);

//                    switch (turn_winner)
//                    {
//                        //p1 runs up to p2 (cause p2 he got bonked)
//                        case 1:
//                            if (!(reposition_distance == 2))
//                            {
//                                Player1.GetComponent<PlayerCore>().MoveForward(2);
//                            }
//                            else
//                            {
//                                turn_winner = 0;
//                            }
//                            break;

//                        //p2 runs up to p1 (cause p1 got bonked)
//                        case 2:
//                            if (!(reposition_distance == 2))
//                            {
//                                Player1.GetComponent<PlayerCore>().MoveForward(2);
//                            }
//                            else
//                            {
//                                turn_winner = 0;
//                            }
//                            break;
//                    }

//                }
//                else
//                {
//                    Player1.GetComponent<PlayerControls>().Attack_choice = AttackTypes.None;
//                    Player2.GetComponent<PlayerControls>().Attack_choice = AttackTypes.None;
//                    timer = fightprep_time;
//                    Player1.GetComponent<PlayerControls>().enabled = true;
//                    Player2.GetComponent<PlayerControls>().enabled = true;
//                    IsPostFight = false;
//                }
//            }     
            
//        }
//        //private bool CheckIfPlayerIsKO(GameObject player)
//        //{
//        //    if ((player.GetComponent<Transform>().position.z <= FPStuff.Leftside_limit) || (player.GetComponent<Transform>().position.z >= FPStuff.Rightside_limit))
//        //    {
//        //        player.GetComponent<Rigidbody>().useGravity = true;
//        //        return true;
//        //    }
//        //    return false;
//        //}
//    } 
//}
