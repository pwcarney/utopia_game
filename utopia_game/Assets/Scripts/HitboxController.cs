using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxController : MonoBehaviour {

	float damage;
	float lastDamage;
	float attackCooldown = 1f;

	string enemy;

	void Start () 
	{
		damage = GetComponentInParent<WarriorController> ().damage;
		enemy = GetComponentInParent<WarriorController> ().enemy;

		lastDamage = -attackCooldown;
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == enemy && Time.timeSinceLevelLoad > lastDamage + attackCooldown) 
		{
			other.gameObject.GetComponent<WarriorController> ().hitpoints -= damage;
			Debug.Log ("Other hp:" + other.gameObject.GetComponent<WarriorController> ().hitpoints.ToString());
			lastDamage = Time.timeSinceLevelLoad;

			if (other.gameObject.GetComponent<WarriorController> ().hitpoints <= 0) 
			{
				other.gameObject.GetComponent<WarriorController> ().Kill ();
				GetComponentInParent<WarriorController> ().enemies.Remove (other.gameObject);
			}
		}
	}
}
