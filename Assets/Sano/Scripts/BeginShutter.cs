using UnityEngine;
using System.Collections;

public class BeginShutter : MonoBehaviour {

    public GameObject ShutterUp, ShutterDown;
    public float EndUp, EndDown;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (ShutterUp.transform.localPosition.y < EndUp)
        {
            ShutterUp.transform.localPosition+= new Vector3(0, 15.0f, 0);
        }
        if (ShutterDown.transform.localPosition.y > EndDown)
        {
            ShutterDown.transform.localPosition += new Vector3(0, -8.0f, 0);
        }
	}
}
