using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfRotate : MonoBehaviour {
    public Vector3 RotateAxis;
    public float RotateSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(RotateAxis*RotateSpeed);
	}
    public void setRotateAxis(Vector3 input)
    {
        RotateAxis = input;
    }
}
