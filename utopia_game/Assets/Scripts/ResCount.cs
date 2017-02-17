using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResCount : MonoBehaviour {

	public Text OilCount;

	private int oil;



	// Use this for initialization
	void Start () 
	{
		oil = 0;
		SetOil();	
	}

	void SetOil () 
	{
		OilCount.text = "Oil: " + oil.ToString();
	}

	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other) 
    {
		if (other.tag == "Worker")
		{
			oil = oil + 1;
			SetOil ();
		}
    }
}
