using UnityEngine;
using System.Collections;

public class EnemyLook : MonoBehaviour {
	private Transform _target;
	Path _path;


	// Use this for initialization
	void Start () {
		_path = GetComponent<Path>();
	}
	
	// Update is called once per frame
	void Update () {
		_target = _path.GetClosestWaypoint();
		_path.CheckIfAtWaypoint(_target);
		Vector3 distance = transform.position - _target.position;
		float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		if(transform.position.x < _target.transform.position.x - 0.5f) {
			Quaternion pTrot = transform.parent.rotation;
			pTrot.x = 0;
			pTrot.y = 180;
			pTrot.z = 0;
			transform.parent.rotation = pTrot;
		}

		if (transform.position.x > _target.transform.position.x + 0.5f) {
			Quaternion pTrot = transform.parent.rotation;
			pTrot.x = 0;
			pTrot.y = 0;
			pTrot.z = 0;
			transform.parent.rotation = pTrot;
		}
		
	}
}
