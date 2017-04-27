using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveImage : MonoBehaviour {

    public float m_MoveSpeed;
    float m_Move, m_Timer;
    bool m_MoveUpDown;
    Transform m_buttonPos;

	// Use this for initialization
	void Start () {
        m_buttonPos = this.GetComponent<RawImage>().transform;
	}
	
	// Update is called once per frame
	void Update () {
        //Move();
	}

    /*
    void Move()
    {
        if (m_Move >= 5)
            m_MoveUpDown = false;
        else if (m_Move <= 0)
            m_MoveUpDown = true;

        if (m_MoveUpDown)
        {
            m_buttonPos.position += new Vector3(0, m_MoveSpeed, 0);
            m_Move += m_MoveSpeed;
        }
        else if (!m_MoveUpDown )
        {
            m_buttonPos.position -= new Vector3(0, m_MoveSpeed, 0);
            m_Move -= m_MoveSpeed;
        }    
    }
     */
}
