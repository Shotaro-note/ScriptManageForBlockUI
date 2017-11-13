
/********************************************
 * This script need to check grasping action
 *********************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVRTouchSample;
namespace OVRTouchSample
{

    public class GrabberForBlockUI : MonoBehaviour
    {

        public bool isRightHand = true;
        // Grip trigger thresholds for picking up objects, with some hysteresis.
        public const float THRESH_GRAB_BEGIN = 0.55f;
        public const float THRESH_GRAB_END = 0.35f;
        // Velocity threshold to distinguish between a throw and a drop.
        public const float THRESH_THROW_SPEED = 1.0f;
        [SerializeField]
        private Transform m_gripTransform = null;
        // Use this for initialization
        private Quaternion m_anchorOffsetRotation;
        private Vector3 m_anchorOffsetPosition;
        private VelocityTracker m_velocityTracker = null;
        private Vector3 m_lastPos;
        private Quaternion m_lastRot;
        private Transform m_parentTransform;

        // Avatar to pull hand poses from.
        [SerializeField]
        private OvrAvatar m_avatar;

        // Should be OVRInput.Controller.LTouch or OVRInput.Controller.RTouch.
        [SerializeField]
        private OVRInput.Controller m_controller;

        private float m_prevFlex;
        private float i_prevFlex;



        private void Awake()
        {
            m_anchorOffsetPosition = transform.localPosition;
            m_anchorOffsetRotation = transform.localRotation;
        }



        private void Start()
        {
            m_velocityTracker = this.GetComponent<VelocityTracker>();
            m_lastPos = transform.position;
            m_lastRot = transform.rotation;
            m_parentTransform = gameObject.transform.parent.transform;

            Vector3 gripOff = m_gripTransform.transform.position - transform.position;
            m_diff = Quaternion.Inverse(transform.rotation) * gripOff;
        }
        Vector3 m_diff;
        private void Update()
        {
            if (m_avatar != null && m_avatar.Driver != null)
            {
                float prevFlex = m_prevFlex;
                float prevFlex_i = i_prevFlex;

                OvrAvatarDriver.PoseFrame frame;
                m_avatar.Driver.GetCurrentPose(out frame);
                OvrAvatarDriver.ControllerPose pose = m_controller == OVRInput.Controller.LTouch ? frame.controllerLeftPose : frame.controllerRightPose;
                // Update values from inputs
                m_prevFlex = pose.indexTrigger;
                CheckForGrabOrRelease(prevFlex);

            }
        }


        private void CheckForGrabOrRelease(float prevFlex)
        {
            if ((m_prevFlex >= THRESH_GRAB_BEGIN) && (prevFlex < THRESH_GRAB_BEGIN))
            {

                if (isRightHand == true)
                {
                    Hand.Instance.OnGrabbed_R();

                }
                else
                {
                    Hand.Instance.OnGrabbed_L();
                }
            }
            else if ((m_prevFlex <= THRESH_GRAB_END) && (prevFlex > THRESH_GRAB_END))
            {

                if (isRightHand == true)
                {
                    Hand.Instance.OnReleased_R();
                }
                else
                {
                    Hand.Instance.OnReleased_L();
                }
            }
           
        }
    }
}