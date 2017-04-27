using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_EnemyHP : MonoBehaviour
{

    float m_EnemyHp;
    float m_maxEnemyHP;
    Image m_Image;

    // Use this for initialization
    void Start()
    {
        m_Image = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Image.fillAmount = m_EnemyHp;

    }

    /// <summary>
    ///  敵のHPをセットする
    /// </summary>
    /// <param name="enemyHP">敵のHP</param>
    public void SetEnemyHP(float enemyHP)
    {
        m_EnemyHp = enemyHP / m_maxEnemyHP;
    }

    public void SetMaxEnemyHP(float enemyHP)
    {
        m_maxEnemyHP = enemyHP;
    }
}
