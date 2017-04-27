using UnityEngine;
using System.Collections;

public class EffectDestroy : MonoBehaviour {

    public GameObject thisEffect;
    public ParticleSystem thisParticle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!thisParticle.isPlaying)
        {
            Destroy(thisEffect);
        }
	}
}
