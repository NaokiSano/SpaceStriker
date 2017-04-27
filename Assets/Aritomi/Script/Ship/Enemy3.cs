using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    public class Enemy3 : Enemy
    {
        protected override void Initialize()
        {
            //ステータス初期化
            hp              = Status.ENEMY_SHIP_3_HP;
            offensivePower  = Status.ENEMY_SHIP_3_OFFENSIVE_POWER;
            AILevel         = Status.ENEMY_SHIP_3_AI;

            base.Initialize();
        }
    }
}