using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    public class Enemy1 : Enemy
    {
        protected override void Initialize()
        {
            //ステータス初期化
            hp              = Status.ENEMY_SHIP_1_HP;
            offensivePower  = Status.ENEMY_SHIP_1_OFFENSIVE_POWER;
            AILevel         = Status.ENEMY_SHIP_1_AI;

            base.Initialize();
        }
    }
}