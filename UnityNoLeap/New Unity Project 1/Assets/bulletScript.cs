using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

	public int team = 3;
	public float velocity = 3.0f;
	public float force = 5.0f;

	float lifeTime = 10.0f;
	float deathtime;
	public int damage = 1;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().velocity = transform.forward * velocity;
		GetComponent<Rigidbody> ().AddForce(transform.forward * force);
		deathtime = Time.time + lifeTime;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (Vector3.forward * Time.deltaTime * velocity);
		if (Time.time >= deathtime){
			Destroy (this.gameObject);
		}

	}

	/*void OnTriggerEnter(Collider other){
		//if (this.team == 3) {return;}
		GameObject collidingGO = other.gameObject;

		if(collidingGO.transform.tag.Equals("Actor")){
			unitScript collidingScript = collidingGO.transform.parent.gameObject.GetComponent<unitScript>();
			if(collidingScript.team != this.team){
				collidingScript.takeDamage(damage, team);
				Destroy(this.gameObject);
			}
		}
		else if(collidingGO.transform.tag.Equals("Obstacle")){
			Debug.Log ("bullet collided with obstacle");
			Destroy(this.gameObject);
		}
	}*/


}
