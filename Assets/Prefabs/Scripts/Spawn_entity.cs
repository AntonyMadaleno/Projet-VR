using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_entity : MonoBehaviour
{
    public GameObject   entity_prefab;
    public int          spawn_rate;
    public float        spawn_radius;

    private int spawn_tick;

    // Start is called before the first frame update
    void Start()
    {
        spawn_tick = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn_tick == spawn_rate)
        {
            spawn_entity();
            Debug.Log(spawn_tick);
            spawn_tick = 0;
        }
        else
            spawn_tick += 1;
    }

    void spawn_entity()
    {
        float x = Random.Range(-spawn_radius, spawn_radius);
        float z = Random.Range(-spawn_radius, spawn_radius);
        float y = 0;

        //Calculate a random position to spawn an entity around the player
        Vector3 spawn_position = new Vector3( x, y, z );

        GameObject entity = Instantiate( entity_prefab, spawn_position, new Quaternion(0,0,0,0) );
    }
}
