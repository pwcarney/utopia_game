﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour {

	public float damage = 1f;
	public float hitpoints = 5f;
	public float speed = 1f;

	public string enemy;
	public float enemyDetectRadius;
	public LayerMask unwalkableMask;

	[HideInInspector]
	public bool killed = false;

	[HideInInspector]
	public List<GameObject> enemies;

	Vector2[] path;
	int targetIndex;

	Vector2 destination = Vector2.zero;

	void Start () 
	{
		GetComponentInChildren<EnemyDetector> ().enemy = enemy;
		GetComponentInChildren<CircleCollider2D> ().radius = enemyDetectRadius;

		StartCoroutine (RefreshPath ());
	}

	void Update ()
	{
		if (killed)
			Destroy (this.gameObject);
	}

	Vector3 GetCurrentDestination()
	{
		if (enemies.Count > 0) 
		{
			Vector3 myPos = transform.position;

			GameObject closest_choice = null;
			float closest = Mathf.Infinity;

			foreach (GameObject choice in enemies) 
			{
				float dist = Vector3.Distance (myPos, choice.transform.position);
				if (dist < closest) 
				{
					closest = dist;
					closest_choice = choice;
				}
			}

			return closest_choice.transform.position;
		} 
		else 
		{
			return Vector3.zero;
		}
	}

	IEnumerator RefreshPath() 
	{
		Vector2 targetPositionOld = destination + Vector2.up;

		while (true) 
		{
			destination = (Vector2)GetCurrentDestination ();

			if (destination == Vector2.zero) 
			{
				// There are no enemies
				StopCoroutine ("Beeline");
				StopCoroutine ("FollowPath");

				yield return new WaitForSeconds (.05f);
				continue;
			}

			Vector2 currentPos = (Vector2)transform.position;
			if (Physics2D.Raycast (
				currentPos, 
				destination - currentPos, 
				enemyDetectRadius, 
				unwalkableMask).collider == null) 
			{
				// Nothing in way, so just beeline toward destination
				StopCoroutine ("FollowPath");
				StopCoroutine ("Beeline");

				StartCoroutine ("Beeline");
			}
			else if (targetPositionOld != destination) 
			{
				// We have to pathfind, boo hoo
				targetPositionOld = destination;

				path = Pathfinding.RequestPath (transform.position, destination);
				StopCoroutine ("FollowPath");
				StopCoroutine ("Beeline");

				StartCoroutine ("FollowPath");
			}

			yield return new WaitForSeconds (.25f);
		}
	}    

	IEnumerator Beeline() 
	{
		while (true) 
		{
			Turn (destination);
			transform.position = Vector2.MoveTowards (transform.position, destination, speed * Time.deltaTime);

			yield return null;
		}
	}

	IEnumerator FollowPath() 
	{
		if (path.Length > 0) 
		{
			targetIndex = 0;
			Vector2 currentWaypoint = path [0];

			while (true) 
			{
				if ((Vector2)transform.position == currentWaypoint) 
				{
					targetIndex++;
					if (targetIndex >= path.Length) {
						yield break;
					}
					currentWaypoint = path [targetIndex];
				}
					
				Turn (currentWaypoint);
				transform.position = Vector2.MoveTowards (transform.position, currentWaypoint, speed * Time.deltaTime);

				yield return null;

			}
		}
	}

	void Turn (Vector2 dest)
	{
		Vector3 facing = (Vector3)dest - transform.position;
		transform.rotation = Quaternion.LookRotation(Vector3.forward, facing);
		if (facing.x <= 0) {
			transform.Rotate (new Vector3 (1, 1, -90));
			GetComponent<SpriteRenderer> ().flipX = false;
		} else {
			transform.Rotate (new Vector3 (1, 1, 90));	
			GetComponent<SpriteRenderer> ().flipX = true;
		}
	}

	public void Kill()
	{
		killed = true;
	}
}
