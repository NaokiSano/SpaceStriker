using UnityEngine;
using System.Collections;

public class Fadeout : MonoBehaviour {

    public float fadeOutSpeed;
    public Color fadeColor;
    ScreenFadeManager fadeManager;
    [HideInInspector]
    private bool start;

	// Use this for initialization
	void Start () {
        fadeManager = ScreenFadeManager.Instance;
        start = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(start)
            FadeOut();
	}

    void FadeOut()
    {
        fadeManager.FadeOut(fadeOutSpeed, fadeColor, () =>
        {   // フェードアウト後に行う処理
            SceneLoad();
        });
    }

    /// <summary>
    ///  Trueでフェードアウトさせる
    /// </summary>
    public bool GetSetStartFlag
    {
        get { return start; }
        set { start = value; }
    }

    /// <summary>
    ///  ボタンに対応するシーンをロード
    /// </summary>
    void SceneLoad()
    {
        string name = this.GetComponent<MenuButton>().GetMenuName();
        if (name == "GameStart")
            Application.LoadLevel("StageSelect");
        else if (name == "Tutorial")
            Application.LoadLevel("Tutorial");
        else if (name == "Credit")
            Application.LoadLevel("Credit");
    }
}
