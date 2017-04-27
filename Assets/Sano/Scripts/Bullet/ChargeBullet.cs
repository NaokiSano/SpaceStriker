using UnityEngine;
using System.Collections;

public class ChargeBullet : Bullet {

    protected override void AwakeInit()
    {
        target = GameObject.FindGameObjectWithTag("Enemy");
    }

    protected override void Initialize()
    {
        effect.playOnAwake = true;
    }

    protected override void Move()
    {
        bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, forwardSpeed);
    }
}
