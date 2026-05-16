using System;
using Fighters;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    #region Fields
    [SerializeField] private bool IsDefaultPlayer;
    []
    [SerializeField] private InputActionAsset inputActions;
    #endregion

    #region Events
    public event Action<AttackTypes> ChoosingAttack;
    #endregion

    #region Methods
    public void OnKick()
    {
        ChoosingAttack.Invoke(AttackTypes.Kick);
    }
    public void OnPunch()
    {
        ChoosingAttack.Invoke(AttackTypes.Punch);
    }
    public void OnGrab()
    {
        ChoosingAttack.Invoke(AttackTypes.Grab);
    }
    #endregion


}
