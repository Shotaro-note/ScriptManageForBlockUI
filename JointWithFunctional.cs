using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointWithFunctional : JointObjects {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void Joint(GameObject pivot_a, GameObject block_b, Transform target)
    {
        base.Joint(pivot_a, block_b, target);
        GameObject block = pivot_a.transform.parent.transform.parent.gameObject;

        ///FunctionManagerのデバック用
        ///
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(.01f, .01f, .01f);
        cube.transform.position = Vector3.one;
        cube.transform.rotation = Quaternion.EulerAngles(30, 45, 90);
        block.GetComponent<FunctionManager>().CheckFunction(block.transform.parent.gameObject, cube.transform, 10f);
    }
}
