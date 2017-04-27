using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CustomizeAttack1 : CustomizeSkillAbs{

    protected override void Init()
    {
        activeButton = false;
    }

    protected override void Updates()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = hit.collider.gameObject;
                if (obj.name == "Attack1")
                {
                    managetScript.SetActive(CustomizeField.CUSTOMIZE_OFF);
                }
            }
        }
    }


    public override void SetActive(bool active)
    {
        activeButton = active;
    }
}
