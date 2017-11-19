using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blocks;

[RequireComponent(typeof(ParticleRaiser))]
public class GroupManager : MonoBehaviour
{
      
    public List<GameObject> Member = new List<GameObject>();
    public bool ChildIsGrabbed = false;
    private float time = 0;
    private int GrabbedObjectCount = 0;
    private GameObject FirstGrabbedBock;
    private GameObject RemovedBlock;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        #region グループ内に掴まれているブロックが2つあった時点で、Remove処理開始,要検討！
        bool check = false;
        foreach (GameObject block in Member)
        {

            if (block.GetComponent<BlockBase>().IsGrabbed == true && FirstGrabbedBock == null)
            {
                FirstGrabbedBock = block;
                check = true;
            }
            if (block.GetComponent<BlockBase>().IsGrabbed == true && FirstGrabbedBock != null)
            {
                check = true;
                if (FirstGrabbedBock != block)
                {
                    RemovedBlock = block;
                }
            }

        }
        if (!check) FirstGrabbedBock = null;
        if (RemovedBlock != null)
        {
            RemoveFromGroup(RemovedBlock);
            RemovedBlock = null;
        }
        #endregion

        #region グループ内にJoint可能なペアがあるか検索、
        if (time > 2f)
        {
            time = 0;
            if (Member.Count == 0) Destroy(this.transform.gameObject);
            foreach (GameObject block in Member)
            {
                if (block.GetComponent<BlockBase>().connectableObject != null && block.GetComponent<BlockBase>().connectablePivot != null)
                {
                    foreach (GameObject block_b in Member)
                    {
                        if (block_b == block.GetComponent<BlockBase>().connectableObject)
                        {
                            block.AddComponent<JointObjects>().Joint(block.GetComponent<BlockBase>().connectablePivot, block.GetComponent<BlockBase>().connectableObject, block.GetComponent<BlockBase>().connectableObject.transform);
                            Destroy(this.gameObject.GetComponent<JointObjects>());
                        }
                    }
                }
            }

        }
        else time += Time.deltaTime;
        #endregion
    }

    //ブロック同士を結合してGroup化
    public void CreateGroup(GameObject block_a, GameObject block_b)
    {

        Member.Add(block_a);
        Member.Add(block_b);
        block_a.transform.SetParent(this.transform);
        block_b.transform.SetParent(this.transform);
        block_a.GetComponent<BlockBase>().IsInGroup = true;
        block_b.GetComponent<BlockBase>().IsInGroup = true;

        #region AttachFixedJoint
        if (block_a.GetComponent<FixedJoint>())
        {
            if (block_a.GetComponent<FixedJoint>().connectedBody == null) block_a.GetComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
            else block_a.AddComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
        }
        else
        {
            block_a.AddComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
        }

        if (block_b.GetComponent<FixedJoint>())
        {
            if (block_b.GetComponent<FixedJoint>().connectedBody == null) block_b.GetComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
            else block_b.AddComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
        }
        else
        {
            block_b.AddComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
        }
        #endregion
    }

    //BlockをGroupに追加
    public void AddToGroup(GameObject block_a)
    {

        bool flag = true;
        foreach (GameObject block_b in Member)
        {
            if (block_b == block_a) flag = false;
        }

        if (flag)
        {
            block_a.GetComponent<BlockBase>().IsInGroup = true;
            Member.Add(block_a);
            block_a.transform.SetParent(this.transform);
            #region AttachFixedJoint            
            if (block_a.GetComponent<FixedJoint>())
            {
                if (block_a.GetComponent<FixedJoint>().connectedBody == null) block_a.GetComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
                else block_a.AddComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
            }
            else
            {
                block_a.AddComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
            }
            #endregion
        }
    }

    //Group同士を結合して一つのGroup化
    public void MergeGroup(GameObject group_b)
    {
        List<GameObject> list = group_b.GetComponent<GroupManager>().Member;
        foreach (GameObject block_b in list)
        {
            block_b.transform.SetParent(this.transform);
            this.Member.Add(block_b);
            block_b.GetComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
        }
        Destroy(group_b);
    }

    #region CreateGroup(List<GameObject>)  お蔵入り
    /*
    public void CreateGroup(List<GameObject> newGroupList)
    {
        if (newGroupList.Count == 1)
        {
            newGroupList[0].GetComponent<BlockBase>().IsInGroup = false;

        }
        else
        {
            foreach (GameObject block in newGroupList)
            {
                Member.Add(block);
                block.transform.SetParent(this.transform);
                #region AttachFixedJoint              
                if (block.GetComponent<FixedJoint>())
                {
                    if (block.GetComponent<FixedJoint>().connectedBody == null) block.GetComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
                    else block.AddComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
                }
                else
                {
                    block.AddComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
                }
                #endregion
                Debug.Log("ReMake");
            }
        }
    }
    */
    #endregion

    //除去対象になったブロックの除去＆一緒に除去されるブロックの除去
    public void RemoveFromGroup(GameObject block)
    {
        List<GameObject> list = block.AddComponent<RemoveJoint>().Remove(block);
        //グループから外すか、新しいグループを作るか
        for(int i = list.Count - 1; i >= 0; i--) { 
            list[i].GetComponent<BlockBase>().IsInGroup = false;
            list[i].transform.SetParent(null);
            Destroy(list[i].GetComponent<FixedJoint>());
            if (list[i] != block)
            {
                list[i].transform.position += new Vector3(Random.Range(-.3f, .3f), Random.Range(-.3f, .3f), Random.Range(-.3f, .3f));
                //エフェクト追加用
                this.GetComponent<ParticleRaiser>().RaiseParticle(list[i].transform);
                
            }
            this.Member.Remove(list[i]);
        }
        Destroy(block.GetComponent<RemoveJoint>());
        ////else
        ////{
        //    foreach (GameObject block in list)
        //    {
        //        this.Member.Remove(block);
        //        block.GetComponent<FixedJoint>().connectedBody = null;
        //        block.transform.SetParent(null);
        //    }
        //    GameObject prefab = Resources.Load<GameObject>("GroupManager");
        //    GameObject go = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        //    go.GetComponent<GroupManager>().CreateGroup(list);
        ////}

    }

    //グループ内のブロック全開放
    public void RemoveAllFromGroup()
    {
        for (int i = Member.Count - 1; i >= 0; i--)
        {
            Member[i].transform.SetParent(null);
            Member[i].GetComponent<BlockBase>().IsInGroup = false;
            Destroy(Member[i].GetComponent<FixedJoint>().connectedBody);
        }
    }
}

    
       

