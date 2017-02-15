using UnityEngine;
using System.Collections;

public class PushTextToFront : MonoBehaviour 
{
	public string layerToPushTo;

	void Start () 
	{
		GetComponent<Renderer>().sortingLayerName = layerToPushTo;
	}
}