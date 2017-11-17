using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blocks;

public class RemoveJoint : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //block_aを解除するときに、一緒に解除されるブロック確定＆Pivotを回復
    public List<GameObject> Remove(GameObject block_a)
    {
        GameObject pivot_a;
        GameObject pivot_b;
        List<GameObject> NewGroupList = new List<GameObject>();
        NewGroupList.Add(block_a);
        List<GameObject> ConnectionList = new List<GameObject>(block_a.GetComponent<BlockBase>().JointInformation.Keys);
        Debug.Log(ConnectionList.Count + "個のオブジェクトが接続されている");
        foreach (GameObject pivot in ConnectionList)
        {
            pivot_a = pivot;
            pivot_b = block_a.GetComponent<BlockBase>().JointInformation[pivot];
            GameObject block_b = pivot_b.transform.parent.transform.parent.gameObject;
            int Count = block_b.GetComponent<BlockBase>().JointInformation.Count;
            Debug.Log("block_bには" + Count + "個のブロックがついていている");
            switch (Count)
            {
                case 0:
                    Debug.Log("error");
                    break;
                case 1:
                    if (block_b.GetComponent<BlockBase>().IsGrabbed == false)
                    {
                        NewGroupList.Add(block_b);

                        Debug.Log(block_a.name + pivot_a.transform.parent.gameObject.name + " & " + block_b.name + pivot_b.transform.parent.gameObject.name + " 's connection is broken!!");
                        block_a.GetComponent<BlockDataLogger>().BlockEventLogger(block_a, block_b, "Is Disconnected");
                        block_b.GetComponent<BlockDataLogger>().BlockEventLogger(block_b, block_a, "Is Disconnected");

                        pivot_a.GetComponent<PivotCollider>().SetValid();
                        pivot_b.GetComponent<PivotCollider>().SetValid();
                        block_a.GetComponent<BlockBase>().JointInformation.Remove(pivot_a);
                        block_b.GetComponent<BlockBase>().JointInformation.Remove(pivot_b);
                    }
                    break;
                default://とりあえず長ったらしくかいとく
                    Debug.Log(block_a.name + pivot_a.transform.parent.gameObject.name + " & " + block_b.name + pivot_b.transform.parent.gameObject.name + " 's connection is broken!!");
                    block_a.GetComponent<BlockDataLogger>().BlockEventLogger(block_a, block_b, "Is Disconnected");
                    block_b.GetComponent<BlockDataLogger>().BlockEventLogger(block_b, block_a, "Is Disconnected");

                    pivot_a.GetComponent<PivotCollider>().SetValid();
                    pivot_b.GetComponent<PivotCollider>().SetValid();
                    block_a.GetComponent<BlockBase>().JointInformation.Remove(pivot_a);
                    block_b.GetComponent<BlockBase>().JointInformation.Remove(pivot_b);
                    //複数の接続がある
                    break;
            }
            
        }
        return NewGroupList;
    }
    //接続全解除
    public void RemoveAllJointInGroup(GameObject group)
    {
        if (!group.GetComponent<GroupManager>())
        {
            return;
        }
        List<GameObject> BlockList = group.GetComponent<GroupManager>().Member;
        group.GetComponent<GroupManager>().RemoveAllFromGroup();
        foreach (GameObject block in BlockList)
        {
            List <GameObject> ConnectionList = new List<GameObject>(block.GetComponent<BlockBase>().JointInformation.Keys);
            for (int i = ConnectionList.Count - 1; i >= 0; i--)
            {
                ConnectionList[i].GetComponent<PivotCollider>().SetValid();
                ConnectionList.RemoveAt(i);
            }
            block.transform.position += new Vector3(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f), Random.Range(-.1f, .1f));
        }    
            
        Destroy(group);
    }
}
