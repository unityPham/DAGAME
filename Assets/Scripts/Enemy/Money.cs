using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public Player_Positon_Y upDownPosition;
    public float enemyDigit;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector2(enemyDigit * GameManager.THIS.enemyDistance, (int)upDownPosition * 0.1f);
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1 -1 ;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameManager.THIS.player & GameManager.THIS.gameMod == Game_Mod.playing)
        {
            CollectMoney();
            AudioManager.THIS.Play(Sound_Name.coin);
            Debug.Log("Up Money");
        }
    }

    void CollectMoney()
    {
        GameManager.THIS.score += 1;
        Destroy(gameObject);
    }
}
