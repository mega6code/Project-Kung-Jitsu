using UnityEngine;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{


    #region Fields
    private static GameManager instance;

    //[SerializeField] private InputManager inputManager;
    #endregion

    #region Properties

    #endregion

    #region Methods
    private void Awake()
    {
        if(GameManager.instance == null)
        {
            GameManager.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

}
