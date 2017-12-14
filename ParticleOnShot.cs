using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnShot : MonoBehaviour {
    private ParticleSystem particle;
    [SerializeField]
    private GameObject particleObject;
	// Use this for initialization
	void Start () {
        if (particleObject != null) {
            particle = particleObject.transform.GetChild(0).GetComponent<ParticleSystem>();
                }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
