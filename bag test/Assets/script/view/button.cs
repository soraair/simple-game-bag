using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class button : MonoBehaviour
{
   //用于背包显示开关
    public GameObject Bag;

   
    public void openclose()
    {
        if (Bag.activeSelf == false)
            Bag.SetActive(true);
        else Bag.SetActive(false);
    }
	
}
