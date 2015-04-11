using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class playerScript : MonoBehaviour {

	public int resources = 10;
	public string playerName = "SpaceCamel";
	public int numOfUnits;

	public List<GameObject> playerUnits;
	public List<GameObject> selectedUnits;

	Rect selectBox = new Rect ();
	Vector3 startPoint;
	Vector3 endPoint;
	
	bool mouse_pressed = false;

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
		SelectUnits ();
		//detetct right clicks
		if (Input.GetMouseButtonDown (1))
			MouseOrderUnitsToMove ();
	}

	//orders all units in selectedUnits to move to mouse position
	void SelectUnits() {
		if (mouse_pressed == true) {
			endPoint = Input.mousePosition;
			selectBox.xMin = Mathf.Min(startPoint.x, endPoint.x);
			selectBox.yMin = Mathf.Min(startPoint.y, endPoint.y);
			selectBox.xMax = Mathf.Max(startPoint.x, endPoint.x);
			selectBox.yMax =  Mathf.Max(startPoint.y, endPoint.y);
			
		}
		if (Input.GetMouseButtonDown (0)) {
			startPoint = Input.mousePosition;
			selectedUnits.Clear();
			mouse_pressed = true;
			
		} else if (Input.GetMouseButtonUp (0)) {
			mouse_pressed = false;
			for(int i = 0; i < playerUnits.Count; i++) {
				GameObject currUnit = playerUnits[i];
				Vector3 screenPos = Camera.main.WorldToScreenPoint(currUnit.transform.position);
				screenPos.z = 0.0f;
				if(selectBox.Contains (screenPos)) {
					selectedUnits.Add(currUnit);
				}
			}
			selectBox.xMin = 0.0f;
			selectBox.yMin = 0.0f;
			selectBox.xMax = 0.0f;
			selectBox.yMax = 0.0f;
		}
	}


	void MouseOrderUnitsToMove(){
		//find where the mouse is in 3D space
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 100.0f)){
			Vector3 hitPoint = hit.point;

			//iterate through array, set each object's target to hitpoint
			for(int i = 0; i < selectedUnits.Count; i++){
				unitScript currentUnitScript = selectedUnits[i].GetComponent<unitScript>();
				currentUnitScript.SetNewDestination(hitPoint, false);
			}
		}
	}

	//adds resources to this player
	public void AddResources(int resourcesToAdd){
		resources += resourcesToAdd;
	}
	
}
