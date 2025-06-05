using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Camera cam;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        //Turns off the StartMenu UI
        gameObject.SetActive(false);
        
        cam.transform.position = new Vector3(-0.6f,2,3.0f);
        cam.transform.rotation = new Quaternion(0, 0.9f, -0.1f, 0);
    }

    public void ExitGame()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
