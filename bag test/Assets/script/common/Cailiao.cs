using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cailiao : Item
{
    public Cailiao (int id, string name, Color color, string icon)
        : base(id, name, color, icon)
    {
        base.Type = "cailiao";
    }
}
