using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blocks;

public class ConnectorBase : MonoBehaviour {
    public List<GameObject> ConnectedBlocks = new List<GameObject>();

    // Use this for initialization
    public virtual void Start () {
		
	}
	
	// Update is called once per frame
	public virtual void Update () {
		
	}

    public virtual void CheckConnectable()
    {
        GameObject connectableObject = this.GetComponent<BlockBase>().connectableObject;
        GameObject connectablePivt = this.GetComponent<BlockBase>().connectablePivot;
        bool isConnectable = this.GetComponent<BlockBase>().IsConnectable;
        
    }
}
