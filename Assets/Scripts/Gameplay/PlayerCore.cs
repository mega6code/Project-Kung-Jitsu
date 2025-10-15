using Gameplay.Fighters;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay
{
    public class PlayerCore : MonoBehaviour
    {
        #region Fields
        public int player_number = 0;
       
        private Fighter current_fighter;
        #endregion

        #region Properties
        public Fighter Current_fighter { get => current_fighter; set => current_fighter = value; }
        #endregion

        void Start()
        {
            
        }
        void Update()
        {
            //gameObject.GetComponent<BoxCollider>().

        }

        //fighttime btw is 2 seconds atm just reminding you thanks chief
        public void Move(Vector3 direction, int speed = 1)
        {
            //ex: (0,0,1 * 5) = 5 units moved every second
            gameObject.transform.position += ((direction * speed) * Time.deltaTime);
           
        }
        public void MoveForward(int speed)
        {
            if (gameObject.transform.rotation.y == 180)
            {
                Move(new Vector3(0, 0, -1), speed);
            }
            //facing towards postitive z cords
            else
            {
                Move(new Vector3(0, 0, 1), speed);
            }
        }
        public void MoveBackwards(int speed)
        {
            if (gameObject.transform.rotation.y == 180)
            {
                Move(new Vector3(0, 0, 1), speed);
            }
            //facing towards postitive z cords
            else
            {
                Move(new Vector3(0, 0, -1), speed);
            }
        }

        public void MatchStartPositioning()
        {

            gameObject.GetComponent<Rigidbody>().useGravity = false;

            if (player_number == 1)
            {
                this.GetComponent<Transform>().position = new Vector3(0, 0, 1);
                this.GetComponent<Transform>().rotation.Set(0, 180, 0, 0);

            }

            if (player_number == 2)
            {
                this.GetComponent<Transform>().position = new Vector3(0, 0, -1);
                this.GetComponent<Transform>().rotation.Set(0, 0, 0, 0);
            }
        }

        public PlayerCore()
        {
            //gameObject.AddComponent<GregFighter>();
            //current_fighter = gameObject.GetComponent<GregFighter>();
 
        }
    }
}
