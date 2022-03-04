using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player_Positon_Y upDownPosition;
    public int enemyDigit;
    private void Start()
    {
        bornPosition();
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

    public void bornPosition()
    {
        gameObject.transform.position = new Vector2(enemyDigit * GameManager.THIS.enemyDistance, (int)upDownPosition * 0.1f);
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
    }
}
