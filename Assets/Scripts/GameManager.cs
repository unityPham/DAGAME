using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public enum Game_Mod
{
    pause,
    playing,
    home,
    over,
}

public enum Player_Positon_Y
{
    up = -12,// -1.0f
    down = -29,//-2.5f

}


public class GameManager : MonoBehaviour
{

    public static GameManager THIS;
    public Game_Mod gameMod;
    public Player_Positon_Y playerPosition_Y;
    public List<GameObject> enemySpawn, destroyGameObjectList;
    public GameObject overCanvas, homeCanvas;
    public GameObject gamePlayGround, mainCamera, player, gamePlayShowScoreObj, gamePlayBackGoundObj;
    public Vector3 cameraPosition;
    public Vector2 playerMovieVector;
    public float speedUp,gamePlayDeltaFrame, playerPositionY, enemyDistance, enemyDigit;
    public int skinDigit;

    public int score, bestScore;

    void Start()
    {
        THIS = this;
        Application.targetFrameRate = 30;
        gamePlayDeltaFrame = 60.0f / Application.targetFrameRate;
        cameraPosition = new Vector3(0, 0, -1);
        OpenHome();
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameMod)
        {
            case Game_Mod.home:
                {
                    break;
                }
            case Game_Mod.playing:
                {
                    movie();
                    break;
                }
            case Game_Mod.pause:
                {
                    break;
                }
            case Game_Mod.over:
                {
                    break;
                }
        }
    }

    void movie()
    {
        cameraPosition.x += Time.deltaTime*0.2f;
        //speed up
        Time.timeScale = 1 + (cameraPosition.x * speedUp*0.01f);
        //movie camera
        mainCamera.transform.localPosition = cameraPosition * gamePlayGround.transform.localScale.x;
        //roll BackGround
        gamePlayGround.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", cameraPosition);
        //set player position
        setPlayerPosition();
        showScore();
        keyControl();
    }


    void showScore()
    {
        gamePlayShowScoreObj.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Score\n" + score;
    }
    void setPlayerPosition()
    {
        Vector3 oldPosition = player.transform.position;
        playerPositionY += (((int)playerPosition_Y * 0.1f) - playerPositionY) *0.4f * gamePlayDeltaFrame;
        player.transform.position = new Vector2(mainCamera.transform.position.x - 2, playerPositionY);
        player.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(player.transform.position.y * 100f) * -1;
        Vector2 playerMovie = (player.transform.position - oldPosition);
        playerMovieVector = playerMovie.normalized;
    }

    void keyControl()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerPosition_Y == Player_Positon_Y.up)
            {
                playerPosition_Y = Player_Positon_Y.down;
            }
            else
            {
                playerPosition_Y = Player_Positon_Y.up;
            }
        }
    }

    public void RestarGame()
    {
        OpenGameStart();
    }

    public void removeAllDestroyList()
    {
        while (destroyGameObjectList.Count > 0)
        {
            Destroy(destroyGameObjectList[0]);
            destroyGameObjectList.RemoveAt(0);
        }
    }

    public void OpenGameStart()
    {
        cameraPosition.x = 0;
        score = 0;
        gameMod = Game_Mod.playing;
        gamePlayShowScoreObj.SetActive(true);
        showScore();
        removeAllDestroyList();
    }

    public void OpenGameOver()
    {
        gameMod = Game_Mod.over;
        GameObject overObj = Instantiate(overCanvas);
        destroyGameObjectList.Add(overObj);
        gamePlayShowScoreObj.SetActive(false);
    }

    public void OpenHome()
    {
        gameMod = Game_Mod.home;
        removeAllDestroyList();
        Instantiate(homeCanvas);
    }

    public void OpenSetting()
    {

    }
}
