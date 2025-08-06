using System.Threading;
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay
{
    public class BattleManager : MonoBehaviour
    {
        public GameObject Player1;
        public GameObject Player2;
        public GameObject FightingPlatform;

        private AttackTypes p1_atkchoice;
        private AttackTypes p2_atkchoice;
        private FightingPlatformStuff FPStuff;
        private int atkchoice_result;
        private int turn_winner;     
        private int attack_strength = 2;

        private float timer = 10;  //the actual live timer
        public float fightprep_time = 10; //how long until fight auto ends
        public float fight_time = 1; //how long the fight lasts in seconds

        private bool IsFightTime = false;
        private bool IsPostFight = false;


        //Even if u cannot punch, stand, see, feel, or breath, so long as u have the will to, you can fight.


        void OnEnable()
        {
            //Player1
            FPStuff = FightingPlatform.GetComponent<FightingPlatformStuff>();
            FPStuff.enabled = true;
        }

        private void OnDisable()
        {
            //ChiefGameManager
        }

        // Update is called once per frame
        void Update()
        {
            if (IsPostFight)
            {
                PostFight();
            }
            else if (IsFightTime)
            {
                Fight();
            }
            else
            {
                if (IsFightPrepDone())
                {
                    DetermineFightWinner();
                    Player1.GetComponent<PlayerControls>().enabled = false;
                    Player2.GetComponent<PlayerControls>().enabled = false;
                    timer = fight_time;
                    IsFightTime = true;
                }
            }
        }

        //private 
        private bool IsFightPrepDone()
        {
            p1_atkchoice = Player1.GetComponent<PlayerControls>().attack_choice;
            p2_atkchoice = Player2.GetComponent<PlayerControls>().attack_choice;

            Debug.Log($"P1 Currently: {p1_atkchoice}");
            Debug.Log($"P2 Currently: {p2_atkchoice}");

            if (!(p1_atkchoice == AttackTypes.None) || !(p2_atkchoice == AttackTypes.None))
            {
                Countdown();

                if (timer <= 0 || (!(p1_atkchoice == AttackTypes.None) && !(p2_atkchoice == AttackTypes.None)))
                {
                    timer = fightprep_time;
                    Debug.Log("FIGHT TIMEEEEEE");
                    return true;
                }
            }
            else
            {
                timer = fightprep_time;
            }
                return false;
        }

        private void Countdown() 
        {
            timer -= Time.deltaTime;
            Debug.Log(Convert.ToInt32(timer));
        }

        /* 1 = p1 wins | 2 = p2 wins | 0 = draw */
        private void DetermineFightWinner() 
        {

            if (p1_atkchoice == p2_atkchoice)
            {
                FightResult(0);

            }
            else if (p1_atkchoice == 0)
            {
                FightResult(2);
            }
            else if (p2_atkchoice == 0)
            {
                FightResult(1);
            }
            else
            {
                atkchoice_result = p1_atkchoice - p2_atkchoice;
                switch (atkchoice_result)
                {
                    case -2:
                        FightResult(2);
                        break;
                    case -1:
                        FightResult(1);
                        break;
                    case 1:
                        FightResult(2);
                        break;
                    case 2:
                        FightResult(1);
                        break;
                }
            }
        }
        
        /// <summary>
        /// Used within DetermineFightWinner() to log fight result
        /// </summary>
        private void FightResult(int winner)
        {
            Debug.Log($"Player {winner} wins the Turn! :D");

            switch (winner)
            {
                case 1:
                    turn_winner = 1;          
                    break;
                case 2:
                    turn_winner = 2;
                    break;
                case 0:                  
                    turn_winner = 0;               
                    break;
            }
        }
        

        private void Fight()
        {
            Countdown();
            if (timer <= 0)
            {
                IsFightTime = false;
                IsPostFight = true;
            }
            else
            {
                switch (turn_winner)
                {
                    case 1:
                        Player1.transform.position += ((Vector3.back * attack_strength) * Time.deltaTime);
                        Player2.transform.position += ((Vector3.back * attack_strength) * Time.deltaTime);
                        break;
                    case 2:
                        Player1.transform.position += ((Vector3.forward * attack_strength) * Time.deltaTime);
                        Player2.transform.position += ((Vector3.forward * attack_strength) * Time.deltaTime);
                        break;
                    case 0:
                        if (timer > fight_time / 2)
                        {
                            Player1.transform.position += ((Vector3.up * 1) * Time.deltaTime);
                            Player2.transform.position += ((Vector3.up * 1) * Time.deltaTime);
                        }
                        else
                        {
                            Player1.transform.position += ((Vector3.down * 1) * Time.deltaTime);
                            Player2.transform.position += ((Vector3.down * 1) * Time.deltaTime);
                        }
                        break;
                }
            }

        }

        private void PostFight()
        {
            if (CheckIfPlayerIsKO(Player1))
            {
                //Player2
                this.enabled = false;
            }
            else if (CheckIfPlayerIsKO(Player2))
            {
                this.enabled = false;
            }
            else
            {               
                Player1.GetComponent<PlayerControls>().attack_choice = AttackTypes.None;
                Player2.GetComponent<PlayerControls>().attack_choice = AttackTypes.None;
                timer = fightprep_time;
                Player1.GetComponent<PlayerControls>().enabled = true;
                Player2.GetComponent<PlayerControls>().enabled = true;
            }
            IsPostFight = false;

        }
        private bool CheckIfPlayerIsKO(GameObject player)
        {
            if ((player.GetComponent<Transform>().position.z <= FPStuff.Leftside_limit) || (player.GetComponent<Transform>().position.z >= FPStuff.Rightside_limit))
            {
                player.GetComponent<Rigidbody>().useGravity = true;
                return true;
            }
            return false;
        }
    } 
}
