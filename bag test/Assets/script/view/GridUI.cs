using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;//事件命名空间，下面两个接口可用
using System;

public class GridUI : MonoBehaviour ,IPointerClickHandler 
    ,IBeginDragHandler,IDragHandler,IEndDragHandler
{
//来自 using System  
    public static Action<Transform> onClick;   //显示框
    public static Action onClick2;   //关闭框
    public static Action<Transform> onLeftBebinDrag;
    public static Action<Transform,Transform> onLeftEndDrag;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(eventData.button==PointerEventData.InputButton.Left)
        {
          
            if (onLeftBebinDrag != null)
                onLeftBebinDrag(transform);
            else
            {
                Debug.LogWarning("没拖物品");
                //return;
                GetComponent<Drag>().isdrag = true;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //this.gameObject.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (onLeftEndDrag != null)
            {
                if (eventData.pointerEnter == null)
                    onLeftEndDrag(transform, null);
                else
                    onLeftEndDrag(transform, eventData.pointerEnter.transform);

            }
            else return;

        }

    }

    //点击显示和关闭物品信息
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerPress.tag == "Grid")
            if (onClick != null)
                onClick(transform);


        if (eventData.pointerPress.tag == "Tooltip")
            if (onClick2 != null)
            {
                onClick2();
               // Debug.LogWarning("aaa");
            }
    }
}
