using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
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
    public List<GameObject> enemySpawnList, destroyGameObjectList;
    public GameObject overCanvas, homeCanvas, audioManagerObj;
    public GameObject gamePlayGround, mainCamera, player, gamePlayShowScoreObj, gamePlayBackGoundObj;
    public Vector3 cameraPosition;
    public Vector2 playerMovieVector;
    public float speedUp,gamePlayDeltaFrame, playerPositionY, enemyDistance, enemyDigit;
    public int skinDigit, nextEnemyDigit;

    public int score, bestScore;

    public bool mute;
    void Start()
    {
        THIS = this;
        Application.targetFrameRate = 60;
        gamePlayDeltaFrame = 60.0f / Application.targetFrameRate;
        cameraPosition = new Vector3(0, 0, -1);
        AudioManager.THIS = Instantiate(audioManagerObj).GetComponent<AudioManager>();
        AudioManager.THIS.Play(Sound_Name.introOver);
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
        SpawnEnemy();
        showScore();
        keyControl();
    }

    public void SpawnEnemy()
    {
        nextEnemyDigit = (int)(mainCamera.transform.position.x / enemyDistance)+5;
        if (nextEnemyDigit >= enemyDigit)
        {
            int random = Random.Range(0, 10);
            Player_Positon_Y enemyPosition_Y;
            if(Random.Range(0, 2) == 0)
            {
                enemyPosition_Y = Player_Positon_Y.up;
            }
            else
            {
                enemyPosition_Y = Player_Positon_Y.down;
            }
            GameObject enemyObj = Instantiate(enemySpawnList[Random.Range(1, enemySpawnList.Count)]);
            enemyObj.transform.position = new Vector2(enemyDigit * enemyDistance, (int)enemyPosition_Y * 0.1f);
            destroyGameObjectList.Add(enemyObj);
            if (Random.Range(0, 10) <4)
            {
                enemyDigit += Random.Range(1, 3);
                SpawnMoney(enemyPosition_Y);
                enemyDigit += Random.Range(1, 3);
            }
            else
            {
                enemyDigit += Random.Range(7, 10);
            }
        }
    }

    public void SpawnMoney(Player_Positon_Y pos_Y)
    {
        if (Random.Range(0, 4) == 0)
        {
            for(int i = 0; i < 5; i++)
            {
                GameObject moneyObj = Instantiate(enemySpawnList[0]);
                moneyObj.GetComponent<Money>().enemyDigit = enemyDigit;
                moneyObj.GetComponent<Money>().upDownPosition = pos_Y;
                enemyDigit++;
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject moneyObj = Instantiate(enemySpawnList[0]);
                moneyObj.GetComponent<Money>().enemyDigit = enemyDigit;
                moneyObj.GetComponent<Money>().upDownPosition = Player_Positon_Y.up;

                GameObject moneyObj2 = Instantiate(enemySpawnList[0]);
                moneyObj2.GetComponent<Money>().enemyDigit = enemyDigit;
                moneyObj2.GetComponent<Money>().upDownPosition = Player_Positon_Y.down;
                destroyGameObjectList.Add(moneyObj);
                destroyGameObjectList.Add(moneyObj2);
                enemyDigit++;
            }
        }
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
            GamePlayControl();
        }
    }

    public void GamePlayControl()
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
        enemyDigit = 6;
        gameMod = Game_Mod.playing;
        AudioManager.THIS.StopAll();
        AudioManager.THIS.Play(HomeManager.THIS.soundsNameList[HomeManager.THIS.skinDigit]);
        gamePlayShowScoreObj.SetActive(true);
        showScore();
        removeAllDestroyList();
    }

    public void OpenGameOver()
    {
        gameMod = Game_Mod.over;
        AudioManager.THIS.StopAll();
        AudioManager.THIS.Play(Sound_Name.boom);
        AudioManager.THIS.Play(Sound_Name.introOver);
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
