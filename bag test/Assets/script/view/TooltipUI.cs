using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipUI : MonoBehaviour {

    //用于点击物品时显示的信息框
    public Text ContentText;
    public Image image;

    public void UpdateTooltip(string text,Color color,string route)
    {
        //OutlineText.text = text;

        //OutlineText.color = color;

        ContentText.text = text;

        ContentText.color = color;
        

        image.overrideSprite = Resources.Load(route, typeof(Sprite)) as Sprite;

    }

    public void Show()   //控制信息框显示与隐藏
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
