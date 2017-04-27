using UnityEngine;
using System.Collections;

public class CustomizeShutter : MonoBehaviour {

    public GameObject customizeManager;
    CustomizeManager managetScript;
    bool activeWall, returnWall;
    public float maxMove, defaultMove;

	// Use this for initialization
	void Start () {
        managetScript = customizeManager.GetComponent<CustomizeManager>();
        activeWall = false;
        returnWall = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (activeWall && transform.position.y >= maxMove)
        {
            transform.position += new Vector3(0, -0.9f, 0);
        }
        else if (!activeWall && transform.position.y <= defaultMove)
        {
            transform.position += new Vector3(0, 0.9f, 0);
        }

        if (!activeWall&& transform.position.y >= defaultMove)
        {
            managetScript.SetActive(CustomizeField.GO_CUSTOMIZE);
            managetScript.SetActive(CustomizeField.CASEIMAGE);
            managetScript.SetActive(CustomizeField.STARTBUTTON);
            managetScript.SetActive(CustomizeField.STATUS_SLIDER);
        }
	}

    public void SetActiveShutter(bool active)
    {
        activeWall = active;
    }
}
