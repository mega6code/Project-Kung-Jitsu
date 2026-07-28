using System;
using System.Collections.Generic;
using UnityEngine;

namespace Fighters
{
    public class Fighter : MonoBehaviour
    {
        #region Fields
        [Header("References")]
        //Serialized References
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Animator animator;
        [SerializeField] private HitboxManager hitboxManager;
        [SerializeField] private Transform launchPoint;
        [SerializeField] private FightStateManager fightStateManager;
        [SerializeField] private FightStyleManager fightStyleManager;
        [SerializeField] private EnergyManager energyManager; 

        [Space]

        [Header("Fighter Details")]
        //Serialzed Fields
        [SerializeField] private string f_name;
        [SerializeField] private string f_title;
        [SerializeField] private AttackTypes attack_choice = AttackTypes.NoAttack;
        [SerializeField] private Dictionary<AttackTypes, string> animatorParameters;
        [SerializeField] private Dictionary<string, Transform> hitboxSpawnablePoints;
        
        //Other Fields
        ////private FighterState current_state; //if need it for the fighter compnonet
        #endregion     

        #region Events
        #endregion

        #region Properties
        public string F_name { get => f_name;}
        public string F_title { get => f_title;}
        #endregion

        #region Methods


        public void Attack()
        {
            if (animator != null && animatorParameters.TryGetValue(attack_choice, out string parameter))
            {
                animator.SetTrigger(parameter);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attackReleasePointName">Like "Left Leg", "Right Arm", etc...</param>
        private void OnAttackReleasing(string attackReleasePointName)
        {
            Transform hitboxSpawnPoint = GetHitboxSpawnablePoint(attackReleasePointName);
            Collider[] colliders = hitboxManager.SpawnInstantHitbox(hitboxSpawnPoint);

            Debug.Log("Attack released!!!!");

            CheckIfAttackHit(colliders);
        }

        private void CheckIfAttackHit(Collider[] colliders)
        {
            if (colliders.Length > 0)
            {
                foreach (Collider collider in colliders)
                {
                    if (collider.TryGetComponent<Fighter>(out Fighter opponent))
                    {
                        opponent.ReceiveHit(new HitData(attack_choice));
                    }
                }
            }
        }

        private Transform GetHitboxSpawnablePoint(string attackReleasePointName)
        {
            if (hitboxSpawnablePoints.TryGetValue(attackReleasePointName, out Transform hitboxSpawnPoint))
            {
                return hitboxSpawnPoint; 
            }
            return null; 
        }


        public void ReceiveHit(HitData hit_data)
        {
            fightStateManager.ReceiveHit(hit_data);
        }

        private void ReceiveKnockback(float launch_angle)
        {
            launch_angle = Math.Clamp(launch_angle, -90, 90);
            Transform launch_direction = launchPoint;
            launch_direction.Rotate(launch_angle, 0, 0);

            float launch_strength = 1;
            rb.AddForce(launch_direction.forward * launch_strength, ForceMode.VelocityChange);
        }

        /*private void OnCollisionEnter(Collision collision)
        {
            collision.gameObject.TryGetComponent()
            current_attack_type.OnCollisionEnter(collision.);
        }*/

        #endregion
    }
}
