//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class WarriorController : MonoBehaviour {
//
//	public Transform target;
//	public float speed = 20;
//
//	Vector2[] path;
//	int targetIndex;
//
//	void Start () 
//	{
//		StartCoroutine (RefreshPath ());
//	}
//
//	Vector3 GetCurrentDestination()
//	{
//		if (!Pathfinding.IsPlayerReachable (player.GetComponent<Transform> ().position) && GetComponentInChildren<Renderer> ().isVisible) 
//		{
//			playerChase = false;
//
//			List<float> dists = new List<float>();
//			for (int i = 0; i < corners.Length; i++)
//			{
//				dists.Add (Vector3.Distance (corners [i], player.GetComponent<Transform> ().position));
//			}
//			cornerInd = dists.IndexOf(dists.Max ());
//		} 
//		else if (Pathfinding.IsPlayerReachable (player.GetComponent<Transform> ().position)) 
//		{
//			playerChase = true;
//		}
//
//		if (playerChase) 
//		{
//			return player.GetComponent<Transform> ().position;
//		} 
//		else 
//		{
//			return corners [cornerInd];
//		}
//	}
//
//	IEnumerator RefreshPath() 
//	{
//		Vector2 targetPositionOld = (Vector2)GetCurrentDestination() + Vector2.up;
//
//		while (true) 
//		{
//			if (targetPositionOld != (Vector2)GetCurrentDestination()) 
//			{
//				targetPositionOld = (Vector2)GetCurrentDestination();
//
//				path = Pathfinding.RequestPath (transform.position, GetCurrentDestination());
//				StopCoroutine ("FollowPath");
//				StartCoroutine ("FollowPath");
//			}
//
//			yield return new WaitForSeconds (.25f);
//		}
//	}    
//
//	IEnumerator FollowPath() 
//	{
//		if (path.Length > 0) 
//		{
//			targetIndex = 0;
//			Vector2 currentWaypoint = path [0];
//
//			while (true) 
//			{
//				if ((Vector2)transform.position == currentWaypoint) 
//				{
//					targetIndex++;
//					if (targetIndex >= path.Length) {
//						yield break;
//					}
//					currentWaypoint = path [targetIndex];
//				}
//
//				transform.rotation = Quaternion.LookRotation(Vector3.forward, player.transform.position - transform.position);
//				transform.position = Vector2.MoveTowards (transform.position, currentWaypoint, speed * Time.deltaTime);
//
//				yield return null;
//
//			}
//		}
//	}
//}
