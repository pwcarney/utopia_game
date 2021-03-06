using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageWorkerController : MonoBehaviour 
{
	public float speed = 1f;
	public StorageController SC;
	public BuilderController BC;

	private GameObject seeking_oil_patch;
	private GameObject seeking_collector;
	public bool hasOil = false;

	void Start () 
	{
		float oil_patch_distance = Mathf.Infinity;
		foreach(GameObject oil_patch in GameObject.FindGameObjectsWithTag("Oil"))
		{
			float dist_to_patch = Vector3.Distance (transform.position, oil_patch.transform.position);
			if (dist_to_patch < oil_patch_distance) 
			{
				seeking_oil_patch = oil_patch;
				oil_patch_distance = dist_to_patch;
			}
		}

		float collector_distance = Mathf.Infinity;
		foreach(GameObject collector in GameObject.FindGameObjectsWithTag("Collector"))
		{
			float dist_to_collector = Vector3.Distance (transform.position, collector.transform.position);
			if (dist_to_collector < collector_distance) 
			{
				seeking_collector = collector;
				collector_distance = dist_to_collector;
			}
		}

	}

	void Update () 
	{
		if (!hasOil) 
		{
			transform.position = Vector2.MoveTowards (transform.position, seeking_oil_patch.transform.position, speed * Time.deltaTime);
		} 
		else if (hasOil) 
		{
			transform.position = Vector2.MoveTowards (transform.position, seeking_collector.transform.position, speed * Time.deltaTime);
		}

	}

	void OnTriggerEnter2D(Collider2D SC) 
	{
		if (SC.tag == "Oil") 
		{
			hasOil = true;
		} 
		else if (SC.tag == "Collector" && hasOil == true)
		{
			SC.gameObject.GetComponent<StorageController>().oil++;
			StorageController.TotalOil++;
			hasOil = false;
		}
	}
}
