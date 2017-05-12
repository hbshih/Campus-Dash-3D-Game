using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubwaySpawn : MonoBehaviour {

	public GameObject[] AI;
	public float spawnTime = 1f;
	public Transform spawnPoint;
	public static int lineposition = 0;
	GameObject chosenAI;

	// Use this for initialization
	void Awake () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Spawn () {
		chosenAI = AI[Random.Range (0, AI.Length)];
		if (lineposition <= 17) {
			Instantiate (chosenAI, spawnPoint.position, spawnPoint.rotation);
			lineposition++;
		}
	}
}
