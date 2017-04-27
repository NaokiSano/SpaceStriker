using UnityEngine;
using System.Collections;

public class EnemyNormalBullet : Bullet {

    protected override void AwakeInit()
    {
        target = GameObject.FindGameObjectWithTag("Player");

    }

    protected override void Initialize()
    {
        
    }

    protected override void Move()
    {
        bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -forwardSpeed);
    }
}
