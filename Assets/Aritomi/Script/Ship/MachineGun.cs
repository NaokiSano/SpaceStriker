// ===================================================
// 機銃クラス
// Yuho Aritomi
// MachineGun.cs v1.0
// new 通常弾を撃ちだす
// new 右曲弾を撃ちだす
// new 左曲弾を撃ちだす
// new チャージ弾を撃ちだす
// ===================================================
using UnityEngine;
using System.Collections;

public class MachineGun : MonoBehaviour {
    public GameObject objNormalBullet;  // 通常弾
    public GameObject objRightBullet;   // 右曲弾
    public GameObject objLeftBullet;    // 左曲弾
    public GameObject objChageBullet;   // チャージ弾
    public Transform traNormalBullet;   // 通常弾位置情報
    public Transform traRightBullet;    // 右曲弾位置情報
    public Transform traLeftBullet;     // 左曲弾位置情報

    // ノーマル弾発射
    public void ShotNormalBullet() 
    {
        Instantiate(objNormalBullet,
            traNormalBullet.position,
            traNormalBullet.rotation); 
    }

    // 右曲弾発射
    public void ShotRightBullet()
    {
        Instantiate(objRightBullet,
            traRightBullet.position,
            traLeftBullet.rotation);
    }

    // 左曲弾発射
    public void ShotLeftBullet()
    {
        Instantiate(objLeftBullet,
            traLeftBullet.position,
            traLeftBullet.rotation);
    }

    // チャージ弾を発射
    public void ShotChageBullet()
    {
        Instantiate(objChageBullet,
            traNormalBullet.position,
            traNormalBullet.rotation);
    }
}
