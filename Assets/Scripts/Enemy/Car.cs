using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Enemy
{
    public Vector3 movieVector;

    // Update is called once per frame
    void Update()
    {
        transform.position += movieVector * Time.deltaTime;
        CheckDestroy();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerCollisionEnter(collision))
        {
            movieVector = Vector3.zero;
        }
    }
}
