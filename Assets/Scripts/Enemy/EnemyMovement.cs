using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	[SerializeField]private GameObject _nozzle;
	private float _speed = 1;
	Rigidbody2D _rb2d;
	Vector2 velocity;

	public Vector2 Velocity {
		get{
			return velocity;
		}
	}

	public float Speed {
		get {
			return _speed;
		}
	}

	void Awake() {
		_rb2d = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		Vector2 move = -_nozzle.transform.right;
//
		move.Normalize();
		move *= Speed * Time.fixedDeltaTime;
		transform.position += new Vector3(move.x, move.y);
		velocity = move;
	}	
}
