using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistance : MonoBehaviour {

    public Transform target;
    Vector3 Initial;
    Vector3 InitialTarget;
    //float maxDistance;
    
    Animator animator;

    public void SetTarget(Transform t)
    {
        Initial = transform.position;
        target = t;
        InitialTarget = t.position;
    }
    // Update is called once per frame
    void Update()
    {

        if (!animator.GetBool("IsAttached"))
        {
            animator.SetBool("IsAttached", true);
        }
        /*
        if ((HandState.Instance.Selected_R == gameObject && HandState.Instance.state_r == HandState.STATE.GRAB) || (HandState.Instance.Selected_L == gameObject && HandState.Instance.state_l == HandState.STATE.GRAB))
        {
            if ((transform.position - target.position).magnitude > maxDistance)
            {
                if (GameManager.Instance.status == GAMESTATE.IN_WORKS)
                {
                    var conn = target.transform.parent.parent.gameObject.GetComponent<ConnectorController>();
                    conn.Remove(gameObject);
                }
                Destroy(this);
            }
            return;
        }
        */
        var delta = target.position - InitialTarget;

        transform.position = Initial + delta;
    }
}
