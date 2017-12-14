using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blocks;

public class FCastleConstruct :MonoBehaviour {
    
    GameObject block;
    
    // Use this for initialization
    void Start () {
        block= this.gameObject;
        Build(block);
        
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    public void Build(GameObject block)
    {
        if(block.transform.parent!= null)
        {
            GameObject group = block.transform.parent.gameObject;
            List<GameObject> list = group.GetComponent<GroupManager>().Member;
            foreach(GameObject go in list)
            {
                if (go.GetComponent<BlockBase>().type == BlockBase.BlockType.Structure)
                {
                    GameObject parts = go.transform.GetChild(0).gameObject;
                    if(parts!= null)
                    {
                        GameObject child=Instantiate(parts, parts.transform.position + (Vector3.forward*.3f), parts.transform.rotation);
                        child.transform.localScale = parts.transform.lossyScale;
                    }
                }
            }
            group.AddComponent<RemoveJoint>().RemoveAllJointInGroup(group);
            Destroy(this);
        }
    }
   
}
