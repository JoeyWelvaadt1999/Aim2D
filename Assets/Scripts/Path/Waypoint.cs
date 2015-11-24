using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {
	[SerializeField]private int _index;
	[SerializeField]private int _waypointNumber;
	public int Index {
		get {
			return _index;
		} 
	}

	public int WaypointNumber {
		get {
			return _waypointNumber;
		}
	}

}
