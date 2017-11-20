using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMove :MonoBehaviour {
    float elapsedTime = 0;
    Vector3 InitialPosition;
    Quaternion InitialRotation;
    GameObject block;
    Transform target;
    float time;
    // Use this for initialization
    void Start () {
        block= this.GetComponent<FunctionManager>().go0;
        target= this.GetComponent<FunctionManager>().tr0;
        time = this.GetComponent<FunctionManager>().value0;
        InitialPosition = block.transform.position;
        InitialRotation = block.transform.rotation;
        Debug.Log("FMobe function");
    }
	
	// Update is called once per frame
	void Update () {
        if (elapsedTime < 1f)
        {
            block.transform.rotation = Quaternion.Lerp(InitialRotation, target.rotation, elapsedTime);
            block.transform.position = Vector3.Lerp(InitialPosition, target.position, elapsedTime);
            elapsedTime += (Time.deltaTime / time);

        }
        if (elapsedTime > 1f)
        {
            block.transform.position = target.position;
            Debug.Log("Bye!");
            Destroy(this);
        }
    }
   
}
