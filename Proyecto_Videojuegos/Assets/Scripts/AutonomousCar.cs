using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomousCar : MonoBehaviour
{

	public Transform[] targets;
	public int targetIndex;
	public List<Vector3> _targets = new List<Vector3>();
	public Vector3 _target;

	public float Speed;


    public GameObject ObjectToRotate;
    public float DegreesOffset = 0;
    public bool CanMove;
    public int racePoints;
    //public Vector3 vectorToTarget;


    // Start is called before the first frame update
    void Start()
    {
        foreach(var target in targets){
        	_targets.Add(target.position);
        }
        

        SetTarget(_targets[targetIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove == false)
        {
            return;
        }
        else
        {
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

    public void setTargetIndex(int index) {
        targetIndex = index;
    }
    public int getTargetIndex() {
        return targetIndex;
    }
}
