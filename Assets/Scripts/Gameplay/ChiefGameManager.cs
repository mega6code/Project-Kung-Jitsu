using Gameplay;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChiefGameManager : MonoBehaviour
{
    private bool start_game;
    private BattleManager myBattleManager;
    private void Start()
    {
        myBattleManager = gameObject.GetComponent<BattleManager>();
    }
    private void Update()
    {
        if (start_game)
        {
            
            myBattleManager.enabled = true;
            this.enabled = false;
            //gameObject.scene.GetType();
            
        }
        else
        {
            if (Input.anyKeyDown)
            {
                start_game = true;
            }
        }
    }
}
