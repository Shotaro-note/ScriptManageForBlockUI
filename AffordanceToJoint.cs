using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blocks;

public class AffordanceToJoint : MonoBehaviour {
    [SerializeField]
    private List<GameObject> blockInScene;
    [SerializeField]
    private GameObject particlePromptConnect;
    [SerializeField]
    private GameObject particlePromptGrab;
    private float time=0f;

	// Use this for initialization
	void Start () {
		
	}
	/// <summary>
    /// Promptを呼び出す条件は要検討
    /// </summary>
	// Update is called once per frame
	void Update () {
        if (time < 1f)
        {
            PromptGrab();
            time = 1f;
        }
        if (time > 15f)
        {
            PromptConnect();
            time = 0f;
        }
        else
        {
            time = Time.deltaTime;
        }
		
	}
    private void PromptGrab()
    {
        
        foreach(GameObject block in blockInScene)
        {
            if (block.tag == "MovableBlock")
            {
                if (block.GetComponent<BlockBase>().IsInGroup == false && block.GetComponent<BlockBase>().IsGrabbed == false)
                {
                    GameObject promptParticle = Instantiate(particlePromptConnect, block.transform.parent.transform.position, block.transform.parent.transform.rotation);
                    Destroy(promptParticle, 5f);

                }
            }
        }
    }
    private void PromptConnect()
    {
        foreach(GameObject block in blockInScene)
        {
            foreach(GameObject pivot in block.GetComponent<BlockBase>().surfaceWithPivots)
            {
                if(pivot.GetComponent<BoxCollider>().enabled == true){
                    GameObject promptParticle = Instantiate(particlePromptConnect, pivot.transform.parent.transform.position, pivot.transform.parent.transform.rotation);
                    Destroy(promptParticle, 5f);
                }
            }
        }
    }
}
