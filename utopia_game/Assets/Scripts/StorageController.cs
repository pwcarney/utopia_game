using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageController : MonoBehaviour {

	public GameObject workerPrefab;

	/*GameObject tempTextBox = (GameObject.Instantiate (OilCount, Vector3.zero, Quaternion.identity));
	TextMesh theText = tempTextBox.transform.GetComponent<TextMesh>();
	private theText.Text "The Text"; */

	private int oil;

	// Use this for initialization
	void Start () 
	{
		SpawnWorker ();
		oil = 0;
		SetOil();
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
		if (other.tag == "Worker")
		{
			oil = oil + 1;
			SetOil();
		}
	}
	void SetOil ()
	{
		GetComponentInChildren<TextMesh>().text = "Oil: " + oil.ToString();
	}
}
