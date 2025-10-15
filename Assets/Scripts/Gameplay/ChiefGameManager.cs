using Gameplay;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;


//add animation core, fix playernum thing (just make it simple now), dont disable playercore only player controls
public class ChiefGameManager : MonoBehaviour
{
    
    //public BattleManager myBattleManager;

    //private bool start_game = false;

    private void Start()
    {
        
    }
    private void Update()
    {
        Debug.Log("Main Menu");
        if (Input.GetKey(KeyCode.KeypadEnter))
        {           
            //myBattleManager.enabled = true;
            this.enabled = false;       
        }
    }
}
