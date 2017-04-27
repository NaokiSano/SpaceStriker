using UnityEngine;
using System.Collections;

public class EndShutter : MonoBehaviour {

    public GameObject Manager;
    CustomizeManager managerScript;
    public GameObject ShutterUp, ShutterDown;
    public float DefaultUp, EndUp;
    public float DefaultDown, EndDown;
    bool endActive, next;

	// Use this for initialization
	void Start () {
        managerScript = Manager.GetComponent<CustomizeManager>();
        endActive = false;
        next = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (endActive && ShutterUp.transform.position.y > EndUp)
        {
            managerScript.SetActive(CustomizeField.STATUS_SLIDER_OFF);
            ShutterUp.transform.position += new Vector3(0, -0.6f, 0);
        }
        if (endActive && ShutterDown.transform.position.y < EndDown)
        {
            ShutterDown.transform.position += new Vector3(0, 0.4f, 0);
        }

        if(ShutterDown.transform.position.y >= EndDown)
        {
            Application.LoadLevel("Battle");
        }
	}

    /// <summary>
    ///  Trueをセットで、エンドシャッター後次シーンへ
    /// </summary>
    /// <param name="active">bool</param>
    public void SetActive( bool active)
    {
        endActive = active;
    }
}
