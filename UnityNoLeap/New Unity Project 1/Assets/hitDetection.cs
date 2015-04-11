using UnityEngine;
using System.Collections;

public class hitDetection : MonoBehaviour {

	unitScript parentUnit;

	void Start(){
		parentUnit = transform.parent.gameObject.GetComponent<unitScript> ();
	}

	void OnTriggerEnter(Collider other){
		if(other.transform.tag.Equals("Projectile")){
			Debug.Log("projectile hit something");
			if(other.GetComponent<bulletScript>().team != parentUnit.team){
				parentUnit.takeDamage(other.GetComponent<bulletScript>().damage);
				Destroy(other.gameObject);
			}
		}
	}
}
