using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poles : Enemy
{
    public Vector3 movieVector;
    
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //transform.position += movieVector*Time.deltaTime;
        //movieVector *= 0.985f;
        if (transform.position.y > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
        }
        else if (transform.position.y < -4)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
            gameObject.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Discrete;
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        float velocity = Vector2.Distance(Vector2.zero, gameObject.GetComponent<Rigidbody2D>().velocity);
        if (velocity < 0.1f & velocity>0)
        {
            gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
            gameObject.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Discrete;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerCollisionEnter(collision))
        {
            movieVector = GameManager.THIS.playerMovieVector;
            gameObject.GetComponent<Rigidbody2D>().velocity = movieVector*3.5f;
        }
    }
}
