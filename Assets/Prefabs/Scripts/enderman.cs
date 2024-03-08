using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enderman : MonoBehaviour
{
    public float fatigue;
    public Animator anim = null;
    // Start is called before the first frame update
    void Start()
    {
        fatigue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(fatigue <= 1000) {
            transform.position = new Vector3(60*Mathf.Cos((fatigue%200f)/200f*Mathf.PI),0, 60*Mathf.Sin((fatigue % 200.0f) / 200.0f * Mathf.PI));
            transform.Rotate(0,-0.028f,0);
        }
        else
        {
            anim.SetBool("mort", true);
            if(fatigue >= 1500)
            {
                Destroy(gameObject);
            }
        }
        fatigue++;
    }
}
