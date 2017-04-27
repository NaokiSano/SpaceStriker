using UnityEngine;
using System.Collections;

public class MenuBullet : Bullet{

    bool menuOK;
    protected override void AwakeInit() { }
    protected override void Initialize() 
    { 
        menuOK = true; 
    }

    protected override void Move()
    {
        if (target != null && menuOK)
        {
            float step = forwardSpeed * Time.deltaTime;
            this.GetComponent<Rigidbody>().transform.position =
                Vector3.MoveTowards(this.GetComponent<Rigidbody>().transform.position, target.transform.position, step);
        }
    }


}