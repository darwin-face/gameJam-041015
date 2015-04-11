using UnityEngine;
using System.Collections;

public class wander : MonoBehaviour {

	public bool isAllowedToWander = false;
	public Vector3 center;
	public float radius = 5.0f;
	public float waitTimeAverage = 1.5f;
	public float waitTimeFudgeFactor = 0.2f;
	public Vector3 wanderWaypoint;

	float minWaitTime;
	float maxWaitTime;
	unitScript thisUnitScript;
	float endWaitTime = 0.0f;

	// Use this for initialization
	void Start () {
		minWaitTime = waitTimeAverage - waitTimeFudgeFactor;
		maxWaitTime = waitTimeAverage + waitTimeFudgeFactor;
		thisUnitScript = GetComponent<unitScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isAllowedToWander) {
			if(Time.time >= endWaitTime){
				GetNewWanderWaypoint();
			}
			thisUnitScript.SetNewDestination(wanderWaypoint, true);
		}
	}

	void GetNewWanderWaypoint(){
		Vector3 newWaypoint;
		newWaypoint.x = Random.Range(center.x - radius, center.x + radius);
		newWaypoint.y = 0;
		newWaypoint.z = Random.Range(center.z - radius, center.z + radius);
		wanderWaypoint = newWaypoint;

		//endWaitTime = Time.time + waitTime;
		//slightly randomize the next waitTime
		endWaitTime = Time.time + Random.Range (minWaitTime, maxWaitTime);
	}

	public void StartWandering(Vector3 center){
		isAllowedToWander = true;
		this.center = center;
	}

	public void StopWandering(){
		isAllowedToWander = false;
	}
}
