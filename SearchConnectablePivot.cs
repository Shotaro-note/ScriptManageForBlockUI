using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blocks;
using UnityEngine.UI;

namespace Blocks
{
    public class SearchConnectablePivot : MonoBehaviour
    {
        private GameObject connectableSurface_a;
        private GameObject connectableSurface_b;
        private GameObject piv_a;
        private GameObject piv_b;
        // Use this for initialization


        public void SetTarget(GameObject a, GameObject b)
        {
            connectableSurface_a = null;
            connectableSurface_b = null;
            

            float minDistance = 100f;
            foreach (GameObject surface_a in a.GetComponent<BlockBase>().surfaceWithPivots)
            {
                piv_a = surface_a.transform.GetChild(0).gameObject;
                if (piv_a.GetComponent<PivotBase>().isConnected == false)
                {
                    foreach (GameObject surface_b in b.GetComponent<BlockBase>().surfaceWithPivots)
                    {
                        piv_b = surface_b.transform.GetChild(0).gameObject;
                        if (piv_b.GetComponent<PivotBase>().isConnected == false)
                        {
                            float distance = Vector3.Distance(piv_a.transform.position, piv_b.transform.position);
                            if (distance < minDistance)
                            {
                                minDistance = distance;
                                connectableSurface_a = surface_a;
                                connectableSurface_b = surface_b;
                            }
                        }

                    }
                }
            }
            if (connectableSurface_a != null && connectableSurface_b != null)
            {
                piv_a=connectableSurface_a.transform.GetChild(0).gameObject;
                piv_a.GetComponent<PivotBase>().isConnected = true;
                piv_b=connectableSurface_b.transform.GetChild(0).gameObject;
                piv_b.GetComponent<PivotBase>().isConnected = true;
                this.gameObject.AddComponent<JointObjects>().Joint(piv_a, piv_b);

                Debug.Log(connectableSurface_a + "+" + connectableSurface_b);
                Destroy(this.GetComponent<SearchConnectablePivot>());
            }

            
           
        }

    }
}