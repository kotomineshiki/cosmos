using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarController : MonoBehaviour {
    public GameObject SunPrefabs;
    public GameObject Sun;
    public GameObject[] SolarPlanetPrefabs;
    public GameObject[] SolarPlanet;

    public GameObject MoonPrefab;
    public GameObject Moon;
    Quaternion q;
    // Use this for initialization
    void Awake () {
        SolarPlanet = new GameObject[9];
        Sun = GameObject.Instantiate(SunPrefabs);
        for (int i=0; i < SolarPlanetPrefabs.Length; ++i)
        {
            SolarPlanet[i] = GameObject.Instantiate(SolarPlanetPrefabs[i]);
            SolarPlanet[i].GetComponent<GravitySimulate>().graviEffectWith.Add(Sun);
        //    SolarPlanet[i].GetComponent<GravitySimulate>().startsetspeed();
        }
        /*此处初始化行星*/
        SolarPlanet[0].GetComponent<PhysicalModel>().SetPara(0.0553f,0.383f,3.87f);//质量半径距离
        SolarPlanet[1].GetComponent<PhysicalModel>().SetPara(0.815f,0.950f,7.23f);
        SolarPlanet[2].GetComponent<PhysicalModel>().SetPara(1,1,10);
        SolarPlanet[3].GetComponent<PhysicalModel>().SetPara(0.107f, 0.532f, 15.24f);


     //   SolarPlanet[4].GetComponent<PhysicalModel>().SetPara(95.159f,9.14f,52.03f);
       // SolarPlanet[5].GetComponent<PhysicalModel>().SetPara(317.83f,10.97f,95.39f);
     //   SolarPlanet[6].GetComponent<PhysicalModel>().SetPara(14.536f,3.98f,191.8f);
        //Sun.GetComponent<PhysicalModel>().SetPara(332837f, 109.25f, 0);
        Sun.GetComponent<PhysicalModel>().SetPara(33237f, 10.25f, 0);

        /*下面设定初始速度*/
        for (int i = 0; i < SolarPlanetPrefabs.Length; ++i)
        {
            SolarPlanet[i].GetComponent<GravitySimulate>().setSpeed(planetspeed(i));
            SolarPlanet[i].GetComponent<selfRotate>().setRotateAxis(selfrotateAxis(i));
        }


        /*下面设定月球相关*/
        Moon = Instantiate(MoonPrefab);
        Moon.GetComponent<GravitySimulate>().graviEffectWith.Add(SolarPlanet[2]);
        Moon.GetComponent<GravitySimulate>().graviEffectWith.Add(Sun);
        SolarPlanet[2].GetComponent<GravitySimulate>().graviEffectWith.Add(Moon);
        Moon.GetComponent<PhysicalModel>().GetComponent<PhysicalModel>().SetPara(0.18f, 0.1f, 10 + 0.0256f);
        Moon.GetComponent<GravitySimulate>().setSpeed(Moon.GetComponent<GravitySimulate>().startsetspeed()+SolarPlanet[2].GetComponent<GravitySimulate>().startsetspeed());




    }
	Vector3 planetspeed(int index)//这个函数用来存储各种行星的初始速度
    {
        Vector3 theplanetspeed=SolarPlanet[index].GetComponent<GravitySimulate>().startsetspeed();

        switch (index)
        {
            case 0:
                q = Quaternion.AngleAxis(7.01f,new Vector3(1,0,0));
                break;
            case 1:
                q = Quaternion.AngleAxis(3.39f, new Vector3(1, 0, 0));
                break;
            case 2:
                q = Quaternion.AngleAxis(0.00f, new Vector3(1, 0, 0));
                break;
            case 3:
                q = Quaternion.AngleAxis(1.85f, new Vector3(1, 0, 0));
                break;
            case 4:
                q = Quaternion.AngleAxis(1.31f, new Vector3(1, 0, 0));
                break;
            case 5:
                q = Quaternion.AngleAxis(2.49f, new Vector3(1, 0, 0));
                break;
            case 6:
                q = Quaternion.AngleAxis(0.77f, new Vector3(1, 0, 0));
                break;
            case 7:
                q = Quaternion.AngleAxis(1.77f, new Vector3(1, 0, 0));
                break;
            case 8:
                q = Quaternion.AngleAxis(1.85f, new Vector3(1, 0, 0));
                break;
        }
        Debug.Log(q * theplanetspeed);
        return (q*theplanetspeed);
    }

    Vector3 selfrotateAxis(int index)//这个函数用来存储各种行星的初始自传角
    {
        

        switch (index)
        {
            case 0:
                q = Quaternion.AngleAxis(28f, new Vector3(1, 0, 0));
                break;
            case 1:
                q = Quaternion.AngleAxis(177f, new Vector3(1, 0, 0));
                break;
            case 2:
                q = Quaternion.AngleAxis(23.45f, new Vector3(1, 0, 0));
                break;
            case 3:
                q = Quaternion.AngleAxis(23.98f, new Vector3(1, 0, 0));
                break;
            case 4:
                q = Quaternion.AngleAxis(3.08f, new Vector3(1, 0, 0));
                break;
            case 5:
                q = Quaternion.AngleAxis(26.73f, new Vector3(1, 0, 0));
                break;
            case 6:
                q = Quaternion.AngleAxis(97.92f, new Vector3(1, 0, 0));
                break;
            case 7:
                q = Quaternion.AngleAxis(28.8f, new Vector3(1, 0, 0));
                break;
            case 8:
                q = Quaternion.AngleAxis(1.85f, new Vector3(1, 0, 0));
                break;
        }
        Debug.Log(q * new Vector3(0, 1, 0));
        return (q * new Vector3(0,1,0));
    }

    
}
