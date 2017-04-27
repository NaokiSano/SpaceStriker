/// Ship2.cs
/// 2016/01/15 ver1.0
using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    public class Enemy : SpaceShip
    {
        [SerializeField]
        Sensor sensor;

        protected int AILevel;

        private enum Step
        {
            ACTION_WAIT,
            ACTION_AVOIDANCE,
            ACTION_SHOT
        }
        private Step step;

        private InputState[] shotType = new InputState[]
        {
            InputState.TOUCH_TOP,
            InputState.TOUCH_RIGHT,
            InputState.TOUCH_LEFT
        };

        // 初期化
        protected override void Initialize()
        {

            // 場面を初期化
            step = Step.ACTION_WAIT;

            base.Initialize();
        }

        // 特殊行動
        protected override void ActSpecial()
        {

        }

        private bool flag_chage;

        // 更新
        protected override void ShipUpdate()
        {
            if (!(bCanAct))
            {
                DebugLog("エネミーは行動しているので何もできない。");
                return;
            }

            switch (step)
            {
                case Step.ACTION_WAIT:
                    Wait();
                    return;
                case Step.ACTION_AVOIDANCE:
                    Avoidance();
                    return;
                case Step.ACTION_SHOT:
                    Shot();
                    return;
            }
        }

        private void Wait()
        {
            if (Random.Range(0, AILevel) == 0)
            {
                step = Step.ACTION_SHOT;
                return;
            }

            if (sensor.GetFlagCol())
            {
                step = Step.ACTION_AVOIDANCE;
                return;
            }
            DebugLog("エネミーは様子を見ている。");
        }

        private void Avoidance()
        {
            DebugLog("エネミーは弾を検知した。");
            if (sensor.ColNormalBullet())
            {
                ssInputState = InputState.TOUCH_BOTTOM;
            }
            if (sensor.ColRightBullet())
            {
                ssInputState = InputState.FLICK_RIGHT;
            }
            if (sensor.ColLeftBullet())
            {
                ssInputState = InputState.FLICK_LEFT;
            }

            sensor.ColInitialize();
            step = Step.ACTION_WAIT;
        }

        private void Shot()
        {
            int select_bullet = 0;

            DebugLog("エネミーは弾を撃つことにした。");

            if (!flag_chage)
            {
                select_bullet = Random.Range(0, 3);
            }

            ssInputState = shotType[select_bullet];

            if (select_bullet == 3)
            {
                flag_chage = true;
                ssInputState = InputState.TOUCH_TRUE;
                if (bCanChageShot == true)
                {
                    ssInputState = InputState.TOUCH_TOP;
                    flag_chage = false;
                }
            }

            sensor.ColInitialize();
            step = Step.ACTION_WAIT;
        }
    }
}