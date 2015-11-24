using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {
	EnemyDie _ed;
	private float _power;
	public float Power {
		get {
			return _power;
		}
		set {
			_power = value;
		}
	}

	public void Hit(GameObject go) {
		_ed = go.GetComponent<EnemyDie>();
		_ed.Die(false, _power);
	}
}
