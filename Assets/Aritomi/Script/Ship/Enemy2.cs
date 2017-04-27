using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    public class Enemy2 : Enemy
    {
        protected override void Initialize()
        {
            //ステータス初期化
            hp              = Status.ENEMY_SHIP_2_HP;
            offensivePower  = Status.ENEMY_SHIP_2_OFFENSIVE_POWER;
            AILevel         = Status.ENEMY_SHIP_2_AI;

            base.Initialize();
        }
    }
}