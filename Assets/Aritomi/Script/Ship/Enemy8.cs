using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    public class Enemy8 : Enemy
    {
        protected override void Initialize()
        {
            //ステータス初期化
            hp              = Status.ENEMY_SHIP_8_HP;
            offensivePower  = Status.ENEMY_SHIP_8_OFFENSIVE_POWER;
            AILevel         = Status.ENEMY_SHIP_8_AI;

            base.Initialize();
        }
    }
}