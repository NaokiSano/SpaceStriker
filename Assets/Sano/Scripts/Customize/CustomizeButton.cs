using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CustomizeButton : MonoBehaviour{

    public GameObject customizeManager;
    CustomizeManager managetScript;
    
    bool m_IsWall;

    void Start()
    {
        managetScript = customizeManager.GetComponent<CustomizeManager>();
    }

    /// <summary>
    ///  このボタンがクリックされたら、
    ///  邪魔になるボタン類を非アクティブ化して壁を有効化
    /// </summary>
    public void OnClick()
    {
        if (gameObject.name == "GoCustomize")
        {
            managetScript.SetActive(CustomizeField.CUSTOMIZE_ON);
        }
    }

    public void SetActiveButton(bool active)
    {
        m_IsWall = active;
    }
}
