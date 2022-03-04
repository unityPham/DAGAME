using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ClickFuntion
{
    None,
    Restar,
    GameStart,
    Home,
    Setting,
    ChangeSkinLeft,
    ChangeSkinRight,
}

public class UI_Click : MonoBehaviour
{

    public ClickFuntion clickFuntion = ClickFuntion.None;
    public void Click()
    {
        switch (clickFuntion)
        {
            case ClickFuntion.Restar:
                {
                    GameManager.THIS.RestarGame();
                    break;
                }
            case ClickFuntion.GameStart:
                {
                    GameManager.THIS.OpenGameStart();
                    break;
                }
            case ClickFuntion.Home:
                {
                    GameManager.THIS.OpenHome();
                    break;
                }
            case ClickFuntion.ChangeSkinLeft:
                {
                    HomeManager.THIS.ChangeLeft();
                    break;
                }
            case ClickFuntion.ChangeSkinRight:
                {
                    HomeManager.THIS.ChangeRight();
                    break;
                }
            case ClickFuntion.Setting:
                {
                    GameManager.THIS.OpenSetting();
                    break;
                }
        }
    }
}
