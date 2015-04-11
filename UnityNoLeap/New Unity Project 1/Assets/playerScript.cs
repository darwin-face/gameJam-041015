using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {

	public GameObject[] selectedUnits;
	public int resources = 10;
	public string playerName = "SpaceCamel";
	public int numOfUnits;

	public bool isHuman = false;

	/*possible other variables
	 * list of owned asteroids/mining things to determine bonus resources
	 * int bonusResources or resourcePoints
	 * 
	 * variables that may be used for AI to determine strength of player
	 * int numOfShips
	 * int techLevel
	 * int numOfUpgrades
	 * float actionsPerMinute
	 */


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//detetct right clicks
		if (Input.GetMouseButtonDown (1))
			MouseOrderUnitsToMove ();
	}

	//orders all units in selectedUnits to move to mouse position
	void MouseOrderUnitsToMove(){
		//find where the mouse is in 3D space
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 100.0f)) {
			Vector3 hitPoint = hit.point;
			
			//iterate through array, set each object's target to hitpoint
			for (int i = 0; i < selectedUnits.Length; i++) {
				GameObject currentUnit = selectedUnits [i];
				currentUnit.GetComponent<unitScript> ().target = hitPoint;
			}
		}
	}

	//adds resources to this player
	public void AddResources(int resourcesToAdd){
		resources += resourcesToAdd;
	}
	
}
