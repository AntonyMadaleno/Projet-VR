using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    public float time;
    private float t1;
    private float t2;
    private float t3;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        t1 = 0;
        t2 = 0;
        t3 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void add(float ti, int i)
    {
        switch (i)
        {
            case 0:
                t1 = ti;
                break;
            case 1:
                t2 = ti;
                break;
            case 2:
                t3 = ti;
                break;
        }
        time = (t1 + t2 + t3) / 3.0f;
    }
}
