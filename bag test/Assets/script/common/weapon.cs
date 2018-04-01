using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
   public Weapon(int id, string name, Color color, string icon)
        : base(id, name ,color,icon )
    {
        base.Type = "weapon";
    }

}
