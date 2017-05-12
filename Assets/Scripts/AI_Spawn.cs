using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Spawn : MonoBehaviour {

	public GameObject[] AI;
	public float spawnTime = 0.05f;
	public Transform[] spawnPoints;
	public static Transform chosenPoint;

	void Start()
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}


	void Spawn()
	{
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		chosenPoint = spawnPoints [spawnPointIndex];
		Instantiate (AI[Random.Range (0, AI.Length)], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
	}
		
}
