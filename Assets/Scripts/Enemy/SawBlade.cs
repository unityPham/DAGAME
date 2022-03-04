using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBlade : Enemy
{
    // Start is called before the first frame update
    float rotationZ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationZ -= Time.timeScale * Time.deltaTime * 200;
        transform.eulerAngles = new Vector3(0, 0, rotationZ);
    }
}
