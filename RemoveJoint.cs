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

    public List<GameObject> Remove(GameObject block_a)
    {
        GameObject pivot_a;
        GameObject pivot_b;
        List<GameObject> NewGroupList = new List<GameObject>();
        NewGroupList.Add(block_a);
        List<GameObject> ConnectionList = new List<GameObject>(block_a.GetComponent<BlockBase>().JointInformation.Keys);
        foreach (GameObject pivot in ConnectionList)
        {
            pivot_a = pivot;
            pivot_b = block_a.GetComponent<BlockBase>().JointInformation[pivot];
            GameObject block_b = pivot_b.transform.parent.transform.parent.gameObject;
            int Count = block_b.GetComponent<BlockBase>().JointInformation.Count;
            switch (Count)
            {
                case 0:
                    Debug.Log("error");
                    break;
                case 1:
                    if (block_b.GetComponent<BlockBase>().IsGrabbed == true)
                    {
                        //独立する処理
                        NewGroupList.Add(block_b);
                    }
                    else {
                        NewGroupList.Add(block_b); 
                    }
                    break;
                default:
                    pivot_a.GetComponent<PivotCollider>().SetValid();
                    pivot_b.GetComponent<PivotCollider>().SetValid();
                    block_a.GetComponent<BlockBase>().JointInformation.Remove(pivot_a);
                    block_b.GetComponent<BlockBase>().JointInformation.Remove(pivot_b);
                    //複数の接続がある
                    Debug.Log("保留");
                    break;
            }
            
        }
        return NewGroupList;

        //Destroy(block_a.GetComponent<RemoveJoint>());
    }
}
