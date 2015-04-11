using UnityEngine;
using System.Collections;

public class unitScript : MonoBehaviour {

	public GameObject target;

	public int health;
	public float speed;
	public int team;
	public int attackDmg;
	public float attackSpeed;
	public float threshold = 1.0f;

	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}

	
	// Update is called once per frame
	void Update () {
		agent.SetDestination (target.transform.position);
		if (target.transform.position.x - gameObject.transform.position.x < threshold) {
			Destroy(this.gameObject);
		}
	}


}
