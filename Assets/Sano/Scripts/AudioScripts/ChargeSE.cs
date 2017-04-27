using UnityEngine;
using System.Collections;

public class ChargeSE : MonoBehaviour {

    public AudioClip chargeSE;
    private AudioSource chargeAudio;

	// Use this for initialization
	void Start () {
        //chargeAudio = this.GetComponent<AudioSource>();
        //Resources.Load("Sano/Resources");
        //foreach (var i in chargeSE)
        //{
        //    chargeAudio.PlayOneShot(i);
        //}
	}

    void OnEnable()
    {
        chargeAudio = this.GetComponent<AudioSource>();
        //Resources.Load("Sano/Resources");
        chargeAudio.PlayOneShot(chargeSE);
    }
	
	// Update is called once per frame
	void Update () {
	       
    }
}
