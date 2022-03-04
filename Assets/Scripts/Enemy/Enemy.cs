using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public Player_Positon_Y upDownPosition;
    //public float enemyDigit;
    private void Start()
    {
        BornPosition();
    }

    private void Update()
    {
        CheckDestroy();
    }

    public void CheckDestroy()
    {
        if (transform.position.x < GameManager.THIS.player.transform.position.x - 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerCollisionEnter(other);
    }

    public bool PlayerCollisionEnter(Collision2D other)
    {
        if (other.gameObject == GameManager.THIS.player & GameManager.THIS.gameMod==Game_Mod.playing)
        {
            GameManager.THIS.OpenGameOver();
            Debug.Log("Over");
            return true;
        }
        else
        {
            return false;
        }
    }

    public void BornPosition()
    {
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
    }
}
