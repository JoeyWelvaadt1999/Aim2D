using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
	private bool _canShake;
	private float _shakeTimer;
	public bool CanShake {
		get {
			return _canShake;
		} set {
			_canShake = value;
		}
	}
	void Update() {
		if(_canShake) {
			_shakeTimer += Time.deltaTime;
			if(_shakeTimer <= 1) {
				Shake(1.0f);
			}else {
				_canShake = false;
				_shakeTimer = 0;
			}
		}
	}

	void Shake(float amount) {
		Vector2 tPos = transform.position;
		transform.localPosition = tPos + new Vector2(Random.insideUnitCircle.x, Random.insideUnitCircle.y) * amount;			
	}	
}
