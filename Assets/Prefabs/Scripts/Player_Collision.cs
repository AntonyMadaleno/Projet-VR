using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour
{

    public int player_hitpoint;
    public GameObject vie;
    public GameObject nullVie;
    public GameObject camera;
    public List<GameObject> cube;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        player_hitpoint = 5;
        cube = new List<GameObject>();
        for (int i=0; i<5; i++)
        {
            GameObject obj = Instantiate(vie,new Vector3(-0.09f+0.01f*i,0.1f,0.2f),new Quaternion(0,0,0,0));
            obj.transform.Rotate(0, 90, 0);
            obj.transform.localScale = new Vector3(0.0001f, 0.01f, 0.01f);
            obj.transform.parent = camera.transform;
            cube.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter( Collider hit )
    {
        if (hit.tag == "Entity" || hit.tag == "Arrow")
        {
            GameObject collider = hit.gameObject;
            Debug.Log(hit.name + " " + collider.name);
            //Retire 1 HP au joueur
            player_hitpoint = player_hitpoint - 1;
            Destroy(cube[player_hitpoint]);
            cube.RemoveAt(player_hitpoint);

            if (player_hitpoint <= 0)
            {
                // you loose !
                return;
            }


            //Detruit l'objet de la collision
            Destroy(collider);
        }
        
    }

    public void BOOM()
    {
        player_hitpoint = 0;
        return;
    }

}
