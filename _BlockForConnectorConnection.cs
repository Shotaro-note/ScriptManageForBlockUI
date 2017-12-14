using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blocks;

    /// <summary>
    /// BlockとConnectorを接続可能にすためのOverride関数用Class
    /// </summary>
    public class BlockForConnectorConnection : BlockBase
    {
    
        public override void AutoConnect()
        {
            base.AutoConnect();
            if (connectableObject != null && connectablePivot != null && connectableObject.tag == "Connector")
            {
                GameObject pivot_o=connectableObject.GetComponent<BlockBase>().connectablePivot;
                GameObject target = pivot_o.transform.parent.transform.GetChild(1).gameObject;
                this.gameObject.AddComponent<JointToConnector>().Joint(connectablePivot, connectableObject,target.transform);
                Destroy(this.gameObject.GetComponent<JointToConnector>());
            }
        }
    }

