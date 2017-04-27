using UnityEngine;
using System;
using System.Collections;

public class ScreenFadeManager : MonoBehaviour {

	// シングルトン宣言 ------------------------------------
	private static ScreenFadeManager mInstance;

	// コンストラクタ
	private ScreenFadeManager() {
		//Debug.Log("Create Singleton Instance.");
	}

	// インスタンスを生成する
	public static ScreenFadeManager Instance {
		get {
			if (mInstance == null) {
				GameObject gObj = new GameObject("ScreenFadeManager");
				mInstance = gObj.AddComponent<ScreenFadeManager>();
			}
			return mInstance;
		}
	}
	// --------------------------------------------------

	// public
	public bool isFadeAction = false;	// フェード中かどうか

	// private
	// フェード用変数
	private Texture2D texture;
	private String sequence = null;
	private Color from;
	private Color to;
	private Color now; 
	private float time;

	// delegate
	public delegate void OnComplete(); 	// delegate
	private OnComplete callBack;		// コールバック


	void Awake() {
		texture = new Texture2D( 1, 1, TextureFormat.ARGB32, false );
		texture.SetPixel(0,0, Color.white );
		texture.Apply();
	}

	void OnGUI () {
		if( now.a != 0 ){
			GUI.color = now;
			GUI.DrawTexture(new Rect( 0, 0, Screen.width, Screen.height ), texture );
		}
	}

	// 共通処理
	void StartSequence ( String function_name ) {
		if( sequence == null ){
			StopCoroutine( sequence );
			sequence = null;
		}
		sequence = function_name;
		StartCoroutine( sequence );
	}

	// フェード処理
	IEnumerator FadeUpdate () {
		float now_time = 0;
		while( 0 < time && now_time < time ){ 
			now_time += Time.deltaTime;
			now = Color.Lerp( from, to, now_time / time );
			yield return 0;
		}
		now = to;
		isFadeAction = false;

		// コールバック
		callBack();
	}

    /// <summary>
    /// フェードインを開始する
    /// </summary>
    /// <param name="t_time">フェードインにかかる時間</param>
    /// <param name="t_color">初期の色</param>
    /// <param name="t_cb">"() =>{ フェードイン完了後の処理  }"</param>
	public void FadeIn( float t_time, Color t_color, OnComplete t_cb ) {
		callBack = t_cb;
		to = from = t_color;
		to.a = 0;
		time = t_time;
		StartSequence( "FadeUpdate" );
	}

    /// <summary>
    /// フェードアウトを開始する
    /// </summary>
    /// <param name="t_time">フェードアウトにかかる時間</param>
    /// <param name="t_color">上書きする色</param>
    /// <param name="t_cb">"() =>{ フェードアウト完了後の処理  }"</param>
	public void FadeOut( float t_time, Color t_color, OnComplete t_cb ) {
		callBack = t_cb;
		to = from = t_color;
		from.a = 0;
		time = t_time;
		StartSequence( "FadeUpdate" );
	}
}
