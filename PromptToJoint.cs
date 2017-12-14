using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blocks;

public class PromptToJoint : MonoBehaviour {
    [SerializeField]
    private List<GameObject> blockInScene;
    [SerializeField]
    private GameObject particlePromptConnect;
    [SerializeField]
    private GameObject particlePromptGrab;
    public float time=0f;

	// Use this for initialization
	void Start () {
		
	}
	/// <summary>
    /// Promptを呼び出す条件は要検討
    /// </summary>
	// Update is called once per frame
	void Update () {
      
        if (time > 15f)
        {
            PromptGrab();          
            PromptConnect();
            time = 0f;
        }
        else
        {
            time += Time.deltaTime;
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
                    Debug.Log("PromptGrab");
                    GameObject promptParticle = Instantiate(particlePromptGrab, block.transform.position, block.transform.rotation);
                    Destroy(promptParticle, 3f);

                }
            }
        }
    }
    private void PromptConnect()
    {
        foreach(GameObject block in blockInScene)
        {
            foreach(GameObject surface in block.GetComponent<BlockBase>().surfaceWithPivots)
            {
                Debug.Log("promptConnect");
                GameObject pivot = surface.transform.GetChild(0).gameObject;
                if(pivot.GetComponent<BoxCollider>().enabled == true){
                    GameObject promptParticle = Instantiate(particlePromptConnect, pivot.transform.position, pivot.transform.rotation);
                    Destroy(promptParticle, 3f);
                }
            }
        }
    }
}
