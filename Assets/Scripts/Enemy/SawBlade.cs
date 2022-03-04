using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBlade : Enemy
{
    // Start is called before the first frame update
    float rotationZ;

    void Update()
    {
        rotationZ -= Time.deltaTime * 200;
        transform.eulerAngles = new Vector3(0, 0, rotationZ);
        CheckDestroy();
    }
}
