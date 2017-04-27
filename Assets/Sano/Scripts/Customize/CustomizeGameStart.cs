using UnityEngine;
using System.Collections;

public class CustomizeGameStart : MonoBehaviour {

    public GameObject Manager;
    CustomizeManager managerScript;

	// Use this for initialization
	void Start () {
        managerScript = Manager.GetComponent<CustomizeManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void OnClick()
    {
        if (gameObject.name == "Start")
        {
            managerScript.SetActive(CustomizeField.CASEIMAGE);
            managerScript.SetActive(CustomizeField.END_SHUTTER);
            //managerScript.SetActive(CustomizeField.CUSTOMIZE_ON);
            managerScript.SetActive(CustomizeField.STARTBUTTON);
        }
    }
}
