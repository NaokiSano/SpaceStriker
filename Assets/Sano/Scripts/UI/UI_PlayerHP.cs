using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_PlayerHP : MonoBehaviour {

    public float m_StartHealth;         // HP最大値
    public Slider m_Slider;
    public Color m_FullHealth = Color.green;
    public Color m_ZeroHealth = Color.red;
    public Image m_FillImage; 

    private float m_CurrentHealth;      // HPの現在値
    private bool m_Dead;           

	// Use this for initialization
	void Start () {
        m_CurrentHealth = m_StartHealth;
        m_Dead = false;
        SetHealthUI();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    ///  HP現在値をスライダーに反映
    /// </summary>
    void SetHealthUI()
    {   
        m_Slider.value = m_CurrentHealth;

        m_FillImage.color = Color.Lerp(m_ZeroHealth, m_FullHealth, m_CurrentHealth / m_StartHealth);
    }

    /// <summary>
    ///  プレイヤーHPをセットする
    /// </summary>
    /// <param name="currentHealth">プレイヤーHP</param>
    void SetPlayerHP(float currentHealth)
    {
        m_CurrentHealth = currentHealth;
        SetHealthUI();
    }
}
