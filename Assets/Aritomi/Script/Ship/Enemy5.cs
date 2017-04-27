using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    public class Enemy5 : Enemy
    {
        protected override void Initialize()
        {
            //ステータス初期化
            hp              = Status.ENEMY_SHIP_5_HP;
            offensivePower  = Status.ENEMY_SHIP_5_OFFENSIVE_POWER;
            AILevel         = Status.ENEMY_SHIP_5_AI;

            base.Initialize();
        }
    }
}