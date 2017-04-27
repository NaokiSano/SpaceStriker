using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    public class BalanceShip : Player
    {
        // 初期化
        protected override void Initialize()
        {
            // ステータス初期化
            hp = Status.BALANCE_SHIP_HP;
            offensivePower = Status.BALANCE_SHIP_OFFENSIVE_POWER;

            base.Initialize();
        }

        // 特殊行動
        protected override void ActSpecial()
        {
            // 何もしない
        }
    }
}
