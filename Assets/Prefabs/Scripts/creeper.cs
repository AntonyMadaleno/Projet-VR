using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creeper : MonoBehaviour
{
    public GameObject entity;
    public float speed;
    private GameObject player;
    private TimeSystem2 timeSystem;
    private float finalCountdown;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        timeSystem = GameObject.Find("System").GetComponent<TimeSystem2>();
        finalCountdown = 0;
        // Calculate the normalized vector from entity to player
        direction = player.transform.position - entity.transform.position;
        direction = Vector3.Normalize(direction) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dist = entity.transform.position - player.transform.position;
        if (dist.magnitude>3)
            entity.transform.position = entity.transform.position + direction * timeSystem.time;
        else
        {
            if(finalCountdown>=10)
            {
                player.GetComponent<Player_Collision>().BOOM();
            }
            finalCountdown += 1* timeSystem.time;
        }
        
    }
}