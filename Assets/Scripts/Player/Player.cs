// using System;
// using KungJitsu.Fighters;
// using Unity.VisualScripting;
// using UnityEngine;
// using UnityEngine.InputSystem;
// using UnityEngine.Serialization;
//
// namespace KungJitsu.Players
// {
//     public class Player : MonoBehaviour
//     {
//         #region Fields
//
//         [SerializeField] private bool isDefaultPlayer = false;
//         [InspectableIf("isDefaultPLayer")]
//          [SerializeField] private InputActionAsset inputActions;
//          [SerializeField] private bool isSharedController = false;
//
//         #endregion
//
//         #region Events
//         public event Action<PlayerData> ChoseAttack;
//         #endregion
//
//         #region Methods
//
//         private void Awake()
//         {
//             if (isDefaultPlayer)
//             {
//                 inputActions.Enable();
//                 inputActions.FindActionMap("InBattle").FindAction("Kick").performed += OnKick;
//                 inputActions.FindActionMap("InBattle").FindAction("Punch").performed += OnPunch;
//                 inputActions.FindActionMap("InBattle").FindAction("Grab").performed += OnGrab;
//                 //inputActions.controlSchemes.
//             }
//         }
//
//         public void OnKick(InputAction.CallbackContext ctx)
//         {
//             ChoseAttack?.Invoke(new PlayerData(this, AttackTypes.Kick));
//         }
//
//         public void OnPunch(InputAction.CallbackContext ctx)
//         {
//             ChoseAttack?.Invoke(new PlayerData(this, AttackTypes.Punch));
//         }
//
//         public void OnGrab(InputAction.CallbackContext ctx)
//         {
//             ChoseAttack?.Invoke(new PlayerData(this, AttackTypes.Grab));
//         }
//
//         public void GoBack(InputAction.CallbackContext ctx)
//         {
//
//         }
//
//         #endregion
//
//
//     }
// }
