using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour {

	[HideInInspector]
	public string enemy;

	WarriorController parentController;

	void Start()
	{
		parentController = GetComponentInParent<WarriorController> ();
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == enemy) 
		{
			if (!other.gameObject.GetComponent<WarriorController> ().killed) 
			{
				Debug.Log ("Found enemy!");
				if (!parentController.enemies.Contains (other.gameObject))
					parentController.enemies.Add (other.gameObject);
			}
		}
	}
}
