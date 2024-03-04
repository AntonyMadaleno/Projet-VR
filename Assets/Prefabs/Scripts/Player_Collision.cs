using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour
{

    private int player_hitpoint;

    // Start is called before the first frame update
    void Start()
    {
        player_hitpoint = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter( Collider hit )
    {
        GameObject collider = hit.gameObject;
        
        //Retire 1 HP au joueur
        player_hitpoint = player_hitpoint - 1;

        if (player_hitpoint <= 0)
        {
            // you loose !
            return;
        }


        //Detruit l'objet de la collision
        Destroy(collider);
    }

}
