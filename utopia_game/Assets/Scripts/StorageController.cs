using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageController : MonoBehaviour {

	public GameObject workerPrefab;

	// Use this for initialization
	void Start () 
	{
		SpawnWorker ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnMouseDown()
	{
		SpawnWorker ();
	}

	void SpawnWorker()
	{
		Vector3 spawnPosition = transform.position;
		spawnPosition.y -= 0.5f;
		Instantiate(workerPrefab, spawnPosition, Quaternion.identity);
	}
}
