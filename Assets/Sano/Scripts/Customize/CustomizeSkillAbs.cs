using UnityEngine;
using System.Collections;

public abstract class CustomizeSkillAbs : MonoBehaviour {

    public GameObject ShipModel;
    public GameObject customizeManager;
    protected CustomizeManager managetScript;
    protected bool activeButton;

    // Use this for initialization
    void Start()
    {
        managetScript = customizeManager.GetComponent<CustomizeManager>();
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Updates();
    }

    protected abstract void Init();
    protected abstract void Updates();
    public abstract void SetActive(bool active);
}
