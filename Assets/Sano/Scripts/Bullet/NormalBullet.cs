using UnityEngine;
using System.Collections;

public class NormalBullet : Bullet{

    [System.NonSerialized]
    public bool direction;


    protected override void AwakeInit()
    {
        target = GameObject.FindGameObjectWithTag("Enemy");
    }
	
    protected override void Initialize()
    {

    }

    protected override void Move()
    {
            bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, forwardSpeed);
    }  
}
