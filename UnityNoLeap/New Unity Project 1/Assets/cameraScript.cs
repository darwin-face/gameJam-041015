using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {
	public float xSpeed = 40.0f;
	public float ySpeed  = 30.0f;
	public float minX = 5;
	public float minY = 20;
	public float maxX = 40;
	public float maxY = 40;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		float xAxis = Input.GetAxis("Horizontal") * xSpeed * Time.deltaTime;
		float yAxis = Input.GetAxis("Vertical") * ySpeed * Time.deltaTime;
		float curX = this.transform.position.x;
		float curY = this.transform.position.y;
		
		Vector3 cameraMove = new Vector3 (xAxis, yAxis, 0.0f);
		if (curX > maxX && xAxis < 0) {
			cameraMove.x = 0;
		} else if (curX < minX && xAxis > 0) {
			cameraMove.x = 0;
		} if (curY > maxY && yAxis > 0) {
			cameraMove.y = 0;
		} else if (curY < minY && yAxis < 0) {
			cameraMove.y = 0;
		} 
		this.transform.Translate (cameraMove);
		
	}
}
