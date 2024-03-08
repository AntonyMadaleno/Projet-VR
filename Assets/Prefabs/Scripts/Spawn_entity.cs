using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Spawn_entity : MonoBehaviour
{
    public GameObject   entity_prefab;
    public int          spawn_rate;
    public float        spawn_radius;
    public GameObject skeleton_prefab;
    private TimeSystem timeSystem;

    private float spawn_tick;

    // Start is called before the first frame update
    void Start()
    {
        timeSystem = GameObject.Find("System").GetComponent<TimeSystem>();
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
            Debug.Log(spawn_tick);
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
        if(spawn_position.magnitude<25)
        {
            spawn_position = spawn_position*(25/spawn_position.magnitude);
        }
        GameObject entity = Instantiate( entity_prefab, spawn_position, new Quaternion(0,0,0,0) );
        entity.transform.LookAt(transform.position);
    }
}
