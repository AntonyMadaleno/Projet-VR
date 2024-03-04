using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject zombie_prefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject entity = Instantiate( zombie_prefab, new Vector3(0.0f, 1.0f, 0.0f), new Quaternion(0,0,0,0) );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
