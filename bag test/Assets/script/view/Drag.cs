using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;//事件命名空间，下面两个接口可用


public class Drag : MonoBehaviour//, IDragHandler, IPointerDownHandler
{
    private float DragBeginY = 0;
    private float DragCurrentY = 0;
    private float DragSegmentY = 0;
    public bool isdrag =false;

    private Transform grid ;
   
    //以下几个方法同样为上下拖动背包
    public void Update()
    {
        if (isdrag == true)
        { UpdataPosition(transform, DragBeginY, DragCurrentY, DragSegmentY); }
        if (Input.GetKeyUp(KeyCode.Mouse0))
            isdrag = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        grid = eventData.pointerEnter.transform;

        if (grid.GetChildCount() == 0)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                DragBeginY = Input.mousePosition.y;

            }
            isdrag = true;
        }
        else return;

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (grid.GetChildCount() == 0)
        {

            DragCurrentY = Input.mousePosition.y;
            DragSegmentY = DragCurrentY - DragBeginY;
        }


    }


    public void UpdataPosition(Transform transform, float dragBeginY, float dragCurrentY, float dragSegmentY)
    {
        if (transform.parent.transform.position.y > 190 && transform.parent.transform.position.y < 460)
        {
            transform.parent.transform.position = new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y + DragSegmentY, transform.parent.transform.position.z);

        }
        if(transform.parent.transform.position.y <= 190)
        {
            transform.parent.transform.position = new Vector3(transform.parent.transform.position.x, 195, transform.parent.transform.position.z);
        }

        if (transform.parent.transform.position.y >=460)
        {
            transform.parent.transform.position = new Vector3(transform.parent.transform.position.x, 455, transform.parent.transform.position.z);
        }

        DragBeginY = Input.mousePosition.y;
        DragCurrentY = Input.mousePosition.y;
        DragSegmentY = DragCurrentY - DragBeginY;
    }


}
