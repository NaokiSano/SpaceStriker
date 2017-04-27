using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuButton : MonoBehaviour {

    public GameObject m_target;
    public GameObject m_menuBullet;
    public GameObject m_TargetMaker;
    public Transform m_spawnPos;
    //public float m_MoveSpeed;
    //Transform m_buttonPos;

    bool m_MenuOK, m_MoveUpDown, m_MoveStart;

	// Use this for initialization
	void Start () {
        m_MoveStart = false;
        m_MenuOK = true;
        //m_buttonPos = this.GetComponent<Image>().transform;
	}

	// Update is called once per frame
    void Update()
    {
        //MoveStart();
        //MoveButton();
	}

    /// <summary>
    ///  どれかのボタンが押されたら、
    ///  そのボタンに弾が発射される
    /// </summary>
    public void ButtonPush()
    {      
        if (m_MenuOK)
        {
            AudioManager.Instance.PlaySE("Accept", 0);
            Vector3 m_targetMarkPos;
            m_targetMarkPos = this.transform.position;
            m_targetMarkPos.z -= 3;
            m_menuBullet.GetComponent<MenuBullet>().target = m_target;
            Instantiate(m_menuBullet, m_spawnPos.transform.position, m_spawnPos.transform.rotation);
            GameObject kodomo = Instantiate(m_TargetMaker, m_targetMarkPos, this.transform.rotation) as GameObject;
            kodomo.transform.parent = GameObject.Find("Camera").transform;
            m_MenuOK = false;
        }
    }

    /// <summary>
    ///   ターゲットに設定されているボタン名を返す
    /// </summary>
    /// <returns>ボタンオブジェクト名</returns>
    public string GetMenuName()
    {
        return m_target.name;
    }
    /*
    void MoveStart()
    {
        if(m_Timer <= 2)
            m_Timer += 1 * Time.deltaTime;

        string name = GetMenuName();
        if(name == "GameStart" && m_Timer >= 0)
        {
            m_MoveStart = true;    
        }
        else if(name == "Credit" && m_Timer >= 0.5f)
        {
            m_MoveStart = true; 
        }
    }
    */
    /*
    /// <summary>
    ///  ボタン浮遊
    /// </summary>
    void MoveButton()
    {
        if (m_Move >= 5)
            m_MoveUpDown = false;
        else if (m_Move <= 0)
            m_MoveUpDown = true;

        if(m_MoveUpDown && m_MoveStart)
        {
            m_buttonPos.position += new Vector3(0, m_MoveSpeed, 0);
            m_Move += m_MoveSpeed;
        }
        else if(!m_MoveUpDown && m_MoveStart)
        {
            m_buttonPos.position -= new Vector3(0, m_MoveSpeed, 0);
            m_Move -= m_MoveSpeed;
        }     
    }
    */

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "MenuBullet")
            this.GetComponent<Fadeout>().GetSetStartFlag = true;
    }
}
