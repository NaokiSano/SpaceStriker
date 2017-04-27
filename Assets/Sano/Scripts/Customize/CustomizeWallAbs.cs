using UnityEngine;
using System.Collections;

public abstract class CustomizeWallAbs : MonoBehaviour {

    public GameObject customizeManager;
    protected CustomizeManager managetScript;
    protected bool activeWall, returnWall;
    protected float maxMove, defaultMove;

	// Use this for initialization
	void Start () {
        managetScript = customizeManager.GetComponent<CustomizeManager>();
        Init();
	}

	// Update is called once per frame
	void Update () {
        Move();
	}

    protected abstract void Init();
    protected abstract void Move();
    public abstract void SetActiveWall(bool active);
}
