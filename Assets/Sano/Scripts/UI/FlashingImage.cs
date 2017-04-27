using UnityEngine;
using System.Collections;

/***************
   画像の点滅 
 ***************/

public class FlashingImage : MonoBehaviour {
    [Range(0, 1)]
    public float fadeSpeed;      // フェード速度
    private bool fadeSwitch;// フェードアウト切替

    private SpriteRenderer spRenderer;

    void Awake()
    {
        spRenderer = this.GetComponent<SpriteRenderer>();
    }

	// Use this for initialization
	void Start () {
        fadeSpeed /= 10;
	}
	
	// Update is called once per frame
	void Update () {
        Fade();
	}

    void Fade()
    {
        Color color = spRenderer.color;
        if(color.a >= 1)
        {
            fadeSwitch = false;    
        }
        else if (color.a <= 0)
        {
            fadeSwitch = true;
        }       

        if(fadeSwitch)
        {
            color.a += fadeSpeed;
        }
        else
        {
            color.a -= fadeSpeed;
        }
        spRenderer.color = color;
    }
}
