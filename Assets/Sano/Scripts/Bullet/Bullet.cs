using UnityEngine;
using System.Collections;

/// <summary>
///     Bullet(弾)の基本クラス
/// </summary>

public abstract class  Bullet : MonoBehaviour {

    [HideInInspector]
    public GameObject target;    // ターゲット(Player)
    public ParticleSystem effect;   // 弾エフェクト
    public GameObject bullet;       // 削除対象の弾
    public GameObject deadWall;     // 弾削除の壁
    public int attackDmg;           // 弾攻撃力
    public int forwardSpeed;        // 進行スピード
    public float homingOff;         // ホーミングを切るターゲットとの距離
    public GameObject explosionEffect; // 被弾爆発エフェクト
    protected float distance;       // ターゲットとの距離
    protected bool shootOk;         // 発射間隔

	// Use this for initialization
	void Start () {
        Initialize();
        effect.playOnAwake = true;
	}

    void Awake() {
        AwakeInit();
    }

    protected abstract void AwakeInit();

    protected abstract void Initialize();

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// 基本となるBulletの移動
    /// </summary>
    protected abstract void Move();

    /// <summary>
    /// あたった時
    /// </summary>
    /// <param name="col">対象</param>
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy")
        {
            Instantiate(explosionEffect, target.transform.position, target.transform.rotation);
            BulletDead();
        }
        else if (col.gameObject.tag == "Menu_Start" || col.gameObject.tag == "Menu_Credit")
        {
            Instantiate(explosionEffect, target.transform.position, target.transform.rotation);
            BulletDead();
        }
        else if (col.gameObject.tag == "shield")
        {
            Instantiate(explosionEffect, gameObject.transform.position, target.transform.rotation);
            BulletDead();
        }
        else if (col.gameObject.tag == "DeadBullet")
        {
            BulletDead();
        }
    }

    protected void BulletDead()
    {
        Destroy(bullet);
    }
}
