using UnityEngine;
using System.Collections;

public class SoundManager : SingletonMonoBehaviour<SoundManager> {

    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void Start()
    {

    }

    public void Update()
    {

    }
}
