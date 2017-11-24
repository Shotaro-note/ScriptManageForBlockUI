using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blocks;

public class PivorColliderForConnector : PivotCollider {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);
        
        if (other.gameObject.tag=="MovableBlock"&&other.gameObject.GetComponent<BlockBase>().connectableObject == this.gameObject)
        {
            if (other.transform.parent != null)
            {
                foreach (GameObject block in this.GetComponent<ConnectorBase>().ConnectedBlocks)
                 {

                    if (other.transform.parent == block.transform.parent)
                    {
                        other.gameObject.AddComponent<JointObjects>().Joint(other.gameObject.GetComponent<BlockBase>().connectablePivot, parent, this.transform.parent.GetChild(1).transform);
                        Destroy(other.gameObject.GetComponent<JointObjects>());
                    }
                }
            }
        }
    }
    public override void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MovableBlock")
        {
            if (parent.GetComponent<BlockBase>().connectablePivot == this.gameObject) parent.GetComponent<BlockBase>().ResetConnectable();
          
            for (int i = parent.GetComponent<ConnectorBase>().ConnectedBlocks.Count-1; i >= 0; i--)
            {
                Debug.Log("Removed");
                if (other.gameObject == parent.GetComponent<ConnectorBase>().ConnectedBlocks[i])
                {
                    parent.GetComponent<ConnectorBase>().ConnectedBlocks.RemoveAt(i);
                    parent.AddComponent<RemoveJoint>().SimpleRemove(other.gameObject);
                    Destroy(parent.GetComponent<RemoveJoint>());
                    parent.GetComponent<ConnectorBase>().ConnectedBlocks.RemoveAt(i);
                }
            }                      
        }
    }
}
