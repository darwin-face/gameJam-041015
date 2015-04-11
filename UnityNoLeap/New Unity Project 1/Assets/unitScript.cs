using UnityEngine;
using System.Collections;

public class unitScript : MonoBehaviour {

	public Vector3 target;
	public int team;
	public GameObject bullet;
	public int health = 10;

	bool isAllowedToWander = false;
	float speed;
	int attackDmg;
	float fireRate = 2.0f;
	float nextAllowedFireTime = 0.0f;
	float waypointThreshold = 1.0f;

	//public float threshold = 1.0f;

	NavMeshAgent agent;
	wander wanderScript;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		wanderScript = GetComponent<wander> ();
		//target = transform.position;
		SetNewDestination (target, false);
	}
	
	// Update is called once per frame
	void Update () {
		//if reached the target, begin wandering
		if(Vector3.Distance(transform.position, target) < waypointThreshold){
			StartWandering();
		}
	}

	void OnTriggerStay(Collider other){
		GameObject collidindGO = other.gameObject;
		//error below?
		unitScript collidingScript = collidindGO.GetComponent<unitScript> ();
		if (collidingScript != null) {
			if(collidingScript.team != this.team){
				if(Time.time >= nextAllowedFireTime){
					//KILL IT
					GameObject currentBullet = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
					currentBullet.transform.LookAt(collidindGO.transform);
					currentBullet.GetComponent<bulletScript>().team = this.team;
					//set next fire time
					nextAllowedFireTime = Time.time + fireRate;
				}
			}
		}
	}

	public void takeDamage(int damage, int team){
		Debug.Log ("unit on team " + this.team + " took damage from a bullet on team " + team);
		health -= damage;
		if (health <= 0) {
			Destroy (this.gameObject);
			Debug.Log( " unit on team " + team + " destroyed!");
		}
	}

	public void SetNewDestination(Vector3 position, bool isWanderDestination){
		target = position;
		if (isWanderDestination && isAllowedToWander) {
			agent.SetDestination(target);
		}
		else {
			StopWandering();
			agent.SetDestination(target);
		}
	}

	void StartWandering(){
		isAllowedToWander = true;
		wanderScript.StartWandering (transform.position);
	}

	public void StopWandering(){
		isAllowedToWander = false;
		wanderScript.StopWandering ();
	}
}
