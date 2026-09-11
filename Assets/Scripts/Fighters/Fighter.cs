using System;
using System.Collections.Generic;
using UnityEngine;

namespace KungJitsu.Fighters
{
    public class Fighter : MonoBehaviour
    {
        #region Fields
        [Header("References")]

            #region Serialized References
            [SerializeField] private Transform launchPoint;
            [SerializeField] private Transform groundPoint;
            [SerializeField] private Transform fighterSpace;
            [SerializeField] private Rigidbody rb;
            [SerializeField] private Animator animator;
            [SerializeField] private Camera fighterCamera;
            [SerializeField] private HitboxManager hitboxManager;
            [SerializeField] private FightStateManager fightStateManager;
            [SerializeField] private EnergyManager energyManager; 
            ////[SerializeField] private FightStyleManager fightStyleManager;
            #endregion

        [Space]

        [Header("Fighter Details")]

            #region Serialized Fields
            [SerializeField] private string f_name;
            [SerializeField] private string f_title;
            [SerializeField] private AttackTypes attack_choice = AttackTypes.NoAttack;


            ////[SerializeField] private Dictionary<AttackTypes, string> animatorParameters;

            ////[SerializeField] private Dictionary<string, Transform> hitboxSpawnablePoints;

            //Other Fields

            ////private FighterState current_state; //if need it for the fighter compnonet

            #endregion

            private bool kknocked = false;
            private bool airborne = false;

            #endregion     

        #region Events

        public event Action<Camera> gotKKnocked;
        public event Action<Camera, Transform> landed;
        #endregion

        #region Properties
        public string F_name { get => f_name;}
        public string F_title { get => f_title;}
        #endregion

        #region Functions

            #region Callbacks
            private void OnEnable()
            {
                fightStateManager.stateGotHit += OnFightStateGotHit;
                fightStateManager.stateBlocked += OnFightStateBlocked;
                fightStateManager.stateDrawed += OnFightStateDrawed;
            }

            private void OnDisable()
            {
                fightStateManager.stateGotHit -= OnFightStateGotHit;
                fightStateManager.stateBlocked -= OnFightStateBlocked;
                fightStateManager.stateDrawed -= OnFightStateDrawed;
            }

            private void Update()
            {
                if (kknocked)
                {
                    Debug.Log($"{this.name}'s k'knocked!");
                    
                    if (Physics.Raycast(groundPoint.position, (rb.transform.up * -1), out RaycastHit hit))
                    {
                        Debug.Log($"{this.name}'s raycast hit {hit.transform.name}: {hit.distance} units away at {rb.linearVelocity.magnitude} speed");
                        
                        if (hit.distance > 0.5f)
                        {
                            airborne = true;
                            Debug.Log($"{this.name} is in air! airborne var is {airborne}");
                        }
                    }
                }

                if (airborne)
                {
                    if (Physics.Raycast(groundPoint.position, (rb.transform.up * -1), out RaycastHit hit))
                    {
                        Debug.Log($"{this.name}'s raycast hit {hit.transform.name}: {hit.distance} units away at {rb.linearVelocity.magnitude} speed");
                        
                        if (hit.distance < 0.5f)
                        {
                            airborne = false;
                            kknocked = false;
                            animator.SetBool("InKKnocked", false);
                            landed.Invoke(fighterCamera, fighterSpace);
                            Debug.Log($"{this.name} has landed!");
                        }
                    }
                }
            }

            /// <summary>
            /// When the animation of the attack reaches the point where it 'makes contact'
            /// </summary>
            private void OnAttackReleasing()
            {
                Collider[] colliders = hitboxManager.SpawnInstantHitbox(this.transform);

                Debug.Log("Attack released!!!!");

                CheckIfAttackHit(colliders);
            }

           /* /// <summary>
            /// When the animation of the attack reaches the point where it 'makes contact'
            /// </summary>
            /// <param name="attackReleasePointName">Like "Left Leg", "Right Arm", etc...</param>
            private void OnAttackReleasing(string attackReleasePointName)
            {
                Transform hitboxSpawnPoint = GetHitboxSpawnablePoint(attackReleasePointName);
                Collider[] colliders = hitboxManager.SpawnInstantHitbox(hitboxSpawnPoint);

                Debug.Log("Attack released!!!!");

                CheckIfAttackHit(colliders);
            } */

            private void OnFightStateGotHit(HitData hitData)
            {
                animator.SetTrigger("IsHit");
                ReceiveKnockback(hitData.launch_angle);
                animator.ResetTrigger(GetTriggerforAttackAnimation());
            }

	        private void OnFightStateDrawed(HitData hitData)
            {
                animator.SetTrigger("Draw");
            }

		    private void OnFightStateBlocked(HitData hitData)
            {
               animator.SetTrigger("Block");
            }
            #endregion

            #region Methods
            public void EnterCombat()
            {
                animator.SetBool("InCombat", true);
            }

            public void LeaveCombat()
            {
                animator.SetBool("InCombat", false);
            }

            public void ChangeAttackChoice(AttackTypes attackType)
            {
                attack_choice = attackType;
            }

            public void LockInAttackChoice()
            {
                if (fightStateManager.IsStateCurrently(attack_choice) == false)
                {
                    fightStateManager.ChangeState(attack_choice);
                }
            }
            public void Attack()
            {
                LockInAttackChoice();
                if (attack_choice != AttackTypes.NoAttack)
                {
                    animator.SetTrigger(GetTriggerforAttackAnimation());
                }
            }
            public void ReceiveHit(HitData hit_data)
            {
                Debug.Log($"{this.name}'s is Receiving a Hit!");
                fightStateManager.IncomingAttack(hit_data);
            }

            private string GetTriggerforAttackAnimation()
            {
                switch (attack_choice)
                {
                    case AttackTypes.Kick:
                        return "Kick";
                    case AttackTypes.Punch:
                        return "Punch";
                    case AttackTypes.Grab:
                        return "Grab";
                    default:
                        return default(string);
                }
            }

            private void CheckIfAttackHit(Collider[] colliders)
            {
                //if (colliders.Length > 0)
                //{
                    foreach (Collider collider in colliders)
                    {
                        if (collider.TryGetComponent<Fighter>(out Fighter opponent))
                        {
                            if (opponent != this)
                            {
                                Debug.Log($"{this.name}'s Attack Release has connected with Target!");
                                opponent.ReceiveHit(new HitData(attack_choice));
                            }
                        }
                    }
                //}
            }

            /*private Transform GetHitboxSpawnablePoint(string attackReleasePointName)
            {
                if (hitboxSpawnablePoints.TryGetValue(attackReleasePointName, out Transform hitboxSpawnPoint))
                {
                    return hitboxSpawnPoint;
                }
                return this.transform;
            }*/

            private void ReceiveKnockback(float launch_angle)
            {
                launch_angle = -(75/*Math.Clamp(launch_angle, 1, 89)*/);
                launchPoint.Rotate(new Vector3(launch_angle, 0, 0));

                float launch_strength = 8;
                rb.AddForce(launchPoint.forward * launch_strength, ForceMode.VelocityChange);
                launchPoint.Rotate(new Vector3(-launch_angle, 0, 0));
                
                kknocked = true;
                animator.SetBool("InKKnocked", true);
                gotKKnocked.Invoke(fighterCamera);
            }
            #endregion
        #endregion

        
    }
}
