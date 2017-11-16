using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistance : MonoBehaviour {
    public GameObject Target;

    /// <summary>
    /// Rigidbodyがついてる親子だと都合が悪いので、
    /// 親の動きを追従する空のGameObjectで対応
    /// </summary>
    void Start()
    {                
            updatePosition();       
        }
    void Update()
    {
        if (Target != null)  updatePosition();
    }

    void updatePosition()
    {
        this.transform.position = Target.transform.position;
        this.transform.rotation = Target.transform.rotation;   
    }


}
