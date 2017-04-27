using UnityEngine;
using System.Collections;

public class DrawNumSprite : MonoBehaviour {

    NumSprite numSprite;

	// Use this for initialization
	void Start () {
        numSprite = GameObject.Find("NumSprite").GetComponent<NumSprite>();
        numSprite.Value = 3;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
