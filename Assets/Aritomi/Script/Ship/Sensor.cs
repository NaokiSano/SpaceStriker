// Sensor.cs
// 2016/01/18 ver1.0
using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    public class Sensor : MonoBehaviour
    {
        // ぶつかった弾の情報
        private bool col_normalBullet = false;
        private bool col_rightBullet = false;
        private bool col_leftBullet = false;
        private bool flag_col =false;

        private void ColUpdate(bool _col_1, bool _col_2, bool _col_3)
        {
            col_normalBullet = _col_1;
            col_rightBullet = _col_2;
            col_leftBullet = _col_3;

        }

        void OnTriggerEnter(Collider col)
        {
            switch (col.tag)
            {
                case TagConstant.TAG_NORMAL_BULLET:
                    ColUpdate(true, false, false);
                    flag_col = true;
                    break;
                case TagConstant.TAG_RIGHT_BULLET:
                    ColUpdate(false, true, false);
                    flag_col = true;
                    break;
                case TagConstant.TAG_LEFT_BULLET:
                    ColUpdate(false, false, true);
                    flag_col = true;
                    break;
            }
        }

        /// <summary>
        /// ノーマルバレットが当たったかを取得する
        /// </summary>
        /// <returns></returns>
        public bool ColNormalBullet()
        {
            return col_normalBullet;
        }
        /// <summary>
        /// ライトバレットが当たったか取得する
        /// </summary>
        /// <returns></returns>
        public bool ColRightBullet()
        {
            return col_rightBullet;
        }
        /// <summary>
        /// レフトバレットが当たったか取得する
        /// </summary>
        /// <returns></returns>
        public bool ColLeftBullet()
        {
            return col_leftBullet;
        }
        /// <summary>
        /// センサーが何かに当たったかを取得する
        /// </summary>
        /// <returns></returns>
        public bool GetFlagCol()
        {
            return flag_col;
        }
        /// <summary>
        /// フラグ初期化
        /// </summary>
        public void ColInitialize()
        {
            ColUpdate(false, false, false);
            flag_col = false;
        }
    }
}
