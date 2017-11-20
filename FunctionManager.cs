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
        
	}
	
	// Update is called once per frame
	public virtual void Update () {
		
	}

    public void CheckFunction(GameObject go, Transform tr, float value)
    {
        if (function != functionList.None)
        {
            go0 = go;
            tr0 = tr;
            value0 = value;
            this.gameObject.AddComponent(Type.GetType("F" + function.ToString()));
            
        }
    }

    public virtual void ExecuteFunction(GameObject go, Transform tr, float value) {
        Debug.Log("Manager_function");

    }

    public enum functionList
    {
        None,
        Move
        
    }
}
