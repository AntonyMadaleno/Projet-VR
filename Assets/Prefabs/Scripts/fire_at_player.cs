using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_at_player : MonoBehaviour
{

    public GameObject   arrow_prefab;
    public float         fire_rate;
    public float        fire_tick;
    private TimeSystem2 timeSystem;
    public GameObject player;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        timeSystem = GameObject.Find("System").GetComponent<TimeSystem2>();
        player = GameObject.Find("Player");
        fire_tick = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (fire_tick >= fire_rate)
        {
            fire_arrow();
            fire_tick = Random.Range(-fire_rate/4.0f, fire_rate/4.0f);
        }
        else
            fire_tick += 1*timeSystem.time;
    }

    void fire_arrow()
    {
        GameObject arrow = Instantiate( arrow_prefab, transform.position+Vector3.up, new Quaternion(0,0,0,0) );
        arrow.transform.LookAt(player.transform);
        audioSource.Play();
    }
}
