// ====================================================
// エネミーコントローラー
// Yuho Aritomi
// EnemyController.cs v1.0
// new 入力情報を更新する
// new ランダムで撃つ
// ====================================================
using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    public class EnemyController : Controller
    {
        [SerializeField]
        private Sensor sensor;

        private enum STEP
        {
            ACTION_WAIT,
            ACTION_AVOIDANCE,
            ACTION_SHOT,
        }
        STEP step;

        //どのボタンを押したかの判定用列挙変数
        private enum TouchButton
        {
            TOUCH_TOP = 0,
            TOUCH_RIGHT,
            TOUCH_LEFT,
            TOUCH_CHAGE,
        }

        // 初期化処理
        protected override void Initialize()
        {
            base.Initialize();
        }

        //撃つ
        private void Shot()
        {
            int rnd = Random.Range(0, 3);

            switch (rnd)
            {
                case (int)TouchButton.TOUCH_TOP:
                    inputState = InputState.TOUCH_TOP;
                    break;
                case (int)TouchButton.TOUCH_RIGHT:
                    inputState = InputState.TOUCH_RIGHT;
                    break;
                case (int)TouchButton.TOUCH_LEFT:
                    inputState = InputState.TOUCH_LEFT;
                    break;
            }
        }

        // 入力情報更新処理
        protected override void InputStateUpdate()
        {
            switch (step)
            {
                case STEP.ACTION_WAIT:

                    return;

                case STEP.ACTION_AVOIDANCE:

                    return;

                case STEP.ACTION_SHOT:

                    return;
            }
        }
    }
}
