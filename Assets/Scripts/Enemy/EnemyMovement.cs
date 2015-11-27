using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	[SerializeField]private GameObject _nozzle;
	private float _speed = 1;
	private float _timer;
	private bool _waterSpeed;
	private bool _earthSpeed;
	Rigidbody2D _rb2d;
	Vector2 velocity;
	Animator _anim;

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


	public bool EarthSpeed {
		get {
			return _earthSpeed;
		} set {
			_earthSpeed = value;
		}
	}

	public bool WaterSpeed {
		get {
			return _waterSpeed;
		} set {
			_waterSpeed = value;
		}
	}

	void Awake() {
		_rb2d = GetComponent<Rigidbody2D>();
		_anim = GetComponent<Animator>();
	}

	void FixedUpdate() {
		if(_earthSpeed) {
			_timer += Time.deltaTime;
			float seconds = Mathf.Floor(_timer%60);
			if(seconds < 2) {
				_speed = 0;
				Vector2 move = -_nozzle.transform.right;
				move.Normalize();
				move *= Speed * Time.fixedDeltaTime;
				transform.position += new Vector3(move.x, move.y);
				velocity = move;
				_anim.SetBool("EarthSpeed", true);

			} else {
				_speed = 1;
				_timer = 0;
				_earthSpeed = false;
				_anim.SetBool("EarthSpeed", false);
			}
		} else if (_waterSpeed){
			_timer += Time.deltaTime;
			float seconds = Mathf.Floor(_timer%60);
			if(seconds < 2) {
				_speed = 0.5f;
				Vector2 move = -_nozzle.transform.right;
				move.Normalize();
				move *= Speed * Time.fixedDeltaTime;
				transform.position += new Vector3(move.x, move.y);
				velocity = move;
				_anim.SetBool("WaterSpeed", true);
			} else {
				_speed = 1;
				_timer = 0; 
				_waterSpeed = false;
				_anim.SetBool("WaterSpeed", false);
			}
		}else {
			Vector2 move = -_nozzle.transform.right;
			move.Normalize();
			move *= Speed * Time.fixedDeltaTime;
			transform.position += new Vector3(move.x, move.y);
			velocity = move;
		}
	}	
}
