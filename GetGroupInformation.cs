using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGroupInformation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public virtual void GetInformationOfGroup(GameObject block)
    {
        if(block.transform.parent.transform.parent= null)
        {
            return;
        }
        GameObject group = block.transform.parent.transform.parent.gameObject;
        List<GameObject> member = group.GetComponent<GroupManager>().Member;
    }

}
