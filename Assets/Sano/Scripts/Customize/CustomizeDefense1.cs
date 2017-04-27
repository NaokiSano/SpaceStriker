using UnityEngine;
using System.Collections;

public class CustomizeDefense1 :CustomizeSkillAbs {

    protected override void Init()
    {
        activeButton = false;
    }

    protected override void Updates()
    {

    }

    public override void SetActive(bool active)
    {
        activeButton = active;
    }
}
