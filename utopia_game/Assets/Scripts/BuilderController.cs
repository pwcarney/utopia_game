using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuilderController : MonoBehaviour 
{

	public GameObject workerPrefab;
	public GameObject warriorPrefab;
	public WorkerController WC;
	public Text OilCount;
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
			SpawnWarrior ();
			oil = oil - cost;
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

	void SpawnWarrior()
	{
		Vector3 spawnPosition = transform.position;
		spawnPosition.y -= 1f;
		Instantiate(warriorPrefab, spawnPosition, Quaternion.identity);
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "BuildBot")
		{
			SetOil();
		}
	}
	public void SetOil ()
	{
		GetComponentInChildren<TextMesh>().text = "Oil: " + oil.ToString();
	}
}
