using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;//事件命名空间，下面两个接口可用


public class GridPanelUI : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    private float DragBeginY = 0;
    private float DragCurrentY = 0;
    private float DragSegmentY=0;

    public Transform[] Grids;

    public Transform GetEmptyGrid()
    {
        for(int i = 0; i < Grids.Length; i++)
        {
            if (Grids[i].childCount == 0)
                return Grids[i];

        }
          return null;
    }

    //以下几个方法为上下拖动背包
    public void Update()
    {
       UpdataPosition(this.transform, DragBeginY, DragCurrentY, DragSegmentY);
    }


   
    public void OnDrag(PointerEventData eventData)
    {

        DragCurrentY = Input.mousePosition.y;
        DragSegmentY = DragCurrentY - DragBeginY;
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            DragBeginY = Input.mousePosition.y;

        }
    }



    public void UpdataPosition(Transform transform, float dragBeginY, float dragCurrentY, float dragSegmentY)
    {
        if ((this.transform.position.y > 190) && (this.transform.position.y<460))
        {
            transform.position = new Vector3(this.transform.position.x, this.transform.position.y + DragSegmentY, this.transform.position.z);
           
        }
        if (this.transform.position.y <= 190)
        {
            transform.position = new Vector3(this.transform.position.x, 195, this.transform.position.z);
        }

        if (this.transform.position.y >=460)
            {
                transform.position = new Vector3(this.transform.position.x, 455, this.transform.position.z);

            }
            DragBeginY = Input.mousePosition.y;
            DragCurrentY = Input.mousePosition.y;
            DragSegmentY = DragCurrentY - DragBeginY;

        }

}
