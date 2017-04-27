using UnityEngine;
using System.Collections;

public class LeftBullet : Bullet {

    [SerializeField]
    private int leftPower;   // 左にカーブ
    private float speed;
    private bool trigger;

    protected override void AwakeInit()
    {
        target = GameObject.FindGameObjectWithTag("Enemy");
    }

    protected override void Initialize()
    {
        GetComponent<Rigidbody>().AddForce(-leftPower, 0, 0, ForceMode.VelocityChange);
        trigger = true;
    }

    protected override void Move()
    {
        distance = this.GetComponent<Rigidbody>().position.z - target.transform.position.z;

        if (distance < -homingOff)
        {
            float step = forwardSpeed * Time.deltaTime ;
            this.GetComponent<Rigidbody>().transform.position = Vector3.MoveTowards(this.GetComponent<Rigidbody>().transform.position, target.transform.position, step);
        }
        else
        {
            float movePosZ = 1.5f;      // Z軸移動(自機方向)
            float magnification = 1.5f; // 倍率

            this.GetComponent<Rigidbody>().transform.position += new Vector3(0, 0, movePosZ);
            if (trigger)
            {
                GetComponent<Rigidbody>().AddForce(leftPower * magnification, 0, 0, ForceMode.Impulse);
                trigger = false;
            }
        }
    }
}
