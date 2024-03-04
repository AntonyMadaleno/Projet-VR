using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_at_player : MonoBehaviour
{

    public GameObject   arrow_prefab;
    public float         fire_rate;
    private float        fire_tick;
    public GameObject   entity;

    // Start is called before the first frame update
    void Start()
    {
        fire_tick = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (fire_tick >= fire_rate)
        {
            fire_arrow();
            fire_tick = Random.Range(-fire_rate/4.0f, fire_rate/4.0f);;
        }
        else
            fire_tick += 1;
    }

    void fire_arrow()
    {
        GameObject arrow = Instantiate( arrow_prefab, entity.transform.position, new Quaternion(0,0,0,0) );
    }
}
