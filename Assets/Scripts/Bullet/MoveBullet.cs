using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour {
	private float _speed = 8;

	public float Speed {
		get {
			return _speed;
		}
	}

	void FixedUpdate() {
		Vector2 move = this.transform.up;
		//
		move.Normalize();
		move *= Speed * Time.fixedDeltaTime;
		transform.position += new Vector3(move.x, move.y);
	}
}
