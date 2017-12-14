using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blocks;

    /// <summary>
    /// Blockと"BlockType.Normal"以外のBlockTypeを持つブロックを接続可能にすためのOverride関数用Class
    /// </summary>
    public class BlockAdvance : BlockBase
    {
    
        public override void AutoConnect()
        {
        #region 接続先がConnector
        if (connectableObject != null && connectablePivot != null && connectableObject.tag == "Connector")
        {
            GameObject pivot_o = connectableObject.GetComponent<BlockBase>().connectablePivot;
            GameObject target = pivot_o.transform.parent.transform.GetChild(1).gameObject;
            this.gameObject.AddComponent<JointToConnector>().Joint(connectablePivot, connectableObject, target.transform);
            Destroy(this.gameObject.GetComponent<JointToConnector>());
        }
        #endregion

        #region 自分がNormalブロックまたは、Bigブロック,Structureブロック
        if (this.GetComponent<BlockBase>().type == BlockType.Normal|| this.GetComponent<BlockBase>().type == BlockType.Big||this.GetComponent<BlockBase>().type==BlockType.Structure)
        {
            if (connectableObject != null && connectablePivot != null && connectableObject.tag == "MovableBlock" && connectableObject.GetComponent<BlockBase>().type == BlockType.Normal)
            {

                this.gameObject.AddComponent<JointObjects>().Joint(connectablePivot, connectableObject, connectableObject.transform);
                Destroy(this.gameObject.GetComponent<JointObjects>());
            }
            else if (connectableObject != null && connectablePivot != null && connectableObject.tag == "MovableBlock" && connectableObject.GetComponent<BlockBase>().type == BlockType.Functional)
            {

                this.gameObject.AddComponent<JointObjects>().Joint(connectablePivot, connectableObject, connectableObject.transform);
                Destroy(this.gameObject.GetComponent<JointObjects>());
            }
            else if (connectableObject != null && connectablePivot != null && connectableObject.tag == "MovableBlock" && connectableObject.GetComponent<BlockBase>().type == BlockType.Big)
            {
                GameObject pivot_o = connectableObject.GetComponent<BlockBase>().connectablePivot;
                GameObject target = pivot_o.transform.parent.transform.GetChild(1).gameObject;
                this.gameObject.AddComponent<JointObjects>().Joint(connectablePivot, connectableObject, target.transform);
                Destroy(this.gameObject.GetComponent<JointObjects>());
            }
            else if (connectableObject != null && connectablePivot != null && connectableObject.tag == "MovableBlock" && connectableObject.GetComponent<BlockBase>().type == BlockType.Structure)
            {
                GameObject pivot_o = connectableObject.GetComponent<BlockBase>().connectablePivot;
                GameObject target = pivot_o.transform.parent.transform.GetChild(1).gameObject;
                if (target == null) target = connectableObject;
                this.gameObject.AddComponent<JointObjects>().Joint(connectablePivot, connectableObject, target.transform);
                Destroy(this.gameObject.GetComponent<JointObjects>());
            }
        }
        #endregion
        #region 自分がfunctionalブロック
        else if (this.GetComponent<BlockBase>().type == BlockType.Functional)
        {
            if (connectableObject != null && connectablePivot != null && connectableObject.tag == "MovableBlock" && connectableObject.GetComponent<BlockBase>().type == BlockType.Normal)
            {

                this.gameObject.AddComponent<JointWithFunctional>().Joint(connectablePivot, connectableObject, connectableObject.transform);
                Destroy(this.gameObject.GetComponent<JointWithFunctional>());
            }
            else if (connectableObject != null && connectablePivot != null && connectableObject.tag == "MovableBlock" && connectableObject.GetComponent<BlockBase>().type == BlockType.Functional)
            {

                this.gameObject.AddComponent<JointWithFunctional>().Joint(connectablePivot, connectableObject, connectableObject.transform);
                Destroy(this.gameObject.GetComponent<JointWithFunctional>());
            }
            else if (connectableObject != null && connectablePivot != null && connectableObject.tag == "MovableBlock" && connectableObject.GetComponent<BlockBase>().type == BlockType.Big)
            {
                GameObject pivot_o = connectableObject.GetComponent<BlockBase>().connectablePivot;
                GameObject target = pivot_o.transform.parent.transform.GetChild(1).gameObject;
                this.gameObject.AddComponent<JointWithFunctional>().Joint(connectablePivot, connectableObject, target.transform);
                Destroy(this.gameObject.GetComponent<JointWithFunctional>());
            }
            else if (connectableObject != null && connectablePivot != null && connectableObject.tag == "MovableBlock" && connectableObject.GetComponent<BlockBase>().type == BlockType.Structure)
            {
                GameObject pivot_o = connectableObject.GetComponent<BlockBase>().connectablePivot;
                GameObject target = pivot_o.transform.parent.transform.GetChild(1).gameObject;
                this.gameObject.AddComponent<JointWithFunctional>().Joint(connectablePivot, connectableObject, target.transform);
                Destroy(this.gameObject.GetComponent<JointWithFunctional>());
            }
        }
        #endregion
    }
}

