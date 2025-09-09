using Gameplay;
using Gameplay.Fighters;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Scriptable Objects/Player")]
public class Player : ScriptableObject
{
    private int player_number;
    public Fighter my_fighter;
    public void Update()
    {
        
    }
    public Player(int p_num)
    {
        player_number = p_num;
        my_fighter = new GregFighter();

        this.AddComponent<Transform>();      
        this.AddComponent<MeshFilter>();
        //this.GetComponent<MeshFilter>().mesh
        this.AddComponent<MeshRenderer>();
        this.AddComponent<CapsuleCollider>();
        this.AddComponent<Rigidbody>();
        this.AddComponent<PlayerControls>();

        if (player_number == 1)
        {
            this.GetComponent<Transform>().position = new Vector3(0, 0, 1);
            
        }

        if (player_number == 2)
        {
            this.GetComponent<Transform>().position = new Vector3(0, 0, -1);
        }
    }

}
