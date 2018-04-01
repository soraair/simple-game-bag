using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class BagManageUI : MonoBehaviour
{

    public TooltipUI tooltipUI;
    private static BagManageUI _instance;
    public static BagManageUI instance { get { return _instance; } }

    public GridPanelUI GridPanelUI;
    public DragItemUI DragITemUI;
    public Drag Drag;

    public  bool isDrag = false;

    public Dictionary<int, Item> ItemList = new Dictionary<int, Item>();

    private float DragBeginY = 0;
    private float DragCurrentY = 0;
    private float DragSegmentY = 0;

    private void Start()
    {
        DragITemUI.Hide();
        tooltipUI.Hide();
    }


    void Awake()
    {
        //单例
        _instance = this;
        //数据
        Load();
        //事件
        GridUI.onClick += GridUI_OnClick;
        GridUI.onClick2 += GridUI_OnClick2;
        GridUI.onLeftBebinDrag += GridUI_onLeftBeginDrag;
        GridUI.onLeftEndDrag += GridUI_onLeftEndDrag;
        //OnPointerDown +=
    }

    private void Update()
    {
        Vector3 position;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(GameObject.Find("BagUI").transform as RectTransform, Input.mousePosition, null, out position);

         if (isDrag)
        {
            DragITemUI.Show();
            DragITemUI.setLocalposition(position);
            
           
        }
       



    }

    //向背包添加物品
    //
    //
    //
    public void StoreItem(int itemId)
    {
        if (!ItemList.ContainsKey(itemId))  //检查含不含此id的物品
            return;

       
        Transform emptyGrid = GridPanelUI.GetEmptyGrid();
      

        if (emptyGrid == null)
        {
            Debug.LogWarning("背包已满");
            return;
        }

        Item temp = ItemList[itemId];
        this.CreateNewItem(temp, emptyGrid);


    }

    //获取物品列表
    //
    //
    //
    private void Load()
    {

        ItemList = new Dictionary<int, Item>();

        Weapon w1 = new Weapon(1, "Excalibur", Color.blue, "1");
        Weapon w2 = new Weapon(2, "Gaebolg", Color.green, "1");
        Consumable co1 = new Consumable(3, "red", Color.green, "1");
        Consumable co2 = new Consumable(4, "blue", Color.green, "1");
        Cailiao c1 = new Cailiao(5, "IceEye", Color.blue, "1");
        Cailiao c2 = new Cailiao(6, "hushou", Color.green, "1");

        ItemList.Add(w1.ID, w1);
        ItemList.Add(w2.ID, w2);
        ItemList.Add(co1.ID, co1);
        ItemList.Add(co2.ID, co2);
        ItemList.Add(c1.ID, c1);
        ItemList.Add(c2.ID, c2);
    }

    #region 事件回调

    public void GridUI_OnClick(Transform gridTransform)
    {
        Item item = ItemModel.GetItem(gridTransform.name);
        //Debug.Log(gridTransform.name);
        if (item == null)
            return;
        tooltipUI.UpdateTooltip(item.Name, item.Color, ("Pictures/" + item.Name));//更新物品信息

        tooltipUI.transform.position = new Vector3(gridTransform.position.x + 50, gridTransform.position.y - 50, 0);
        tooltipUI.Show();

    }

    public void GridUI_OnClick2()
    {

        tooltipUI.Hide();
    }


    //鼠标开始拖动事件
    public void GridUI_onLeftBeginDrag(Transform gridTransform)
    {
        //如果点的格子里没有物品
        if (gridTransform.childCount == 0)
        {
            return;
            
           
        }
           // 格子里有物品
        else
        {
           
            Item item = ItemModel.GetItem(gridTransform.name);
            Sprite s = Resources.Load("Pictures/" + item.Name, typeof(Sprite)) as Sprite;


            DragITemUI.UpdateImage(s);
            Destroy(gridTransform.GetChild(0).gameObject);

            isDrag = true;

   
        }
    }

   

    //鼠标结束拖动
    public void GridUI_onLeftEndDrag(Transform prevTransform, Transform enterTransform)
    {
        //判断是否在拖着东西
        if (isDrag == false)
            return;
        
        isDrag = false;
        DragITemUI.Hide();
      

        if (enterTransform == null)//扔掉东西
        {
            Debug.LogWarning("reng");
 
            ItemModel.DeleteItem(prevTransform.name);
        }

        else if (enterTransform.tag == "Grid")//拖到当前各自或其他格子
        {
            Debug.LogWarning("kongge");
            if (enterTransform.childCount == 0) //直接放入
            {
                
                Item item = ItemModel.GetItem(prevTransform.name);
                this.CreateNewItem(item, enterTransform);
                ItemModel.DeleteItem(prevTransform.name);
                      }
            else //交换格子的物品
            {
                Item preItem = ItemModel.GetItem(prevTransform.name);
                Item enterItem = ItemModel.GetItem(enterTransform.name);
                Destroy(enterTransform.GetChild(0).gameObject);
              
                this.CreateNewItem(preItem, enterTransform);
              
                this.CreateNewItem(enterItem, prevTransform);
              
               
            }
        }
        else//拖到其他地方
        {
            Item item = ItemModel.GetItem(prevTransform.name);
            this.CreateNewItem(item, prevTransform);
        }

    }
    #endregion

    //用于向格子里新建物品
    private void CreateNewItem(Item item, Transform parent)
    {

        GameObject ItemPrefab = Resources.Load<GameObject>("prefabs/Item");//动态加载物品

        GameObject ItemGo = GameObject.Instantiate(ItemPrefab);//实例化物品


        ItemGo.transform.GetComponent<Image>().overrideSprite = Resources.Load("Pictures/" + item.Name, typeof(Sprite)) as Sprite;
        //给物品上图
        //Debug.Log(Resources.Load("Pictures/" + item.Name, typeof(Sprite)) as Sprite);

        ItemGo.transform.SetParent(parent);      //设置空格子为物品的父级
        ItemGo.transform.localPosition = Vector3.zero;//与父级相对位置为零
        ItemGo.transform.localScale = Vector3.one;
        ItemModel.StoreItem(parent.name, item);

    }

  
}




