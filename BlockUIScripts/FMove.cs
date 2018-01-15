using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMove :MonoBehaviour {
    float elapsedTime = 0;
    Vector3 InitialPosition;
    Quaternion InitialRotation;
    GameObject block;
    //Transform target;
    Vector3 a;
    Vector3 b;
    float time=5f;
    // Use this for initialization
    void Start () {
        block= this.gameObject;
       // target= this.GetComponent<FunctionManager>().tr0;
        time = 3f;
        InitialPosition = block.transform.position;
        InitialRotation = block.transform.rotation;
        a = block.transform.GetChild(2).transform.position;
        b = a - block.transform.position;
        if (block.transform.parent != null)
        {
            block = this.transform.parent.gameObject;
        }
        Debug.Log("FMobe function");
    }
	
	// Update is called once per frame
	void Update () {
        if (elapsedTime < 1f)
        {
            if (block!=null)
            {
               // block.transform.rotation = Quaternion.Lerp(InitialRotation, target.rotation, elapsedTime);
                block.transform.position += b/time;
                elapsedTime += (Time.deltaTime / time);
            }
        }
        if (elapsedTime > 1f)
        {
            //block.transform.position = target.position;
            Debug.Log("Bye!");
            Destroy(this);
        }
    }
   
}
