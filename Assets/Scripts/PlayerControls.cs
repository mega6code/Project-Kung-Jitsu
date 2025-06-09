using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    #region Fields
    public int player_num;
    public InputActionAsset actions;
    public InputActionMap action_map;
    public InputAction kick_IA;
    public InputAction punch_IA;
    public InputAction grab_IA; 
    #endregion


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        action_map = actions.FindActionMap($"P{player_num}Combat");
        kick_IA = action_map.FindAction("Kick");
        punch_IA = action_map.FindAction("Punch");
        grab_IA = action_map.FindAction("Grab");

    }

    // Update is called once per frame
    void Update()
    {   
        if (kick_IA.IsPressed())
        {
            Debug.Log("Kick!!!!!!!!!!!!!!");
        }
        else if (punch_IA.IsPressed())
        {
            Debug.Log("Punchchhh!!!!!!!!!!!!!!");
        }
        else if (grab_IA.IsPressed())
        {
            Debug.Log("Grabbbbb!!!!!!!!!!!!!!");
        }

    }
    
    
}
