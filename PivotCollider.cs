using Blocks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotCollider : MonoBehaviour {
    [SerializeField]
    private GameObject parent;
    private GameObject ConnectedObject;
    

    public GameObject connectedObject
    {
        get
        {
            return ConnectedObject;
        }
    }

    public void SetValid() {
        this.GetComponent<BoxCollider>().enabled = true;
    }
    public void SetInvalid() {
        this.GetComponent<BoxCollider>().enabled = false;
    }
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
            ConnectedObject = other.gameObject;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MovableBlock")
        {
            if (other.gameObject == ConnectedObject)
            {
                if (parent.GetComponent<BlockBase>().connectablePivot == this.gameObject)
                {
                    parent.GetComponent<BlockBase>().connectableObject = null;
                    parent.GetComponent<BlockBase>().IsConnectable = false;
                    parent.GetComponent<BlockBase>().connectablePivot = null;
                    ConnectedObject = null;
                }
            }
        }
    }
}
