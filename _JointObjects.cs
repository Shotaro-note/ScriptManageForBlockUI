using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blocks;

namespace Blocks
{
    public class _JointObjects : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
/*
        public void Joint(GameObject pivot_a, GameObject pivot_b)
        {

            GameObject parent_a = pivot_a.transform.parent.transform.parent.transform.parent.gameObject;
            GameObject parent_b = pivot_b.transform.parent.transform.parent.transform.parent.gameObject;
            parent_a.transform.SetParent(pivot_b.transform);

            Quaternion rotate = parent_a.transform.localRotation;
            Vector3 rotate_eular = Quaternion.ToEulerAngles(rotate);
            float x = Mathf.Rad2Deg * rotate_eular.x;
            float y = Mathf.Rad2Deg * rotate_eular.y;
            float z = Mathf.Rad2Deg * rotate_eular.z;


            if (-180 < x && x < -135) { x = -180; }
            else if (-135 < x && x < -45) { x = -90; }
            else if (-45 < x && x < 45) { x = 0; }
            else if (45 < x && x < 135) { x = 90; }
            else if (135 < x&&x < 180) { x = 180; }

            if (-180 < y && y < -135) { y = -180; }
            else if (-135 < y && y < -45) { y = -90; }
            else if (-45 < y && y < 45) { y = 0; }
            else if (45 < y && y < 135) { y = 90; }
            else if (135 < y && y < 180) { y = 180; }

            if (-180 < z && z< -135) { z = -180; }
            else if (-135 < z && z < -45) { z = -90; }
            else if (-45 < z && z < 45) { z = 0; }
            else if (45 < z && z < 135) { z = 90; }
            else if (135 < z && z < 180) { z = 180; }
            Debug.Log(x+"  "+y+"  "+ z);
            parent_a.transform.localRotation = Quaternion.Slerp(rotate, Quaternion.Euler(x, y, z), 1); 
            

            Vector3 move = pivot_b.transform.position - pivot_a.transform.position;
            parent_a.transform.position += move;


            parent_a.transform.SetParent(null);

            if (parent_b.GetComponent<FixedJoint>())
            {
                if (parent_b.GetComponent<FixedJoint>().connectedBody == null) parent_b.GetComponent<FixedJoint>().connectedBody = parent_a.GetComponent<Rigidbody>();
                else parent_b.AddComponent<FixedJoint>().connectedBody = parent_a.GetComponent<Rigidbody>();
            }
            else
            {
                parent_b.AddComponent<FixedJoint>().connectedBody = parent_a.GetComponent<Rigidbody>();
            }

         
      
        }
        */
    }
    
}
