using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public GameObject entity;
    private GameObject player;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        // Calculate the normalized vector from entity to player
        direction = player.transform.position - entity.transform.position;
        direction = Vector3.Normalize(direction) * 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        entity.transform.position = entity.transform.position + direction;
    }
}
