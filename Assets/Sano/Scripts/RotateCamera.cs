using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour {

    public float rotateSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        string name = Application.loadedLevelName;
        if(name == "Menu")
        {
            this.transform.Rotate(rotateSpeed, 0, 0);
        }
        else
            this.transform.Rotate(0, rotateSpeed, 0);
	}
}
