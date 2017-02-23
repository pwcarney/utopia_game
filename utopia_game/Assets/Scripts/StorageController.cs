using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageController : MonoBehaviour {

	public GameObject workerPrefab;
	public Text OilCount;
	public static int TotalOil;
	public int oil;

	private int x;
	private int cost;


	// Use this for initialization
	void Start () 
	{
		SpawnWorker ();
		oil = 0;
		x = 1;
		SetOil();
		cost = 5*x;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnMouseDown()
	{
		if (oil >= cost)
		{
			SpawnWorker ();
			oil = oil - cost;
			TotalOil = TotalOil - cost;
			x++;
			SetOil();
			cost = 5 * x;
		}
		else
		{
			GetComponentInChildren<TextMesh>().text = "Not Enough Oil!";
			Invoke("SetOil", 1);
		}
	}


	void SpawnWorker()
	{
		Vector3 spawnPosition = transform.position;
		spawnPosition.y -= 0.5f;
		Instantiate(workerPrefab, spawnPosition, Quaternion.identity);
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Robot")
		{
			SetOil();
		}
		if (other.tag == "BuildBot" && oil >= 2 && TotalOil >= 2)
		{
			oil = oil - 2;
			TotalOil = TotalOil - 2;
			SetOil();
		}

	}
	public void SetOil ()
	{
		GetComponentInChildren<TextMesh>().text = "Oil: " + oil.ToString();
	}
}
