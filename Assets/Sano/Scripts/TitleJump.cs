using UnityEngine;
using System.Collections;

public class TitleJump : MonoBehaviour {

    public float fadeOutSpeed;
    public Color fadeColor;
    public float zoomSpeed;
    public GameObject ship;
    ScreenFadeManager fadeManager;
    bool fadeZoomF;

	// Use this for initialization
	void Start () {
        fadeManager = ScreenFadeManager.Instance;
        fadeZoomF = false;
        AudioManager.Instance.PlayBGM(AudioName.BGMName[0]);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			if(Physics.Raycast(ray,out  hit))
			{
                if (hit.collider.tag == "Titlebottn")
                {
                    AudioManager.Instance.PlaySE(AudioName.SEName[1], 0);
                    fadeZoomF = true;
                    FadeOut();
                }
			}
		}

        if(fadeZoomF)
        {
            CameraZoonIn();
        }

	}

    void FadeOut()
    {
        fadeManager.FadeOut(fadeOutSpeed, fadeColor, () =>
        {   // フェードアウト後に行う処理         
            Application.LoadLevel("Menu");
        });
    }

    /// <summary>
    ///  TapStartを押したら機体にズームしていく
    /// </summary>
    void CameraZoonIn()
    {
        float step = zoomSpeed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(transform.position, ship.transform.position, step);
    }
}
