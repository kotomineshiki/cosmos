using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarController : MonoBehaviour {
    public GameObject Sun;
    public GameObject[] SolarPlanet;
	// Use this for initialization
	void Start () {
        SolarPlanet[0].GetComponent<PhysicalModel>().SetPara(0.0553f,0.383f,3.87f);//质量半径距离
        SolarPlanet[1].GetComponent<PhysicalModel>().SetPara(0.815f,0.950f,7.23f);
        SolarPlanet[2].GetComponent<PhysicalModel>().SetPara(1,1,10);
        SolarPlanet[3].GetComponent<PhysicalModel>().SetPara(0.107f, 0.532f, 15.24f);
        SolarPlanet[4].GetComponent<PhysicalModel>().SetPara(95.159f,9.14f,52.03f);
        SolarPlanet[5].GetComponent<PhysicalModel>().SetPara(317.83f,10.97f,95.39f);
        SolarPlanet[6].GetComponent<PhysicalModel>().SetPara(14.536f,3.98f,191.8f);
        //Sun.GetComponent<PhysicalModel>().SetPara(332837f, 109.25f, 0);
        Sun.GetComponent<PhysicalModel>().SetPara(332837f, 10.25f, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
