using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResCount : MonoBehaviour {

	public Text OilCount;

	public int oil;



	// Use this for initialization
	void Start () 
	{
		GameObject.Find("Storage Controller").GetComponent<StorageController>().oil = 0;
		SetOil();	
	}

	void SetOil () 
	{
		OilCount.text = "Oil: " + oil.ToString();
	}

	
	// Update is called once per frame
	void Update () 
	{
		SetOil ();
	}
}
