using UnityEngine;
using System.Collections;
using Blocks;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public static Hand Instance;

    #region variables
    //public STATE state;
    public STATE state_r;
    public STATE state_l;

    public GameObject Palm_r;
    public GameObject Palm_l;
    public GameObject positionMarker_r;
    public GameObject positionMarker_l;

    public Vector3 grabbedPoint_r;
    private Vector3 grabbedAngle_r;
    private Quaternion grabbedQuaterrion_r;
    public Vector3 InitialPoint_r;
    public Vector3 InitialAngle_r;

    public Vector3 grabbedPoint_l;
    private Vector3 grabbedAngle_l;
    public Vector3 InitialPoint_l;
    public Vector3 InitialAngle_l;

    private Vector3 LocalgrabbedPoint_r;
    private Vector3 LocalgrabbedPoint_l;

    public GameObject Selected_L;
    public GameObject Selected_R;

    private bool canMove_R;
    private bool canMove_L;

    public AudioClip grab_sound;
    public AudioClip grab_sound2;

    Vector3 InitialBlockPosition_R;
    Vector3 InitialBlockPosition_L;

    Rigidbody jointR;
    Rigidbody jointL;
    #endregion

    void Awake()
    {
        Instance = this;
        state_r = STATE.NONE;
        state_l = STATE.NONE;

        canMove_L = false;
        canMove_R = false;
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            if (Selected_R != null && Selected_R.GetComponent<BlockBase>().IsInGroup == true){
                GameObject group = Selected_R.transform.parent.gameObject;
                state_r = STATE.NONE;
                grabbedPoint_r = Vector3.zero;
                canMove_R = false;
                Selected_R = null;
                this.gameObject.AddComponent<RemoveJoint>().RemoveAllJointInGroup(group);
                Destroy(this.gameObject.GetComponent<RemoveJoint>());
            }
           
        }
        #region Layer:Photo,D-Flipから取り出す時

        if (Selected_R != null && state_r == STATE.GRAB && canMove_R && Selected_R.layer == LayerMask.NameToLayer("Photo"))
        {
            var dif = Selected_R.transform.InverseTransformVector(positionMarker_r.transform.position - grabbedPoint_r);
            dif = Selected_R.transform.TransformVector(Vector3.Scale(dif, new Vector3(0, 0, 1)));
            Selected_R.transform.position = InitialPoint_r + dif;
            var photoChild = Selected_R.GetComponent<PhotoChild>();
            if (photoChild.CreateFlag)
            {
                DisplayToMovable_R();
            }

        }

        if (Selected_L != null && state_l == STATE.GRAB && canMove_L && Selected_L.layer == LayerMask.NameToLayer("Photo"))
        {
            var dif = Selected_L.transform.InverseTransformVector(positionMarker_l.transform.position - grabbedPoint_l);
            dif = Selected_L.transform.TransformVector(Vector3.Scale(dif, new Vector3(0, 0, 1)));
            Selected_L.transform.position = InitialPoint_l + dif;
            var photoChild = Selected_L.GetComponent<PhotoChild>();
            if (photoChild.CreateFlag)
            {
                DisplayToMovable_L();
            }

        }

        #endregion
        #region Old moving system of movable block
        /*
        if (Selected_R != null && state_r == STATE.GRAB && canMove_R && Selected_R.tag == "MovableBlock")
        {
            //HapticExample.PlayStay(true);

            Selected_R.transform.position = InitialPoint_r + positionMarker_r.transform.position - grabbedPoint_r;

            // Selected_R.transform.localEulerAngles = InitialAngle_r + new Vector3(0, (grabbedAngle_r.z - Palm_r.transform.localEulerAngles.z), 0) * .8f;
            //Selected_R.transform.localEulerAngles += Palm_r.transform.localEulerAngles - grabbedAngle_r;
            Selected_R.transform.rotation *= Palm_r.transform.localRotation * Quaternion.Inverse(grabbedQuaterrion_r);
            Debug.Log(Selected_R.transform.localEulerAngles);
            //Selected_R.transform.RotateAround(Selected_R.transform.position, Vector3.up,-1*( grabbedAngle_r.z - Palm_r.transform.localEulerAngles.z));
            //Selected_R.transform.RotateAround(Selected_R.transform.position, Vector3.right, -1 * (grabbedAngle_r.y - Palm_r.transform.localEulerAngles.y));
            //Selected_R.transform.RotateAround(Selected_R.transform.position, Vector3.forward, -1 * (grabbedAngle_r.x - Palm_r.transform.localEulerAngles.x));
            grabbedAngle_r = Palm_r.transform.localEulerAngles;
            grabbedQuaterrion_r = Palm_r.transform.localRotation;
        }


        if (Selected_L != null && state_l == STATE.GRAB && canMove_L && Selected_L.tag == "MovableBlock")
        {
            // HapticExample.PlayStay(false);
            Selected_L.transform.position = InitialPoint_l + positionMarker_l.transform.position - grabbedPoint_l;
            //            Selected_L.transform.localEulerAngles = InitialAngle_l + new Vector3(0, (grabbedAngle_l.z - Palm_l.transform.localEulerAngles.z), 0) *.8f;
            Selected_L.transform.RotateAround(Selected_L.transform.position, Vector3.up, -1 * (grabbedAngle_l.z - Palm_l.transform.localEulerAngles.z));
            grabbedAngle_l = Palm_l.transform.localEulerAngles;
        }
        */
        #endregion
    }

    public void SetSelectedObject(GameObject go, bool isright)
    {
        
        if (isright)
        {
            if (Selected_R == null && (Selected_L == null || Selected_L != go))
            {
                //Debug.Log("activate");
                Selected_R = go;

                InitialBlockPosition_R = go.transform.position;
            }
        }
        else
        {
            if (Selected_L == null && (Selected_R == null || Selected_R != go))
            {
                Selected_L = go;
                InitialBlockPosition_L = go.transform.position;
            }
        }

    }
    public void CancelSelectedObject(GameObject go, bool isright)
    {

        if (isright)
        {
            if (state_r != STATE.GRAB && Selected_R == go)
            {
                Selected_R = null;
            }
        }
        else
        {
            if (state_l != STATE.GRAB && Selected_L == go)
            {
                Selected_L = null;
            }
        }
        /*var child = go.GetComponent<PhotoChild>();
        if (child)
            child.ResetColor();
*/
    }

    #region description
    /*To detect grasping or releasing action, it' needed to use GrabberForBlockUI(Touch) and ExtendedFingerDetector(Leap) */
    #endregion

    public void OnGrabbed_R()
    {
 
        LocalgrabbedPoint_r = Camera.main.transform.InverseTransformVector(Palm_r.transform.position);

        if (Selected_R != null)
        {
            
            state_r = STATE.GRAB;

            grabbedPoint_r = positionMarker_r.transform.position;
            grabbedAngle_r = Palm_r.transform.localEulerAngles;
            grabbedQuaterrion_r = Palm_r.transform.localRotation;

            InitialPoint_r = Selected_R.transform.position;
            InitialAngle_r = Selected_R.transform.localEulerAngles;
            
            if (Selected_R != null && Selected_R.tag == "MovableBlock")
            {
                Selected_R.GetComponent<BlockBase>().IsGrabbed = true;
                /*if(Selected_R.GetComponent<BlockBase>().IsInGroup == true)
                {
                    Selected_R.transform.parent.gameObject.GetComponent<GroupManager>().AddKeepDistance(Selected_R);
                }*/
                if (Selected_R.GetComponent<BlockBase>().IsInGroup == true)
                {
                    
                    GameObject parent = Selected_R.transform.parent.gameObject;
                    if (parent.GetComponent<GroupManager>().ChildIsGrabbed)
                    {
                        parent.GetComponent<GroupManager>().RemoveFromGroup(Selected_R);
                        //ここで、Removeされて動かせるようになったオブジェクトが来る。
                        OnGrabbed_R();//再帰呼び出しして、
                    }
                    else
                    {
                        parent.transform.SetParent(Palm_r.transform);
                        parent.GetComponent<GroupManager>().ChildIsGrabbed = true;
                    }
                    //if (Palm_r.GetComponent<FixedJoint>())
                    //{
                    //    if (Palm_r.GetComponent<FixedJoint>().connectedBody == null) Palm_r.GetComponent<FixedJoint>().connectedBody = parent.GetComponent<Rigidbody>();
                    //    else Palm_r.AddComponent<FixedJoint>().connectedBody = parent.GetComponent<Rigidbody>();
                    //}
                    //else
                    //{
                    //    Palm_r.AddComponent<FixedJoint>().connectedBody = parent.GetComponent<Rigidbody>();
                    //}
                }
                else
                {
                    Selected_R.transform.SetParent(Palm_r.transform);
                    //if (Palm_r.GetComponent<FixedJoint>())
                    //{
                    //    if (Palm_r.GetComponent<FixedJoint>().connectedBody == null) Palm_r.GetComponent<FixedJoint>().connectedBody = Selected_R.GetComponent<Rigidbody>();
                    //    else Palm_r.AddComponent<FixedJoint>().connectedBody = Selected_R.GetComponent<Rigidbody>();
                    //}
                    //else
                    //{
                    //    Palm_r.AddComponent<FixedJoint>().connectedBody = Selected_R.GetComponent<Rigidbody>();
                    //}
                }
                /*
                if (Selected_R.GetComponent<FixedJoint>())
                {
                    if (Selected_R.GetComponent<FixedJoint>().connectedBody == null) jointR = Selected_R.GetComponent<FixedJoint>().connectedBody = Palm_r.GetComponent<Rigidbody>();
                    else jointR = Selected_R.AddComponent<FixedJoint>().connectedBody = Palm_r.GetComponent<Rigidbody>();
                }
                else
                {
                    jointR = Selected_R.AddComponent<FixedJoint>().connectedBody = Palm_r.GetComponent<Rigidbody>();
                }
                */
            }
          

            //Debug.Log(jointR);
            canMove_R = true;
            HapticExample.PlaySE(true);
            AudioSource.PlayClipAtPoint(grab_sound, Selected_R.transform.position, 0.5f);

        }
        else
        {

            AudioSource.PlayClipAtPoint(grab_sound2, transform.position, 0.01f);
        }
    }
    public void OnGrabbed_L()
    {     
        LocalgrabbedPoint_l = Camera.main.transform.InverseTransformVector(Palm_l.transform.position);
        if (Selected_L != null)
        {
            state_l = STATE.GRAB;
            grabbedPoint_l = positionMarker_l.transform.position;
            grabbedAngle_l = Palm_l.transform.localEulerAngles;

            InitialPoint_l = Selected_L.transform.position;
            InitialAngle_l = Selected_L.transform.localEulerAngles;

            if (Selected_L != null && Selected_L.tag == "MovableBlock")
            {
                if (Selected_L.GetComponent<BlockBase>().IsInGroup == true)
                {

                    GameObject parent = Selected_L.transform.parent.gameObject;
                    if (parent.GetComponent<GroupManager>().ChildIsGrabbed)
                    {
                        parent.GetComponent<GroupManager>().RemoveFromGroup(Selected_L);
                        //ここで、Removeされて動かせるようになったオブジェクトが来る。
                        OnGrabbed_L();//再帰呼び出しして、
                    }
                    else
                    {
                        parent.transform.SetParent(Palm_l.transform);
                        parent.GetComponent<GroupManager>().ChildIsGrabbed = true;
                    }

                }
                else
                {
                    Selected_L.transform.SetParent(Palm_l.transform);

                }
                


                //    Selected_L.GetComponent<BlockBase>().IsGrabbed = true;

                //    if (Selected_L.GetComponent<FixedJoint>())
                //    {
                //        if(Selected_L.GetComponent<FixedJoint>().connectedBody==null) jointL = Selected_L.GetComponent<FixedJoint>().connectedBody = Palm_l.GetComponent<Rigidbody>();
                //        else jointL = Selected_L.AddComponent<FixedJoint>().connectedBody = Palm_l.GetComponent<Rigidbody>();
                //    }
                //    else
                //    {
                //        jointL = Selected_L.AddComponent<FixedJoint>().connectedBody = Palm_l.GetComponent<Rigidbody>();
                //    }
                //}
            }

            canMove_L = true;
            AudioSource.PlayClipAtPoint(grab_sound, Selected_L.transform.position, 0.5f);
            HapticExample.PlaySE(false);

        }
        else
        {
            AudioSource.PlayClipAtPoint(grab_sound2, transform.position, 0.5f);
        }
    }
    public void OnReleased_R()
    {
        //HapticExample.StopStay(true);
        state_r = STATE.NONE;
        grabbedPoint_r = Vector3.zero;
        canMove_R = false;

        if (Selected_R != null && Selected_R.tag == "MovableBlock")
        {
            Selected_R.GetComponent<BlockBase>().IsGrabbed = false;
            if (Selected_R.GetComponent<BlockBase>().IsInGroup == true)
            {
                GameObject parent = Selected_R.transform.parent.gameObject;
                parent.GetComponent<GroupManager>().ChildIsGrabbed = false;
                parent.transform.SetParent(null);
            }else Selected_R.transform.SetParent(null);
          
            
            /*
            FixedJoint[] jointedItems = Selected_R.GetComponents<FixedJoint>();
            foreach (var item in jointedItems)
            {
                if (item.connectedBody == jointR)
                {
                    Destroy(item);
                    jointR = null;
                }
            }*/
            Selected_R.GetComponent<BlockBase>().AutoConnect();
            //Selected_R.GetComponent<BlockBase>().AutoMove();
            Selected_R = null;
        }
       
    }
    public void OnReleased_L()
    {
        //HapticExample.StopStay(false);
        state_l = STATE.NONE;
        //text.text = (LocalgrabbedPoint_l.z - Camera.main.transform.InverseTransformVector(Palm_l.transform.position).z).ToString("f3");

        grabbedPoint_l = Vector3.zero;
        canMove_L = false;
        if (Selected_L != null && Selected_L.tag == "MovableBlock")
        {
            Selected_L.GetComponent<BlockBase>().IsGrabbed = false;
            if (Selected_L.GetComponent<BlockBase>().IsInGroup == true)
            {
                GameObject parent = Selected_L.transform.parent.gameObject;
                parent.GetComponent<GroupManager>().ChildIsGrabbed = false;
                parent.transform.SetParent(null);
            }
            else Selected_L.transform.SetParent(null);
          
            //FixedJoint[] jointedItems = Selected_L.GetComponents<FixedJoint>();
            //foreach(var item in jointedItems)
            //{
            //    if (item.connectedBody == jointL)
            //    {
            //        Destroy(item);
            //        jointL = null;
            //    }               
            //}
            Selected_L.GetComponent<BlockBase>().AutoConnect();
            //Selected_L.GetComponent<BlockBase>().AutoMove();
            Selected_L = null;
        }
        /*else if (Selected_L != null && Selected_L.layer == LayerMask.NameToLayer("Photo"))
        {
            //ここにブロックを生成する処理をかく
            var photoChild = Selected_L.GetComponent<PhotoChild>();
            var pos = photoChild.transform.position + Selected_L.transform.TransformVector(new Vector3(0, 0, -5f));
            Selected_L.transform.localPosition = Vector3.zero;
            if (photoChild.CreateFlag)
            {
                var go = ResourceManager.Instance.BlockFactory(photoChild.spriteName, photoChild.sprite);
                go.transform.position = pos;
                go.transform.eulerAngles = photoChild.transform.parent.eulerAngles + new Vector3(0, 90, 0);

                Selected_L = null;

                if (GameManager.Instance.IsExperiment && GameManager.Instance.status == GAMESTATE.EXPERIMENT)
                {
                    RecordMaster.Instance.SaveBlockInfo(1, photoChild.spriteName, photoChild.transform.position.x.ToString(), photoChild.transform.position.y.ToString(), photoChild.transform.position.z.ToString(), "NA");
                }

                photoChild.Made(false);
            }
           
        }
        else if (Selected_L != null && Selected_L.tag == "MapParts")
        {
            Selected_L = null;
        }*/
    }
    
    public void DisplayToMovable_L()
    {
        var photoChild = Selected_L.GetComponent<PhotoChild>();
        var pos = photoChild.transform.position + Selected_L.transform.TransformVector(new Vector3(0, 0, -2f));
        Selected_L.transform.localPosition = Vector3.zero;
        var go = ResourceManager.Instance.BlockFactory(photoChild.spriteName, photoChild.sprite);
        go.transform.position = pos;
        go.transform.eulerAngles = photoChild.transform.parent.eulerAngles + new Vector3(0, 90, 0);
        Selected_L = go;
        //LocalgrabbedPoint_l = Camera.main.transform.InverseTransformVector(Palm_l.transform.position);
        grabbedPoint_l = positionMarker_l.transform.position;
        grabbedAngle_l = Palm_l.transform.localEulerAngles;

        InitialPoint_l = Selected_L.transform.position;
        InitialAngle_l = Selected_L.transform.localEulerAngles;

        canMove_L = true;
        AudioSource.PlayClipAtPoint(grab_sound, Selected_L.transform.position, 0.5f);
        HapticExample.PlaySE(false);
        photoChild.CreateFlag = false;
        photoChild.Made(false);

    }
    public void DisplayToMovable_R()
    {
        var photoChild = Selected_R.GetComponent<PhotoChild>();
        var pos = photoChild.transform.position + Selected_R.transform.TransformVector(new Vector3(0, 0, -2f));
        Selected_R.transform.localPosition = Vector3.zero;
        var go = ResourceManager.Instance.BlockFactory(photoChild.spriteName, photoChild.sprite);
        go.transform.position = pos;
        go.transform.eulerAngles = photoChild.transform.parent.eulerAngles + new Vector3(0, 90, 0);



        Selected_R = go;
        //LocalgrabbedPoint_l = Camera.main.transform.InverseTransformVector(Palm_l.transform.position);
        grabbedPoint_r = positionMarker_r.transform.position;
        grabbedAngle_r = Palm_r.transform.localEulerAngles;

        InitialPoint_r = Selected_R.transform.position;
        InitialAngle_r = Selected_R.transform.localEulerAngles;

        canMove_R = true;
        AudioSource.PlayClipAtPoint(grab_sound, Selected_R.transform.position, 0.5f);
        HapticExample.PlaySE(false);
        photoChild.CreateFlag = false;
        photoChild.Made(false);

    }

    public enum STATE
    {
        NONE,
        GRAB
    }
}
