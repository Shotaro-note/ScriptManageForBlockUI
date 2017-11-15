using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistance : MonoBehaviour {
    public GameObject Target;
    private Vector3 Initial;
    Quaternion rotate_before;
    Quaternion rotate_after;
    Quaternion Rotation;

    void Start()
    {
       
            Initial = this.transform.localPosition - Target.transform.localPosition;
            updatePosition();
            Rotation = Quaternion.FromToRotation(this.transform.forward, Target.transform.position - this.transform.position);
        
        }
    void Update()
    {
        if (Target != null)  updatePosition();
    }

    void updatePosition()
    {
        Vector3 pos = Target.transform.localPosition;
        this.transform.localPosition = pos + Initial;
        this.transform.rotation = Target.transform.rotation* Rotation;       
    }


}
