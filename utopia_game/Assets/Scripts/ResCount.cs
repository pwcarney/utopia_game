using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResCount : MonoBehaviour {

	public Text OilCount;
	public StorageController SC;
	private int TO;

	void Start () 
	{
		TO = 0; 
		SetTOil ();	
	}

	public void TOUpdate ()
	{
		TO = StorageController.TotalOil;
	}

	void SetTOil () 
	{
		OilCount.text = "Oil: " + TO.ToString();
	}
		
	void Update () 
	{
		TOUpdate();
		SetTOil ();
	}
}
