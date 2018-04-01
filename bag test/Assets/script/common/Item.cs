using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public string Type { get; protected set; }//让子类可以设置
    public Color Color { get; private set; }
    public string Icon { get; private set; }

    public Item(int id,string name, Color color, string icon)
    {
        this.ID = id;
        this.Name =  name;
   

        this.Color = color;
        this.Icon = icon;

    }
}
