using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blocks;

public class Manufacturing : MonoBehaviour {
    private GameObject Body=null;
    private GameObject Wing=null;
    private List<GameObject> Engine=new List<GameObject>();
    private GameObject Weapon=null;
    private GameObject Material = null;

    private Transform createPos;

	public void Scan(List<GameObject> member)
    {
        for(int i = member.Count-1; i >= 0; i--)
        {
            if (member[i].GetComponent<AirplanePart>().Type==AirplanePart.type.body)
            {
                Body = member[i];
                checkMaterial(Body);
            }
            else if (member[i].GetComponent<AirplanePart>().Type == AirplanePart.type.wing)
            {
                Wing = member[i];
                checkMaterial(Wing);
            }
            else if (member[i].GetComponent<AirplanePart>().Type == AirplanePart.type.engine)
            {
                Engine.Add(member[i]);
                checkMaterial(member[i]);
            }
            else if (member[i].GetComponent<AirplanePart>().Type == AirplanePart.type.weapon)
            {
                Weapon = member[i];
                checkMaterial(Weapon);
            }
        }
        if (Body == null)
        {
            Debug.Log("No body");
            return;
        }    
    }

    public void CreateAirplane()
    {
        GameObject airplane = new GameObject("airplane");
        /*ここに飛行機用のスクリプトとかを追加する手順を書く*/
        /*Body,Wing,Engine,Weaponを割り当てて、Instantiateする？*/
    }

    public void checkMaterial(GameObject obj)
    {
        List<GameObject> list = new List<GameObject>(obj.GetComponent<BlockBase>().JointInformation.Keys);
        foreach (GameObject pivot in list)
        {
            GameObject pivot_a = pivot;
            GameObject pivot_b = pivot.transform.parent.transform.parent.GetComponent<BlockBase>().JointInformation[pivot];
            GameObject obj_b = pivot_b.transform.parent.transform.parent.gameObject;
            if (obj_b.GetComponent<AirplanePart>().Type == AirplanePart.type.material)
            {
                Material = obj_b;
                Debug.Log("Material Detected");
                /*ここに、パーツの色を変える関数を記述する*/
            }
        }
    }
}
