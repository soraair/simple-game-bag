using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class ItemModel  {

    //相当于物品库的构建，用于在库里取物品放到背包里  和  将物品从背包里取放到库中
    public static Dictionary<string, Item> GridItem = new Dictionary<string, Item>();

    public static void StoreItem(string name,Item item)
    {
        DeleteItem(name);

        GridItem.Add(name,item);
    }

    public static Item GetItem(string name)
    {
        if (GridItem.ContainsKey(name))
            return GridItem[name];
        else return null;
    }

    public static void DeleteItem(string name)
    {
        if (GridItem.ContainsKey(name))
            GridItem.Remove(name);
    }

}
