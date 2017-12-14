using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAnalyze : MonoBehaviour {
    GameObject block;
	// Use this for initialization
	void Start () {
        block = this.gameObject;
        Analyze(block);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// Debug以下は仮
    /// </summary>
    /// <param name="go"></param>
    void Analyze(GameObject go)
    {
        if (go.transform.parent != null)
        {
            GameObject group = go.transform.parent.gameObject;
            List<GameObject> list= group.GetComponent<GroupManager>().Member;
            Debug.Log(group.name + "　のメンバーは　");
            foreach(GameObject member in list)
            {
                Debug.Log(member.name);
            }
            Debug.Log("です");
        }
        Destroy(this);
    }
}
