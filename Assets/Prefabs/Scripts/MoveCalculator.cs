using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCalculator : MonoBehaviour
{
    private TimeSystem TimeSys;
    public int part;
    private Vector3 oldPos;
    private Vector3 oldRot;
    // Start is called before the first frame update
    void Start()
    {
        TimeSys = GameObject.Find("System").GetComponent<TimeSystem>();
        oldPos = transform.position;
        oldRot = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 rot = transform.eulerAngles;
        float t = Time.deltaTime;
        Vector3 pos2 = pos - oldPos;
        float p = pos2.magnitude*4;
        Vector3 rot2 = rot - oldRot;
        if (rot2.x > 180/0.4*t)
            rot2.x = rot2.x - 360;
        if (rot2.y > 180 / 0.4 * t)
            rot2.y = rot2.y - 360;
        if (rot2.z > 180 / 0.4 * t)
            rot2.z = rot2.z - 360;
        float p2 = rot2.magnitude;
        oldPos = pos;
        oldRot = rot;
        TimeSys.add(p*p2*t/2.5f, part);
    }
}
