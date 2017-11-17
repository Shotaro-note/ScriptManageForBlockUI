using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointToConnector : JointObjects {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void Joint(GameObject pivot_a, GameObject block_b,Transform target)
    {
        base.Joint(pivot_a, block_b,target);
        if (block_b.tag == "Connector")
        {
            Debug.Log("JointのOverride呼び出されました～～");
        }
    }
}
