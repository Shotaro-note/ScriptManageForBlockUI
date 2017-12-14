using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointWithFunctional : JointObjects {
    GameObject fManager;//functionManager,gameObject
    FunctionManager functionManager;//FunctionManager,script
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// pivot_aが自分、block_bが接続先、Aのほうがfunction持っている側
    /// </summary>
    /// <param name="pivot_a"></param>
    /// <param name="block_b"></param>
    /// <param name="target"></param>
    public override void Joint(GameObject pivot_a, GameObject block_b, Transform target)
    {
        base.Joint(pivot_a, block_b, target);
        GameObject block = pivot_a.transform.parent.transform.parent.gameObject;

        
        fManager = GameObject.Find("FunctionManager");
        functionManager = fManager.GetComponent<FunctionManager>();
        functionManager.CheckFunction(block);
        
        //block.GetComponent<FunctionManager>().CheckFunction(block.transform.parent.gameObject, cube.transform, 10f);
    }
}
