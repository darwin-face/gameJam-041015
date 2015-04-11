using UnityEngine;
using System.Collections;

public class playerInput : MonoBehaviour {

	public GameObject[] selectedUnits;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			//find where the mouse is in 3D space
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 100.0f)){
				Vector3 hitPoint = hit.point;

				//iterate through array, set each object's target to hitpoint
				for(int i = 0; i < selectedUnits.Length; i++){
					GameObject currentUnit = selectedUnits[i];
					currentUnit.GetComponent<unitScript>().target = hitPoint;
				}
			}
		}
	}
	
}
