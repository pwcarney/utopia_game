using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPlacementController : MonoBehaviour {

	bool storagePlacement = false;
	bool builderPlacement = false;
	public GameObject storagePrefab;
	public GameObject builderPrefab;
	public Image storageButton;

	void Update()
	{
		if (Input.GetMouseButtonDown (0))  // Left click
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mousePos.z = 0;
			if (storagePlacement) 
			{
				Instantiate(storagePrefab, mousePos, Quaternion.identity);
				LeavePlacementMode ();
			}
			if (builderPlacement) 
			{
				Instantiate(builderPrefab, mousePos, Quaternion.identity);
				LeavePlacementMode ();
			}
		}

		if (Input.GetMouseButtonDown (1))  // Right click
		{
			LeavePlacementMode ();
		}
	}

	public void EnterStoragePlacementMode()
	{
		if (!storagePlacement) 
		{
			storagePlacement = true;

			Color buttonColor = storageButton.color;
			buttonColor.a -= 0.5f;
			storageButton.color = buttonColor;
		}
	}
	public void EnterBuilderPlacementMode()
	{
		if (!builderPlacement) 
		{
			builderPlacement = true;

			Color buttonColor = storageButton.color;
			buttonColor.a -= 0.5f;
			storageButton.color = buttonColor;
		}
	}

	void LeavePlacementMode()
	{
		if (storagePlacement) 
		{
			storagePlacement = false;

			Color buttonColor = storageButton.color;
			buttonColor.a += 0.5f;
			storageButton.color = buttonColor;
		}
		if (builderPlacement) 
		{
			builderPlacement = false;

			Color buttonColor = storageButton.color;
			buttonColor.a += 0.5f;
			storageButton.color = buttonColor;
		}
	}
}
