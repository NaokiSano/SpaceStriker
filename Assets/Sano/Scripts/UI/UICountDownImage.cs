using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UICountDownImage : MonoBehaviour {

    public GameObject ui_CountDown;
    public Sprite[] ui_Sprite;
    Image ui_Image;
    UI_CountDown ui_CountDownTime;
    Vector3 ui_DefaultScale;
    bool m_IsDefault;

	// Use this for initialization
	void Start () {
        ui_Image = GetComponent<Image>();
        ui_CountDownTime = ui_CountDown.GetComponent<UI_CountDown>();
        ui_DefaultScale = transform.localScale;
        m_IsDefault = false;
        ui_Image.sprite = ui_Sprite[0];
	}
	
	// Update is called once per frame
	void Update () {
        int time = (int)ui_CountDownTime.GetNowTime();

        switch(time)
        {
            case 3:
                ui_Image.sprite = ui_Sprite[0];
                gameObject.transform.localScale -= new Vector3(0.01f, 0.01f);
                break;
            case 2:
                if (!m_IsDefault)
                {
                    transform.localScale = ui_DefaultScale;
                    m_IsDefault = true;
                }
                gameObject.transform.localScale -= new Vector3(0.01f, 0.01f);
                ui_Image.sprite = ui_Sprite[1];
                break;
            case 1:
                if (m_IsDefault)
                {
                    transform.localScale = ui_DefaultScale;
                    m_IsDefault = false;
                }
                gameObject.transform.localScale -= new Vector3(0.01f, 0.01f);
                ui_Image.sprite = ui_Sprite[2];
                break;
        }
	}
}
