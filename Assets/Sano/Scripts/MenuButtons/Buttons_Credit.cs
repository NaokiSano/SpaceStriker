using UnityEngine;
using System.Collections;

public class Buttons_Credit : MonoBehaviour {

    public GameObject target;
    public GameObject menuBullet;
    public Transform spawnPos;
    public int nextTime;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonPush()
    {
        menuBullet.GetComponent<MenuBullet>().target = target;
        Instantiate(menuBullet, spawnPos.transform.position, spawnPos.transform.rotation);
    }
}
