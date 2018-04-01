using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetector : MonoBehaviour {

	
	
	//按G键在背包里生成新的物品
	void Update () {
        if (Input.GetKeyDown("g"))
        {
            BagManageUI.instance.StoreItem(Random.Range(1, 7));//随机取索引为1到2 的物品
        }
	}
}
