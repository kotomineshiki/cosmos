using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySimulate : MonoBehaviour {
    public List<GameObject> graviEffectWith;
    public Vector3 TotalGravitationalForce;
	// Use this for initialization
	void Start () {
    //    this.GetComponent<PhysicalModel>().speed=startsetspeed();
	}
	public Vector3 startsetspeed()
    {
        this.GetComponent<PhysicalModel>().speed.z = Mathf.Sqrt(graviEffectWith[0].GetComponent<PhysicalModel>().mass /
    Vector3.Distance(this.transform.position, graviEffectWith[0].transform.position)
    );
        return new Vector3(0, 0, this.GetComponent<PhysicalModel>().speed.z);
    }
    public void setSpeed(Vector3 input)
    {
        this.GetComponent<PhysicalModel>().speed = input;
    }
	// Update is called once per frame
	void FixedUpdate () {
        TotalGravitationalForce.Set(0, 0, 0);
        foreach (GameObject i in graviEffectWith)
        {

            TotalGravitationalForce += -(i.GetComponent<PhysicalModel>().mass) /
                (Vector3.Distance(this.transform.position, i.transform.position) * Vector3.Distance(this.transform.position, i.transform.position) * Vector3.Distance(this.transform.position, i.transform.position))
                * (this.transform.position - i.transform.position);
        }
        this.GetComponent<PhysicalModel>().speed += TotalGravitationalForce*Time.deltaTime;
        this.transform.position+=(this.GetComponent<PhysicalModel>().speed)*Time.deltaTime;
	}
}
