using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_TimeDraw : MonoBehaviour {

    public GameObject m_TimerObj;
    float m_CountTime;
    Text text;

	// Use this for initialization
	void Start () {
        text = this.GetComponent<Text>();
        
	}
	
	// Update is called once per frame
	void Update () {
        m_CountTime = m_TimerObj.GetComponent<Timer>().GetTime();
        text.text = m_CountTime.ToString("f2");     // f2は、小数第2位までを表示
    }

    public float GetTime()
    {
        return m_CountTime;
    }
}
