using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    #region Fields
    [SerializeField] private InputActionAsset[] input_action_asset;
    #endregion

    #region Properties

    #endregion
    #region Methods

    #endregion
    #region Events

    #endregion
    #region Event Functions

    //will always enable the 'default' action asset at start
    private void Start()
    {
        input_action_asset[0].Enable();
    }
    #endregion
}
