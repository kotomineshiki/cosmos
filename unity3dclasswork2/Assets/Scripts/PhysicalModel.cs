using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalModel : MonoBehaviour {
    public float mass;
    public Vector3 speed;
    public float radius;
    public float distance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetPara(float M,float r, float d)
    {
        mass = M;
    //    speed.z = s;
        radius = r;
        distance = d;

        this.GetComponent<SphereCollider>().radius = radius;
        this.transform.localScale = new Vector3(radius, radius, radius);
        transform.position =new Vector3(50* distance,0,0);

    }

}
