using UnityEngine;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{


    #region Fields
    private static GameManager instance;

    [SerializeField] private InputManager input_manager;
    #endregion

    #region Properties

    #endregion

    #region Methods

    #endregion
    #region Events

    #endregion
    #region Event Functions
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

    private void Start()
    {
    }
    #endregion

}
