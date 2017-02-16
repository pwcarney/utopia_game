using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour {

	public float speed = 1;
	public string enemy;

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

		StartCoroutine (RefreshPath ());
	}

	void Update ()
	{
		if (killed)
			Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == enemy) 
		{
			enemies.Remove (other.gameObject);
			other.gameObject.GetComponent<WarriorController> ().Kill ();
		}
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
				yield return new WaitForSeconds (.25f);
				continue;
			}

			if (targetPositionOld != destination) 
			{
				targetPositionOld = destination;

				path = Pathfinding.RequestPath (transform.position, destination);
				StopCoroutine ("FollowPath");
				StartCoroutine ("FollowPath");
			}

			yield return new WaitForSeconds (.25f);
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

				//transform.rotation = Quaternion.LookRotation(Vector3.forward, player.transform.position - transform.position);
				transform.position = Vector2.MoveTowards (transform.position, currentWaypoint, speed * Time.deltaTime);

				yield return null;

			}
		}
	}

	public void Kill()
	{
		killed = true;
	}
}
