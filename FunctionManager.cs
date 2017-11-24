using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FunctionManager : MonoBehaviour {
    public functionList function=functionList.None;
    public GameObject go0;
    public Transform tr0;
    public float value0;
	// Use this for initialization
	void Start () {
        //FunctionManagerのデバック用
       
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(.01f, .01f, .01f);
        cube.transform.position = Vector3.one;
        cube.transform.rotation = Quaternion.EulerAngles(30, 45, 90);
    }

    // Update is called once per frame
    public virtual void Update () {
		
	}

    public void CheckFunction(GameObject go)
    {
        if (go.GetComponent<FunctionalBlock>().function != functionList.None)
        {
            function = go.GetComponent<FunctionalBlock>().function;         
            go.AddComponent(Type.GetType("F" + function.ToString()));           
        }

    }

    public virtual void ExecuteFunction(GameObject go) {
        if (go.GetComponent<FunctionalBlock>().function != functionList.None)
        {
            function = go.GetComponent<FunctionalBlock>().function;

        }

    }
    public enum functionList
    {
        None,
        Move,
        Analyze,
        CastleConstruct    
    }
}
