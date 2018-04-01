using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DragItemUI : MonoBehaviour {

    public Text ItemName;
    public Image ItemImage;
    

    //用于拖动物品
    public void UpdateItem(string name)
    {
        ItemName.text = name;

    }

   

    public void UpdateImage(Sprite s)
    {
        ItemImage.sprite = s;
      
    }
    


    public void Show()
    {
        gameObject.SetActive(true);
        
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void setLocalposition(Vector2 position)
    {
      transform.position = position;
    }
}
