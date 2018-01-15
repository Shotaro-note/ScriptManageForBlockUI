using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRaiser : MonoBehaviour {

    public GameObject ParticleObjects;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// パーティクルを発生させて3秒後に消去する関数
    /// </summary>
    public void RaiseParticle()
    {
        if (ParticleObjects == null) return;
        GameObject particle = Instantiate(ParticleObjects, this.transform.position, this.transform.rotation) as GameObject;
        Destroy(particle, 3f);
        return;
    }

    public void RaiseParticle(Transform target)
    {
        if (ParticleObjects == null) return;
        GameObject particle = Instantiate(ParticleObjects, target.position, target.rotation) as GameObject;
        Destroy(particle, 3f);
        return;
    }
}
