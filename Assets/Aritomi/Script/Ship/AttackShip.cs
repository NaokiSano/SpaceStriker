using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    public class AttackShip : Player
    {
        // 初期化
        protected override void Initialize()
        {
            // ステータス初期化
            hp = Status.ATTACK_SHIP_HP;
            offensivePower = Status.ATTACK_SHIP_OFFENSIVE_POWER;

            base.Initialize();
        }

        // 特殊行動
        protected override void ActSpecial()
        {
            // 何もしない
        }
    }
}
