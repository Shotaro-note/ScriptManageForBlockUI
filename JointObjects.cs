using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blocks;

public class JointObjects : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Joint(GameObject pivot_a,GameObject block_b)
    {
        GameObject block_a = pivot_a.transform.parent.transform.parent.gameObject;
        GameObject pivot_b = block_b.GetComponent<BlockBase>().connectablePivot;
        GameObject parent = null;

        if (block_a.GetComponent<BlockBase>().connectableObject == block_b && block_b.GetComponent<BlockBase>().connectableObject == block_a&& block_a.GetComponent<BlockBase>().IsGrabbed==false&& block_b.GetComponent<BlockBase>().IsGrabbed==false)
        {


            #region Joint blocks（かなり作りが雑、親子関係壊しまくってるので、いつか直したい)
            if (block_a.transform.parent!=null)
            {
                parent = block_a.transform.parent.gameObject;
            }            
            block_a.transform.SetParent(block_b.transform);

            Quaternion rotate_before = block_a.transform.localRotation;
            Vector3 rotate_eular = Quaternion.ToEulerAngles(rotate_before);
            float x = Mathf.Rad2Deg * rotate_eular.x;
            float y = Mathf.Rad2Deg * rotate_eular.y;
            float z = Mathf.Rad2Deg * rotate_eular.z;


            if (-180 < x && x < -135) { x = -180; }
            else if (-135 < x && x < -45) { x = -90; }
            else if (-45 < x && x < 45) { x = 0; }
            else if (45 < x && x < 135) { x = 90; }
            else if (135 < x && x < 180) { x = 180; }

            if (-180 < y && y < -135) { y = -180; }
            else if (-135 < y && y < -45) { y = -90; }
            else if (-45 < y && y < 45) { y = 0; }
            else if (45 < y && y < 135) { y = 90; }
            else if (135 < y && y < 180) { y = 180; }

            if (-180 < z && z < -135) { z = -180; }
            else if (-135 < z && z < -45) { z = -90; }
            else if (-45 < z && z < 45) { z = 0; }
            else if (45 < z && z < 135) { z = 90; }
            else if (135 < z && z < 180) { z = 180; }
            //Debug.Log(x + "  " + y + "  " + z);
           // block_a.transform.localRotation = Quaternion.Slerp(rotate_before, Quaternion.Euler(x, y, z), 1);
            Quaternion rotate_after = Quaternion.Euler(x, y, z);
            Quaternion Rotation = rotate_after * Quaternion.Inverse(rotate_before);           
            Vector3 move = pivot_b.transform.position - block_a.transform.position;

            if (parent != null)
            {
                List<GameObject> list = parent.GetComponent<GroupManager>().Member;
                int count = list.Count;
                Vector3[] movement = new Vector3[count];
                for(int i = 0; i < count; i++)
                {
                    if (list[i] != block_a)
                    {
                        list[i].transform.SetParent(block_a.transform);
                        movement[i] = list[i].transform.localPosition;
                    }
                    
                }
                block_a.GetComponent<FixedJoint>().connectedBody = null;         
                block_a.transform.position += move;
                block_a.transform.localRotation = Rotation * block_a.transform.localRotation;
                block_a.GetComponent<FixedJoint>().connectedBody = parent.GetComponent<Rigidbody>();
                for (int i = 0; i < count; i++)
                {
                    if (list[i] != block_a)
                    {
                        list[i].GetComponent<FixedJoint>().connectedBody = null;                                         
                        list[i].transform.localPosition = movement[i];
                        list[i].transform.SetParent(parent.transform);
                        //list[i].transform.localRotation = Rotation * list[i].transform.localRotation;
                        list[i].GetComponent<FixedJoint>().connectedBody = parent.GetComponent<Rigidbody>();
                        
                    }
                }
                block_a.transform.SetParent(parent.transform);                   
            }
            else
            {
                block_a.transform.localRotation = Rotation * block_a.transform.localRotation;
                block_a.transform.position += move;
                block_a.transform.SetParent(null);
            }
            /*ここに接続されたコンテンツ同士についてのEventが来る*/
            /*
            block_a.AddComponent<FixedJoint>().connectedBody = block_b.GetComponent<Rigidbody>();
            block_b.AddComponent<FixedJoint>().connectedBody = block_a.GetComponent<Rigidbody>();
            */
            Debug.Log(block_a.name+pivot_a.transform.parent.gameObject.name + " & " + block_b.name+pivot_b.transform.parent.gameObject.name + " are Conected!!");

            block_a.GetComponent<BlockBase>().JointInformation[pivot_a] = pivot_b;
            block_b.GetComponent<BlockBase>().JointInformation[pivot_b]= pivot_a;
            pivot_a.GetComponent<PivotCollider>().SetInvalid();
            pivot_b.GetComponent<PivotCollider>().SetInvalid();
            block_a.GetComponent<BlockBase>().ResetConnectable();
            block_b.GetComponent<BlockBase>().ResetConnectable();

            #endregion
            #region Make,Add to Group
            
            if (block_a.transform.parent == null && block_b.transform.parent == null)
            {
                GameObject prefab = Resources.Load<GameObject>("GroupManager");
                GameObject go = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
                go.GetComponent<GroupManager>().CreateGroup(block_a, block_b);
                Debug.Log("Make");
            }
            else if (block_a.transform.parent == null)
            {
                Debug.Log("parent: " + block_b.transform.parent.name);
                GameObject go = block_b.transform.parent.gameObject;
                go.GetComponent<GroupManager>().AddToGroup(block_a);
                Debug.Log("Add");
            }
            else if (block_b.transform.parent == null)
            {
                Debug.Log("parent: " + block_a.transform.parent.name);
                GameObject go = block_a.transform.parent.gameObject;
                go.GetComponent<GroupManager>().AddToGroup(block_b);
                Debug.Log("Add");
            }
            else if (block_a.transform.parent != null && block_b.transform.parent != null&&(block_a.transform.parent!=block_b.transform.parent))
            {                
                GameObject go = block_a.transform.parent.gameObject;
                go.GetComponent<GroupManager>().MergeGroup(block_b.transform.parent.gameObject);
                Debug.Log("Merge");
            }
            else Debug.Log("error");
            #endregion
            
          
        }

        /*
        if (block_b.GetComponent<FixedJoint>())
        {
            if (block_b.GetComponent<FixedJoint>().connectedBody == null) block_b.GetComponent<FixedJoint>().connectedBody = block_a.GetComponent<Rigidbody>();
            else block_b.AddComponent<FixedJoint>().connectedBody = block_a.GetComponent<Rigidbody>();
        }
        else
        {
            block_b.AddComponent<FixedJoint>().connectedBody = block_a.GetComponent<Rigidbody>();
        }
        */
    }



}
