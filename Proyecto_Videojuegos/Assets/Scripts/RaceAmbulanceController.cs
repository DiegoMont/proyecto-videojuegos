using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceAmbulanceController : MonoBehaviour
{
    public GameObject sound;
	public Transform target;
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
        //_target = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!solicited) {
            return;
        }
        if (solicited) {
            Move();  
        }
        
    }

    public void callAmbulance(Transform target) {
        solicited = true;
        _target = target.position;
        Instantiate(sound, transform.position, transform.rotation);
    }

    void Move() {
    	float distance = Vector3.Distance(gameObject.transform.position, _target);
        if (distance <= 0){
            sceneManager.GetComponent<RaceSceneManagerController>().LoadGameOverScene();
        }
    	gameObject.transform.position = Vector3.Lerp(transform.position, _target, (Time.deltaTime*Speed)/distance);
    }
/*
    void Rotate(){
        Vector3 vectorToTarget = target.transform.position - ObjectToRotate.transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x)*Mathf.Rad2Deg;
        Quaternion  q = Quaternion.AngleAxis(angle + DegreesOffset, ObjectToRotate.transform.forward);
        ObjectToRotate.transform.rotation = Quaternion.Slerp(ObjectToRotate.transform.rotation, q, Time.deltaTime * 1000);
    }
  */  

}
