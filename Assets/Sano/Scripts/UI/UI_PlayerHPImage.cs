using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_PlayerHPImage : MonoBehaviour
{

    Image m_CircleGauge;
    float m_CurrentPlayerHP;
    float m_MaxCurrentPlayerHP;

    // Use this for initialization
    void Start()
    {
        m_CircleGauge = GetComponent<Image>();
        m_CurrentPlayerHP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        m_CircleGauge.fillAmount = m_CurrentPlayerHP / 4f;
        if (Input.GetKeyDown(KeyCode.A))
            SetPlayerHP(80);
    }

    /// <summary>
    ///  プレイヤーHPをセット
    /// </summary>
    /// <param name="playerHP">プレイヤーHP</param>
    public void SetPlayerHP(float playerHP)
    {
        m_CurrentPlayerHP = playerHP / m_MaxCurrentPlayerHP;
    }

    public void SetMaxPlayerHP(float playerHp)
    {
        m_MaxCurrentPlayerHP = playerHp;
    }
}
