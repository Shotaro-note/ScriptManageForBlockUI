using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blocks;


public class PivotColliderForConnector : PivotCollider {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        if (other.gameObject.tag == "Connector")
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
    public override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);
        if (other.gameObject.tag == "Connector")
        {
            parent.GetComponent<BlockBase>().connectableObject = other.gameObject;
            parent.GetComponent<BlockBase>().IsConnectable = true;
            parent.GetComponent<BlockBase>().connectablePivot = this.gameObject;
            ConnectedObject = other.gameObject;
        }
    }
}
