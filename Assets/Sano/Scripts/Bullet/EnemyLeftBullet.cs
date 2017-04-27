using UnityEngine;
using System.Collections;

public class EnemyLeftBullet : Bullet {

    [SerializeField]
    private int leftPower; // 右にカーブ
    private float speed;
    private bool trigger;

    protected override void AwakeInit()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void Initialize()
    {
        GetComponent<Rigidbody>().AddForce(leftPower, 0, 0, ForceMode.Impulse);
        trigger = true;
    }

    protected override void Move()
    {
        distance = this.GetComponent<Rigidbody>().position.z - target.transform.position.z;

        if (distance > homingOff)
        {
            float step = forwardSpeed * Time.deltaTime;
            this.GetComponent<Rigidbody>().transform.position = Vector3.MoveTowards(this.GetComponent<Rigidbody>().transform.position, target.transform.position, step);

            Vector3 targetPosition = target.transform.position;
        }
        else
        {
            float movePosZ = 1.5f;      // Z軸移動(自機方向)
            float magnification = 1.5f; // 倍率

            this.GetComponent<Rigidbody>().transform.position -= new Vector3(0, 0, movePosZ);
            if (trigger)
            {
                GetComponent<Rigidbody>().AddForce(-leftPower * magnification, 0, 0, ForceMode.Impulse);
                trigger = false;
            }
        }
    }
}
