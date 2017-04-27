using UnityEngine;
using System.Collections;

public class BalanceType :CustomizeSkillAbs{

    protected override void Init()
    {
        activeButton = true;
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
