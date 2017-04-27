using UnityEngine;
using System.Collections;

public class Button_GameStart : MonoBehaviour{

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
