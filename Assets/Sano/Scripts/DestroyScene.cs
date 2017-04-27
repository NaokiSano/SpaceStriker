using UnityEngine;
using System.Collections;

public class DestroyScene : MonoBehaviour {

    GameObject countDown;
	// Use this for initialization
	void Start () {
        countDown = GameObject.Find("CountDown");   
	}
	
	// Update is called once per frame
	void Update () {
	    if(countDown==null)
        {
            Destroy(this.gameObject);
        }
	}
}
