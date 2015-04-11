using UnityEngine;
using System.Collections;

public class managerScript : MonoBehaviour {

	public GameObject[] playerGameObjects = new GameObject[2];

	playerScript[] players;
	int resourcesPerTick = 1;
	float tickTime = 2.0f;
	float nextTick = 0.0f;

	// Use this for initialization
	void Start () {
		players = new playerScript[playerGameObjects.Length];
		int i = 0;
		foreach(GameObject player in playerGameObjects){
			players[i] = player.GetComponent<playerScript>();
			i++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= nextTick) {
			//determine the next tick, keeps ticks consistent
			nextTick += tickTime;
			//distribute resources to each player
			foreach(playerScript currentPlayer in players){
				currentPlayer.AddResources(resourcesPerTick);
			}
		}
	}
}
