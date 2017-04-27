using UnityEngine;
using System.Collections;

public class AttackType : CustomizeSkillAbs{

    protected override void Init()
    {
        activeButton = false;
    }

    protected override void Updates()
    {
        if (activeButton)
        {
            ShipModel.SetActive(true);
        }
        else
            ShipModel.SetActive(false);
    }

    public override void SetActive(bool active)
    {
        activeButton = active;
    }
}
