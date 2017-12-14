using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blocks;

public class BlockAirplane : BlockBase {

    public override void AutoConnect()
    {
        
        #region Airplaneブロック専用
        if (this.GetComponent<BlockBase>().type == BlockType.Airplane)
        {
            if (connectableObject != null && connectablePivot != null && connectableObject.tag == "MovableBlock" && connectableObject.GetComponent<BlockBase>().type == BlockType.Airplane)
            {

                this.gameObject.AddComponent<JointObjects>().Joint(connectablePivot, connectableObject, connectableObject.transform);
                Destroy(this.gameObject.GetComponent<JointObjects>());
            }
           
        }
        #endregion
        
    }

}
