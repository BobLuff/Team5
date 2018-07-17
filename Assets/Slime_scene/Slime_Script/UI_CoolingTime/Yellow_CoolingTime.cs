using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 继承自SlimeCoolingTime类，用于显示是否可以扔黄色史莱姆
/// </summary>
public class Yellow_CoolingTime : SlimeCoolingTime
{
    public bool HavingYellow = true;

    // Use this for initialization
  
	// Update is called once per frame
	void Update () {
        if (!HavingYellow)
        {
            SetImageActiveState(false, true);

            UpdateSlimeCreate();
            HavingYellow = UpdateImageNormal();


        }
      
        m_Player_Control.Having_Slime_Yellow = HavingYellow;

    }
}
