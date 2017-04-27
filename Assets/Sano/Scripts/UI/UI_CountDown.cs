using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_CountDown : MonoBehaviour {

    public int m_MaxCount;
    float m_NowCount, m_NowTime, m_OldTime;
    bool m_IsStart, m_IsDefault;
    
	// Use this for initialization
	void Start () {
        m_IsStart = false;
        m_IsDefault = false;
	}
	
	// Update is called once per frame
    void Update()
    {
        CountDown();

        StartBattle();
    }

    /// <summary>
    ///  カウントダウン
    /// </summary>
    void CountDown()
    {
        m_NowCount += 1 * Time.deltaTime;
        m_NowTime = m_MaxCount - m_NowCount;

        if((int)m_OldTime != (int)m_NowTime && (int)m_NowTime != 0)
        {
            AudioManager.Instance.PlaySE(AudioName.SEName[1], 0);
        }

        m_OldTime = (int)m_NowTime;

        if(m_NowTime <= 1)
        {
            m_IsStart = true;
        }
    }

    /// <summary>
    ///  カウント0で削除
    /// </summary>
    void StartBattle()
    {
        if (m_IsStart)
            Destroy(this.gameObject);
    }

    /// <summary>
    ///  スタートフラグを返す
    /// </summary>
    /// <returns>m_IsStart</returns>
    public bool IsStart()
    {
        return m_IsStart;
    }

    /// <summary>
    ///  今の時間を返す
    /// </summary>
    /// <returns>float</returns>
    public float GetNowTime()
    {
        return m_OldTime;
    }
}
