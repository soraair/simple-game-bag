using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour {
    
    //用于更新物品的位置
    public Text ItemName;
     public void UpdateItem(string name)
    {
        ItemName.text = name;

    }

    public Image ItemImage;

    public void UpdateImage(Sprite s)
    {
        ItemImage.sprite = s; 
    }
}
