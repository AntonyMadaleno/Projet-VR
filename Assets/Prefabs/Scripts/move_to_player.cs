using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_to_player : MonoBehaviour
{

    public GameObject entity;
    public float speed;
    private GameObject player;
    private TimeSystem2 timeSystem;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        timeSystem = GameObject.Find("System").GetComponent<TimeSystem2>();
        // Calculate the normalized vector from entity to player
        direction = player.transform.position - entity.transform.position;
        direction = Vector3.Normalize(direction) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        entity.transform.position = entity.transform.position + direction * timeSystem.time;
    }
}
