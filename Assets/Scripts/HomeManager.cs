using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{
    public static HomeManager THIS;
    public List<Sprite> playerSkin;
    public List<string> playerSkinName;
    public List<Sound_Name> soundsNameList;
    public GameObject showSkinObj, skinNameObj;
    public int skinDigit;
    void Start()
    {
        THIS = this;
        GameManager.THIS.destroyGameObjectList.Add(gameObject);
        skinDigit = GameManager.THIS.skinDigit;
        setPlayerSkin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLeft()
    {
        skinDigit -= 1;
        if (skinDigit < 0)
        {
            skinDigit += playerSkin.Count;
        }
        setPlayerSkin();
    }

    public void ChangeRight()
    {
        skinDigit += 1;
        skinDigit = skinDigit % playerSkin.Count;
        setPlayerSkin();
    }

    public void setPlayerSkin()
    {
        GameManager.THIS.skinDigit = skinDigit;
        GameManager.THIS.player.GetComponent<SpriteRenderer>().sprite = playerSkin[skinDigit];
        showSkinObj.GetComponent<Image>().sprite = playerSkin[skinDigit];
        showSkinObj.GetComponent<RectTransform>().sizeDelta = showSkinObj.GetComponent<Image>().sprite.bounds.size;
        skinNameObj.GetComponent<Text>().text = playerSkinName[skinDigit];
        skinNameObj.transform.GetChild(0).gameObject.GetComponent<Text>().text = playerSkinName[skinDigit];
    }
}
