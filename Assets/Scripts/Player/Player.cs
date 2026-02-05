using System;
using Fighters;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    #region Fields
    #endregion

    #region Methods
    
    #endregion

    #region Event Methods
    public void OnKick(InputAction.CallbackContext cbx)
    {
        ChoosingAttack.Invoke(this, AttackTypes.Kick);
    }
    public void OnPunch(InputAction.CallbackContext cbx)
    {
        ChoosingAttack.Invoke(this, AttackTypes.Punch);
    }
    public void OnGrab(InputAction.CallbackContext cbx)
    {
        ChoosingAttack.Invoke(this, AttackTypes.Grab);
    }
    #endregion

    #region Events
    public event EventHandler<AttackTypes> ChoosingAttack;

    #endregion

}
