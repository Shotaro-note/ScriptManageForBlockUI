using Blocks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotCollider : MonoBehaviour {
    [SerializeField]
    private GameObject parent;
    private GameObject DetectConnectable;

	// Use this for initialization
	void Start () {
        parent.GetComponent<BlockBase>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "MovableBlock")
        {
            parent.GetComponent<BlockBase>().connectableObject = other.gameObject;
            parent.GetComponent<BlockBase>().IsConnectable = true;
            parent.GetComponent<BlockBase>().connectablePivot = this.gameObject;
            DetectConnectable = other.gameObject;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MovableBlock")
        {
            if (other.gameObject == DetectConnectable)
            {
                if (parent.GetComponent<BlockBase>().connectablePivot == this.gameObject)
                {
                    parent.GetComponent<BlockBase>().connectableObject = null;
                    parent.GetComponent<BlockBase>().IsConnectable = false;
                    DetectConnectable = null;
                }
            }
        }
    }
}
