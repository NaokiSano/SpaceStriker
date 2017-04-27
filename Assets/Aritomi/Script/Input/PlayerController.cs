// ==================================================
// プレイヤーコントローラークラス
// Aritomi Yuuho
// Controller.cs v1.0
// new 入力情報を更新する
// ==================================================
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerController : Controller
{
    private bool bIsTouch;
    private Vector3 vec3FirstMousePosition;
    private Vector3 vec3FinishMousePosition;

    // 初期化処理
    protected override void Initialize()
    {
        bIsTouch = false;
        vec3FirstMousePosition = Vector3.zero;
        vec3FinishMousePosition = Vector3.zero;

        base.Initialize();
    }

    // タッチされたときの処理
    private void OnTouchEnter(Vector3 _vec3TouchPosition)
    {
        bIsTouch = true;
        vec3FirstMousePosition = _vec3TouchPosition;
        base.inputState = InputState.TOUCH_TRUE;
    }

    // タッチされているときの処理
    private void OnTouchStay()
    {

    }

    // フリック処理
    private void Flick()
    {
        float fFirstX, fFinishX, fDistance;
        fFirstX = vec3FirstMousePosition.x;
        fFinishX = vec3FinishMousePosition.x;
        fDistance = Mathf.Abs(fFinishX - fFirstX);

        if (fDistance > PCConstant.FLICK_RANGE)
        {
            if (fFinishX > fFirstX) 
                base.inputState = InputState.FLICK_RIGHT;
            else 
                base.inputState = InputState.FLICK_LEFT;
        }
    }

    /*===================================================
     * Purpose  : タッチし終わったときの処理
     * Argument : _vec3TouchPosition マウスの位置
     * Return   : なし
     ===================================================*/
    private void OnTouchExit(Vector3 _vec3TouchPosition)
    {
        bIsTouch = false;
        vec3FinishMousePosition = _vec3TouchPosition;

        Flick();

        vec3FirstMousePosition = Vector3.zero;
        vec3FinishMousePosition = Vector3.zero;
    }

    /*===================================================
     * Override
     * Purpose  : InputState更新
     * Argument : なし
     * Return   : InputState 入力情報
     ===================================================*/
    protected override void InputStateUpdate()
    {
        if (!(bIsTouch)) base.inputState = InputState.TOUCH_FALSE;

        Vector3 vec3TouchPosition;

        vec3TouchPosition = Input.mousePosition;

        if (Input.GetMouseButtonDown(0)) OnTouchEnter(vec3TouchPosition);
        if (Input.GetMouseButton(0)) OnTouchStay();
        if (Input.GetMouseButtonUp(0)) OnTouchExit(vec3TouchPosition);
    }

    /*===================================================
     * Purpose  : 右側ボタンを押した時の処理
     * Argument : なし
     * Return   : なし
     ===================================================*/
    public void ButtonPushRight()
    {
        base.inputState = InputState.TOUCH_RIGHT;
    }

    /*===================================================
     * Purpose  : 左側ボタンを押した時の処理
     * Argument : なし
     * Return   : なし
     ===================================================*/
    public void ButtonPushLeft()
    {
        base.inputState = InputState.TOUCH_LEFT;
    }

    /*===================================================
     * Purpose  : 上側ボタンを押した時の処理
     * Argument : なし
     * Return   : なし
     ===================================================*/
    public void ButtonPushTop()
    {
        base.inputState = InputState.TOUCH_TOP;
    }

    /*===================================================
     * Purpose  : 下側ボタンを押した時の処理
     * Argument : なし
     * Return   : なし
     ===================================================*/
    public void ButtonPushBottom()
    {
        base.inputState = InputState.TOUCH_BOTTOM;
    }
}