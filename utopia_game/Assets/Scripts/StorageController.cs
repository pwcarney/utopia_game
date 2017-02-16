using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageController : MonoBehaviour {

	public GameObject workerPrefab;
	public Text OilCount;

	private int oil;

	// Use this for initialization
	void Start () 
	{
		SpawnWorker ();
		oil = 0;
		SetOilCount ();
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

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Worker"))
		{
			oil = oil + 1;
			SetOilCount ();
		}
	}

	void SetOilCount ()
	{
		OilCount.text = "Oil: " + oil.ToString ();
	}
}
