using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Blocks
{
    public class BlockBase : MonoBehaviour
    {
        
        public static BlockBase Instance;
        public bool IsGrabbed = false;
        public bool IsInGroup = false;
        private Vector3 MyScale;


       // public List<GameObject> pivots = new List<GameObject>();//(pivot,connectedPivot)
        public List<GameObject> surfaceWithPivots = new List<GameObject>();
        public Dictionary<GameObject, GameObject> JointInformation = new Dictionary<GameObject, GameObject>();
        /*jointInformation<this.pivot_name,other.pivot_name>*/
        /*ForPivotCollider*/
        public GameObject connectableObject;
        public bool IsConnectable;
        public GameObject connectablePivot;
        /******************/


        /**一応残し**/
        public GameObject _object;
        private GameObject currentConnector;

        void Start()
        {
            MyScale = this.gameObject.transform.localScale;
        }

        void Update()
        {
            this.gameObject.transform.localScale=MyScale;
        }


        void OnTriggerStay(Collider col)
        {
            if (this.gameObject.tag == "MovableBlock")
            {
                if (col.gameObject.name == "Detector_R")
                {
                    Hand.Instance.SetSelectedObject(_object, true);

                }
                else if (col.gameObject.name == "Detector_L")
                {
                    Hand.Instance.SetSelectedObject(_object, false);

                }
                /*if(col.gameObject.tag == "MovableBlock")
                {
                    if (col.gameObject.GetComponent<BlockBase>())
                    {
                        connectableObject = col.gameObject;
                    }
                }*/
                #region For connecting to MovableBlock & connector
                /*
                else if (col.gameObject.tag == "MovableBlock" || col.gameObject.tag == "Connector")
                {
                    if (GameManager.Instance.status == GAMESTATE.IN_WORKS)
                    {
                        var connector = col.gameObject.GetComponent<ConnectorController>();
                        if (connector)
                        {
                            if (currentConnector == null)
                            {
                                if (connector.CanAttach())
                                {
                                    connector.CloseTo(this.gameObject);
                                    currentConnector = col.gameObject;
                                    HighLight(col.gameObject);
                                }
                            }
                            else
                            {
                                if (currentConnector != col.gameObject)
                                {
                                    if (connector.CanAttach())
                                    {
                                        currentConnector.GetComponent<ConnectorController>().Away(gameObject);
                                        connector.CloseTo(this.gameObject);
                                        currentConnector = col.gameObject;
                                        HighLight(col.gameObject);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Debug.Log("Error");
                        }
                    }
                    else
                    {
                        var connector = col.gameObject.GetComponent<ConntectorController>();
                        if (connector)
                        {
                            if (currentConnector == null)
                            {
                                if (connector.CanAttach())
                                {
                                    connector.CloseTo(this.gameObject);
                                    currentConnector = col.gameObject;
                                    HighLight(col.gameObject);
                                }
                            }
                            else
                            {
                                if (currentConnector != col.gameObject)
                                {
                                    if (connector.CanAttach())
                                    {
                                        currentConnector.GetComponent<ConntectorController>().Away(gameObject);
                                        connector.CloseTo(this.gameObject);
                                        currentConnector = col.gameObject;
                                        HighLight(col.gameObject);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Debug.Log("Error");
                        }
                    }
                }
                */
                #endregion
                /*
                if (col.gameObject.layer == LayerMask.NameToLayer("OculusTouch"))
                {
                }
                else if (col.gameObject.layer == LayerMask.NameToLayer("Leapmotion"))
                {

                }*/
            }

        }

        void OnTriggerExit(Collider col)
        {
            if (this.gameObject.tag == "MovableBlock")
            {
                if (col.gameObject.name == "Detector_R")
                {
                    Hand.Instance.CancelSelectedObject(_object, true);
                }
                else if (col.gameObject.name == "Detector_L")
                {
                    Hand.Instance.CancelSelectedObject(_object, false);
                }
                /*if (col.gameObject == connectableObject)
                {
                    connectableObject = null;
                }*/
                #region for detaching from connector
                /*
                else if (col.gameObject.tag == "Connector")
                {
                    if (GameManager.Instance.status == GAMESTATE.IN_WORKS)
                    {
                        var conn = col.gameObject.GetComponent<ConnectorController>();
                        if (currentConnector == col.gameObject)
                        {
                            currentConnector = null;

                        }
                    }
                    else
                    {
                        var conn = col.gameObject.GetComponent<ConntectorController>();
                        if (currentConnector == col.gameObject)
                        {
                            currentConnector = null;

                        }
                        conn.Remove(this.gameObject);
                    }
                    //conn.Away(gameObject);
                    //if (conn.AttachedObject == gameObject)
                    //{

                    //    if(!conn.CanAttach())
                    //    {
                    //        conn.Remove(gameObject);
                    //    }

                    //}
                }
                else if (col.gameObject.tag == "MovableBlock")
                {
                    if (GameManager.Instance.status == GAMESTATE.IN_WORKS)
                    {
                        var conn = col.gameObject.GetComponent<ConnectorController>();
                        if (currentConnector == col.gameObject)
                        {
                            currentConnector = null;

                        }
                        //  conn.Remove(gameObject);
                    }
                    else
                    {
                        var conn = col.gameObject.GetComponent<ConntectorController>();
                        if (currentConnector == col.gameObject)
                        {
                            currentConnector = null;

                        }
                        conn.Remove(this.gameObject);
                    }

                }
                */
                #endregion

                if (col.gameObject.layer == LayerMask.NameToLayer("OculusTouch"))
                {

                }
                else if (col.gameObject.layer == LayerMask.NameToLayer("Leapmotion"))
                {

                }
            }
        }

       
        public virtual void AutoConnect()
        {
            if (connectableObject != null && connectablePivot != null&&connectableObject.tag=="MovableBlock")
            {

                this.gameObject.AddComponent<JointObjects>().Joint(connectablePivot, connectableObject,connectableObject.transform);
                Destroy(this.gameObject.GetComponent<JointObjects>());        
            }
        }

        public void ResetConnectable()
        {
            connectableObject = null;
            connectablePivot = null;
            IsConnectable = false;
        }
        /**一応残し**/
        public void AutoMove()
        {

            if (currentConnector != null)
            {

                if (GameManager.Instance.status == GAMESTATE.IN_WORKS)
                {
                    var conn = currentConnector.GetComponent<ConnectorController>();
                    conn.SetChild(GetComponent<ContentBase>());
                }
                else
                {
                    var conn = currentConnector.GetComponent<ConntectorController>();
                    conn.SetChild(GetComponent<ContentBase>());
                }

            }
        }
        private void HighLight(GameObject go)
        {
            //var mat = go.transform.GetChild(0).GetComponent<Renderer>().material;

        }


    }
}