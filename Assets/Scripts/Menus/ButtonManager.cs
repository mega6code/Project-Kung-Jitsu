using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Camera menu_cam;
    public Camera main_cam;
    public Vector3 cam_mov_speed = new Vector3(1, 1, 1);
    bool cam_moving = false;

// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cam_moving)
        {
            MoveCam();
        }
        
    }

    

    public void PlayGame()
    {
        //Turns off the StartMenu UI
        gameObject.SetActive(false);
        cam_moving = true;
        
    }

    public void MoveCam()
    {
        if(!(menu_cam.transform.rotation == main_cam.transform.rotation))
        {
            menu_cam.transform.rotation = main_cam.transform.rotation;
        }
        
        if (!(menu_cam.transform.position == main_cam.transform.position))
        {
            menu_cam.transform.position += cam_mov_speed * Time.deltaTime;
        }
        else
        {
            cam_moving = false;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
