using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeControllerBlockUI: MonoBehaviour
{
    public Hand hand;
    public GameObject Hand_Right_Touch;
    public GameObject Hand_Left_Touch;
    public GameObject Palm_r_Touch;
    public GameObject Palm_l_Touch;
    public GameObject positionMarker_r_Touch;
    public GameObject positionMarker_l_Touch;

    public GameObject Leap;
    public GameObject Hand_Right_Leap;
    public GameObject Hand_Left_Leap;
    public GameObject Palm_r_Leap;
    public GameObject Palm_l_Leap;
    public GameObject positionMarker_r_Leap;
    public GameObject positionMarker_l_Leap;
    // Use this for initialization
    void Start()
    {
        Leap.SetActive(true);
        Hand_Right_Leap.SetActive(true);
        Hand_Left_Leap.SetActive(true);
        hand.Palm_r = Palm_r_Leap;
        hand.Palm_l = Palm_l_Leap;
        hand.positionMarker_r = positionMarker_r_Leap;
        hand.positionMarker_l = positionMarker_l_Leap;
        Hand_Right_Touch.SetActive(false);
        Hand_Left_Touch.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) || OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
            Leap.SetActive(false);
            hand.Palm_r = Palm_r_Touch;
            hand.positionMarker_r = positionMarker_r_Touch;
            Hand_Right_Leap.SetActive(false);
            Hand_Right_Touch.SetActive(true);


            hand.Palm_l = Palm_l_Touch;
            hand.positionMarker_l = positionMarker_l_Touch;
            Hand_Left_Leap.SetActive(false);
            Hand_Left_Touch.SetActive(true);
        }
        if (OVRInput.Get(OVRInput.RawButton.RThumbstick) && OVRInput.GetDown(OVRInput.RawButton.LThumbstick))
        {
            Leap.SetActive(true);
            hand.Palm_r = Palm_r_Leap;
            hand.positionMarker_r = positionMarker_r_Leap;
            Hand_Right_Touch.SetActive(false);
            Hand_Right_Leap.SetActive(true);

            hand.Palm_l = Palm_l_Leap;
            hand.positionMarker_l = positionMarker_l_Leap;
            Hand_Left_Touch.SetActive(false);
            Hand_Left_Leap.SetActive(true);
        }
    }
}
