using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        block_a.transform.SetParent(block_b.transform);

        Quaternion rotate = block_a.transform.localRotation;
        Vector3 rotate_eular = Quaternion.ToEulerAngles(rotate);
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
        Debug.Log(x + "  " + y + "  " + z);
        block_a.transform.localRotation = Quaternion.Slerp(rotate, Quaternion.Euler(x, y, z), 1);


        Vector3 move = block_b.transform.position - pivot_a.transform.position;
        block_a.transform.position += move;
        block_a.transform.SetParent(null);

        if (block_a.transform.parent == null&&block_b.transform.parent==null)
        {
            GameObject prefab = Resources.Load<GameObject>("GroupManager");
            GameObject go = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
            go.GetComponent<GroupManager>().CreateGroup(block_a, block_b);
        }
        else if (block_a.transform.parent == null && block_b.transform.parent != null)
        {
            GameObject go = block_b.transform.parent.gameObject;
            go.GetComponent<GroupManager>().AddToGroup(block_a);
        }
        else if (block_b.transform.parent == null && block_a.transform.parent != null)
        {
            GameObject go = block_a.transform.parent.gameObject;
            go.GetComponent<GroupManager>().AddToGroup(block_b);
        }
        else if (block_a.transform.parent != null && block_b.transform.parent != null)
        {
            GameObject go = block_a.transform.parent.gameObject;
            go.GetComponent<GroupManager>().MergeGroup(block_b.transform.parent.gameObject);
        }
        else Debug.Log("error");

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
