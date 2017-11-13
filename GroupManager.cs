using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupManager : MonoBehaviour {
    public List<GameObject> Member = new List<GameObject>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreateGroup(GameObject block_a,GameObject block_b)
    {
        
        Member.Add(block_a);
        Member.Add(block_b);
        block_a.transform.SetParent(this.transform);
        block_b.transform.SetParent(this.transform);

        #region AttachFixedJoint
        if (block_a.GetComponent<FixedJoint>())
        {
            if (block_a.GetComponent<FixedJoint>().connectedBody == null) block_a.GetComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
            else block_a.AddComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
        }
        else
        {
            block_a.AddComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
        }

        if (block_b.GetComponent<FixedJoint>())
        {
            if (block_b.GetComponent<FixedJoint>().connectedBody == null) block_b.GetComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
            else block_b.AddComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
        }
        else
        {
            block_b.AddComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
        }
#endregion

        

    }

    public void AddToGroup(GameObject block_a)
    {
       
        bool flag = true;
        foreach (GameObject block_b in Member)
        {
            if (block_b == block_a) flag = false;
        }
        if (flag)
        {
            Member.Add(block_a);
            block_a.transform.SetParent(this.transform);
            #region AttachFixedJoint
            if (block_a.GetComponent<FixedJoint>())
            {
                if (block_a.GetComponent<FixedJoint>().connectedBody == null) block_a.GetComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
                else block_a.AddComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
            }
            else
            {
                block_a.AddComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
            }
            #endregion
        }
    }

    public void MergeGroup(GameObject group_b)
    {
        List<GameObject> list = group_b.GetComponent<GroupManager>().Member;
        foreach (GameObject block_b in list)
        {
            bool flag = true;
            foreach (GameObject block in Member)
            {
                if (block == block_b) flag = false;
            }
            if (flag)
            {
                block_b.transform.SetParent(this.transform);
                Member.Add(block_b);
                block_b.GetComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
            }
        }
        Destroy(group_b);
    }
}
