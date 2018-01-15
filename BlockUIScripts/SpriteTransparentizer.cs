using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTransparentizer : MonoBehaviour {
    [SerializeField]
    private float changeRed = 1.0f;
    [SerializeField]
    private float changeGreen = 1.0f;
    [SerializeField]
    private float cahngeBlue = 1.0f;
    [SerializeField]
    private float cahngeAlpha = 0.01f;
	// Use this for initialization
	void Start () {
        this.GetComponent<SpriteRenderer>().color = new Color(changeRed, changeGreen, cahngeBlue, cahngeAlpha);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
