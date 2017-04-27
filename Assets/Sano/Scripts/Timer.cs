using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
 
    public int m_limitTime;
    float m_nowTime;
    bool m_pause, m_end;

	// Use this for initialization
	void Start () {
        m_nowTime = m_limitTime;
        m_end = false;
        m_pause = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!m_pause && !m_end)
        {
            m_nowTime -= 1.0f * Time.deltaTime;

            if (m_nowTime <= 0)
                m_end = true;
        }
        else if (m_end)
            m_nowTime = 0;
	}



    /// <summary>
    ///  今のタイムを返すだけ
    /// </summary>
    /// <returns>float</returns>
    public float GetTime()
    {
        return m_nowTime;
    }

    /// <summary>
    ///  タイムリミットをむかえたか
    /// </summary>
    /// <returns>bool</returns>
    public bool GetIsEnd()
    {
        return m_end;
    }

    public void SetPause(bool Flag)
    {
        m_pause = Flag;
    }
}
