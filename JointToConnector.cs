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
        block_b.GetComponent<ConnectorBase>().ConnectedBlocks.Add(pivot_a.transform.parent.transform.parent.gameObject);            
        
    }
}
