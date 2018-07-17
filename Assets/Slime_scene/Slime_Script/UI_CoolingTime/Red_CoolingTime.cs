using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 继承自SlimeCoolingTime类，用于显示是否可以扔红色史莱姆
/// </summary>

public class Red_CoolingTime : SlimeCoolingTime
{
    public bool HavingRed = true;

 

    // Update is called once per frame
    void Update () {
        if (!HavingRed)
        {
            SetImageActiveState(false, true);

            UpdateSlimeCreate();

             HavingRed = UpdateImageNormal();


        }

       
            m_Player_Control.Having_Slime_Red = HavingRed;
   
        // HavingRed = UpdateImageNormal();
        // m_Player_Control.Having_Slime_Red = HavingRed;

    }
}
