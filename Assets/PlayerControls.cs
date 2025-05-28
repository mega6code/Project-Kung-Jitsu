using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Vector3 vector_movement = new Vector3(2, 2);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate( new Vector3(2, 2));

        if (Input.GetKey(KeyCode.W) == true)
        {
            
            gameObject.transform.position = transform.position + vector_movement;
        }
        
    }
}
