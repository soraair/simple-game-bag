using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
   public Consumable (int id, string name, Color color, string icon)
        : base(id, name, color, icon)
    {
        base.Type = "consumable";
    }
}