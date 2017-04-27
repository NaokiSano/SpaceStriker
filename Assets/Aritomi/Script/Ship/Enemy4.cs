using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    public class Enemy4 : Enemy
    {
        protected override void Initialize()
        {
            //ステータス初期化
            hp              = Status.ENEMY_SHIP_4_HP;
            offensivePower  = Status.ENEMY_SHIP_4_OFFENSIVE_POWER;
            AILevel         = Status.ENEMY_SHIP_4_AI;

            base.Initialize();
        }
    }
}