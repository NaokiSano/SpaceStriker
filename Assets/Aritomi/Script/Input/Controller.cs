/// コントローラクラス
/// Yuho Aritomi
/// Controller.cs v1.0
/// v1.0
/// InputStateを返す
/// InputStateの更新は継承クラスに任せる
using UnityEngine;
using System.Collections;



public abstract class Controller : MonoBehaviour
{
    protected InputState inputState;    //入力情報

    /// <summary>
    /// 初期化
    /// </summary>
    protected virtual void Initialize()
    {
        inputState = InputState.TOUCH_FALSE;
    }

    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        Initialize();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    void Awake()
    {
        Initialize();
    }

    /// <summary>
    /// InputStateの更新
    /// </summary>
    protected abstract void InputStateUpdate();

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        InputStateUpdate();
    }

    /// <summary>
    /// 入力情報を返す
    /// </summary>
    /// <returns></returns>
    public InputState GetInputState()
    {
        return inputState;
    }
}
