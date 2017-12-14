using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplanePart : MonoBehaviour {
    public type Type;

    public void ChangeMaterial(Material mat)
    {
        if (this.transform.childCount == 0)
        {
            this.transform.GetComponent<MeshRenderer>().material = mat;
        }
        else
        {
            for (int i = this.transform.childCount - 1; i >= 0; i--)
            {
                this.transform.GetChild(i).transform.GetComponent<MeshRenderer>().material = mat;
            }
        }
    }
	public enum type
    {
        body,
        wing,
        engine,
        weapon,
        material
    }
}
