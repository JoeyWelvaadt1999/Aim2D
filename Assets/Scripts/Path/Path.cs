using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {
	private int _index = 0;
	private int _currentPos = 0;
	private List<Transform> _waypointsContainer = new List<Transform>();

	public Transform GetClosestWaypoint () {
		Waypoint[] waypoints = GameObject.FindObjectsOfType<Waypoint>();
		float closestDistance = int.MaxValue;
		Transform newWaypoint = null;
		foreach(Waypoint w in waypoints) {
			float distance = Vector2.Distance(transform.position, w.transform.position);
			Waypoint currentW = w.GetComponent<Waypoint>();
			if(_currentPos == currentW.WaypointNumber) {
				if(!_waypointsContainer.Contains(w.transform)) {
					if(_index == currentW.Index || _index == 0) {
						_index = currentW.Index;
						if(distance < closestDistance) {
							newWaypoint = w.transform;
							closestDistance = distance;
						}
					}
				}
			}
		}
		return newWaypoint;
	}

	public bool CheckIfAtWaypoint(Transform target) {
		if(transform.position.x >= target.position.x - 0.1f && transform.position.x <= target.position.x + 0.1f &&
		   transform.position.y >= target.position.y - 0.1f && transform.position.y <= target.position.y + 0.1f) {
			_waypointsContainer.Add(GetClosestWaypoint());
			_currentPos++;
			return true;
		} else {
			return false;
		}
	}

}
