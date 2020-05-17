using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RaceNewAmbulanceController : MonoBehaviour
{
    
	public GameObject sound;
	public Transform[] targets;
	public int targetIndex;
	public List<Vector3> _targets = new List<Vector3>();
	public Vector3 _target;

	public float Speed;


    public GameObject ObjectToRotate;
    public float DegreesOffset = 0;

    public bool solicited;
    public GameObject sceneManager;
    // Start is called before the first frame update
    void Start()
    {
      sceneManager = GameObject.FindWithTag("RaceSceneManager");
      solicited = false;  
    }

    // Update is called once per frame
    void Update()
    {
        if (!solicited) {
            return;
        }
        if (solicited) {
            Move();
            Rotate();  
        }
    }

    void SetTarget(Vector3 target) {
    	_target = target;
    }

    void Move(){
    	float distance = Vector3.Distance(gameObject.transform.position, _target);
    	if(distance<=0) {
    		targetIndex++;
    		targetIndex = targetIndex % _targets.Count;
    		SetTarget(_targets[targetIndex]);

    	} else {
    		gameObject.transform.position = Vector3.Lerp(transform.position, _target, (Time.deltaTime*Speed)/distance);
    	}

    	

    }

    void Rotate(){
        Vector3 vectorToTarget = targets[targetIndex].transform.position - ObjectToRotate.transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x)*Mathf.Rad2Deg;
        Quaternion  q = Quaternion.AngleAxis(angle + DegreesOffset, ObjectToRotate.transform.forward);
        ObjectToRotate.transform.rotation = Quaternion.Slerp(ObjectToRotate.transform.rotation, q, Time.deltaTime * 1000);
    }

    public void callAmbulance(string s) {
        //solicited = true;

        if (s == "Ruta1") {
        	GameObject[] rutas1 = GameObject.FindGameObjectsWithTag("AR1");
        	GameObject[] rutas11 = flipTargets(rutas1);
        	targets = new Transform[rutas11.Length];
        	for (int i = rutas11.Length-1; i >= 0; i--) {
            	targets[i] = rutas11[i].GetComponent<Transform>();
            	
        	}
        	//SetTarget(_targets[targetIndex]);
        }

        foreach(var target in targets){
        	_targets.Add(target.position);
        }
        SetTarget(_targets[targetIndex]);

        solicited = true;
        //SetTarget(_targets[targetIndex]);
        Instantiate(sound, transform.position, transform.rotation);
    }

    public GameObject[] flipTargets(GameObject[] rutas1) {
    	int length = rutas1.Length;
    	GameObject[] flippedRutas = new GameObject[length];
    	
    	for (int i = 0; i < length / 2; i++) {
   			GameObject tmp = rutas1[i];
   			rutas1[i] = rutas1[length - i - 1];
   			rutas1[length - i - 1] = tmp;
		}

		return rutas1;
    }

    //Cuando llegue
    //sceneManager.GetComponent<RaceSceneManagerController>().LoadGameOverScene();
}
