using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Spawn_entity : MonoBehaviour
{
    public List<GameObject>   entity_prefab;
    public int          spawn_rate;
    public float        spawn_radius;
    public GameObject skeleton_prefab;
    private TimeSystem2 timeSystem;

    public float spawn_tick;

    // Start is called before the first frame update
    void Start()
    {
        timeSystem = GameObject.Find("System").GetComponent<TimeSystem2>();
        spawn_tick = 0;
        for(int i=0; i<4; i++)
        {
            GameObject ske = Instantiate(skeleton_prefab,new Vector3(50*Mathf.Cos(i*Mathf.PI/2),0,50*Mathf.Sin(i*Mathf.PI/2)),new Quaternion(0,0,0,0));
            ske.transform.LookAt(transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn_tick >= spawn_rate)
        {
            spawn_entity();
            spawn_tick = 0;
        }
        else
            spawn_tick += 1*timeSystem.time;
    }

    void spawn_entity()
    {
        float x = Random.Range(-spawn_radius, spawn_radius);
        float z = Random.Range(-spawn_radius, spawn_radius);
        float y = 0;
        
        //Calculate a random position to spawn an entity around the player
        Vector3 spawn_position = new Vector3( x, y, z );
        if(spawn_position.magnitude<15)
        {
            spawn_position = spawn_position*(15/spawn_position.magnitude);
        }
        
        int nbobj = Random.Range(0, 5);
        GameObject entity;
        if(nbobj < 2)
            entity = Instantiate(entity_prefab[0], spawn_position, new Quaternion(0,0,0,0) );
        else
        {
            if (nbobj == 4)
                entity = Instantiate(entity_prefab[2], spawn_position, new Quaternion(0, 0, 0, 0));
            else
            {
                entity = Instantiate(entity_prefab[1], spawn_position, new Quaternion(0, 0, 0, 0));
            }
        }
        entity.transform.LookAt(transform.position);
    }
}
