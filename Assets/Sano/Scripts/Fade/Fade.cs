using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

    public float fadeInSpeed;
    public Color fadeColor;
    ScreenFadeManager fadeManager;

	// Use this for initialization
	void Start () {
        fadeManager = ScreenFadeManager.Instance;
	}
	
	// Update is called once per frame
	void Update () {
        FadeIn();
	}

    void FadeIn()
    {
        fadeManager.FadeIn(fadeInSpeed, fadeColor, () =>
        {    // フェードイン後に行う処理
           
        });
    }
}
