/// DefenseShip.cs
/// 2016/01/15 ver1.0
using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    public class DefenseShip : Player
    {
        // 初期化
        protected override void Initialize()
        {
            // ステータス初期化
            hp = Status.DEFENSE_SHIP_HP;
            offensivePower = Status.DEFENSE_SHIP_OFFENSIVE_POWER;

            base.Initialize();
        }

        // 特殊行動
        protected override void ActSpecial()
        {
            // 何もしない
        }
    }
}