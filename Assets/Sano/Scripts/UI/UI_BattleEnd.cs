using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_BattleEnd : MonoBehaviour
{

    public GameObject m_Timer;
    bool m_IsEnd;
    float m_Time;
    public float m_NextTime;
    Text text;


    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        text.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        m_IsEnd = m_Timer.GetComponent<Timer>().GetIsEnd();

        if (m_IsEnd)
        {
            //            text.text = "FINISH！";
            //            Count();
        }
        //        else
        //            text.text = null;
    }

    public void Count(bool isVictory)
    {
        if (isVictory == true)
            text.text = "You Win!";
        else
            text.text = "You Lose...";
        m_Time += 1 * Time.deltaTime;
        if (m_Time >= m_NextTime)
        {
            LoadScene();
        }
    }
    void LoadScene()
    {
        Application.LoadLevel("StageSelect");
        //Application.LoadLevel("title");
    }
}
