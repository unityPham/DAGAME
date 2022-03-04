using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Score")
        {
            gameObject.GetComponent<Text>().text = "Score\n" + GameManager.THIS.score;
            transform.GetChild(0).gameObject.GetComponent<Text>().text = gameObject.GetComponent<Text>().text; //"Score\n" + GameManager.THIS.score;
        }
        else
        {
            GameManager.THIS.bestScore = (GameManager.THIS.score > GameManager.THIS.bestScore) ? GameManager.THIS.score : GameManager.THIS.bestScore;

            gameObject.GetComponent<Text>().text = "Best Score\n" + GameManager.THIS.bestScore;
            transform.GetChild(0).gameObject.GetComponent<Text>().text = gameObject.GetComponent<Text>().text; //"Best Score\n" + GameManager.THIS.bestScore;
        }
    }

}
